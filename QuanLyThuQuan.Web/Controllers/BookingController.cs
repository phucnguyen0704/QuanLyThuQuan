using Microsoft.AspNetCore.Mvc;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;
using QuanLyThuQuan.Web.Services.BookingService;
using QuanLyThuQuan.Web.Services.DeviceService;
using QuanLyThuQuan.Web.Services.SeatService;
using QuanLyThuQuan.Web.Services.VolationService;

namespace QuanLyThuQuan.Web.Controllers
{
    [Route("booking")]
    public class BookingController : Controller
    {
        private readonly ISeatService _seatService;
        private readonly IDeviceService _deviceService;
        private readonly IBookingService _bookingService;
        private readonly IViolationService _violationService;

        public BookingController(ISeatService seatService, IDeviceService deviceService, IBookingService bookingService, IViolationService violationService)
        {
            _seatService = seatService;
            _deviceService = deviceService;
            _bookingService = bookingService;
            _violationService = violationService;
        }

        [HttpGet]
        [Route("viewseat")]
        public async Task<IActionResult> ViewSeat() // Fixed return type to Task<IActionResult>
        {
            Response<List<Seat>> seatGetAll = await _seatService.GetAllSeats();
            if (seatGetAll.Success == false)
            {
                return View("Error", seatGetAll.Message);
            }
            ViewBag.seats = seatGetAll.Data;

            return View("ViewSeat");
        }

        [HttpGet]
        [Route("newreservation")]
        public async Task<IActionResult> Booking(int? seatId)
        {

            if (HttpContext.Session.GetString("memberId") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            Response<List<Seat>> seatGetAll = await _seatService.GetAllSeats();
            var deviceGetAll = await _deviceService.GetAllAvailable();
            if (seatGetAll.Success == false)
            {
                TempData["err"] = deviceGetAll.Message;
                return View("Error", seatGetAll.Message);
            }
            if (deviceGetAll.Success == false)
            {
                TempData["err"] = deviceGetAll.Message;
                return View("Error", deviceGetAll.Message);
            }
            ViewBag.seats = seatGetAll.Data;
            ViewBag.seatId = seatId;
            ViewBag.devices = deviceGetAll.Data;
            ViewBag.memberId = HttpContext.Session.GetString("memberId");
            return View();
        }

        [HttpPost]
        [Route("newreservationStore")]
        public async Task<IActionResult> BookingStore(ReservationDTO reservationDTO, List<uint> deviceIds)
        {
            if (reservationDTO.Reservation.SeatId == 0 && reservationDTO.Reservation.ReservationType == 1)
            {
                TempData["err"] ="Hãy chọn chỗ ngồi";
                return RedirectToAction("Booking");
            }

            var response = await _bookingService.CreateBooking(reservationDTO, deviceIds);
            if (response.Success)
            {
                TempData["success"] = "Đặt chỗ thành công";
                return RedirectToAction("ViewSeat");
            }
            TempData["err"] = response.Message;
            return RedirectToAction("Booking");

        }

        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> HistoryBooking()
        {
            var result = await _bookingService.GetMemberBookings(long.Parse(HttpContext.Session.GetString("memberId")));

            return View(result.Data);
        }

        [HttpGet]
        [Route("history-regulation")]
        public async Task<IActionResult> HistoryRegulation()
        {
            var result = await _violationService.GetViolations(HttpContext.Session.GetString("memberId") ?? "");

            return View(result.Data);
        }

        [HttpGet]
        [Route("api/reservations/{reservationId}/details")]
        public async Task<IActionResult> GetReservationDetails(int reservationId)
        {
            var details = await _bookingService.GetReservationDetails(reservationId);
            if (!details.Success)
            {
                TempData["err"] = details.Message;
                return NotFound();
            }
            return Ok(details.Data);
        }
    }
}
