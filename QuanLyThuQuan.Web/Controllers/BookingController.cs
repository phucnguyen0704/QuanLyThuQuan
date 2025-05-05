using Microsoft.AspNetCore.Mvc;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;
using QuanLyThuQuan.Web.Services.BookingService;
using QuanLyThuQuan.Web.Services.DeviceService;
using QuanLyThuQuan.Web.Services.SeatService;

namespace QuanLyThuQuan.Web.Controllers
{
    [Route("booking")]
    public class BookingController : Controller
    {
        private readonly ISeatService _seatService;
        private readonly IDeviceService _deviceService;
        private readonly IBookingService _bookingService;

        public BookingController(ISeatService seatService, IDeviceService deviceService, IBookingService bookingService)
        {
            _seatService = seatService;
            _deviceService = deviceService;
            _bookingService = bookingService;
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

            if(HttpContext.Session.GetString("memberId") == null)
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
            
                var response = await _bookingService.CreateBooking(reservationDTO, deviceIds);
                if (response.Success)
                {
                    TempData["success"] = "Đặt chỗ thành công";
                    return RedirectToAction("ViewSeat");
                }
                TempData["err"] = response.Message;
                return View(reservationDTO);
            
        }

        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> HistoryBooking()
        {
            var result = await _bookingService.GetMemberBookings(long.Parse(HttpContext.Session.GetString("memberId")));

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
