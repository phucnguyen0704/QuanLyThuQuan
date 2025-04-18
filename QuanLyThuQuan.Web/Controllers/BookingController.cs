using Microsoft.AspNetCore.Mvc;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;
using QuanLyThuQuan.Web.Services.SeatService;

namespace QuanLyThuQuan.Web.Controllers
{
    [Route("booking")]
    public class BookingController : Controller
    {
        private readonly ISeatService _seatService;

        public BookingController(ISeatService seatService)
        {
            _seatService = seatService;
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
        public IActionResult Booking()
        {
            return View();
        }

        [HttpGet]
        [Route("history")]
        public IActionResult HistoryBooking()
        {
            return View();
        }
    }
}
