using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index2()
        {
            return RedirectToAction("ViewSeat", "Booking");
        }

        [HttpGet]
        [Route("profile")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
