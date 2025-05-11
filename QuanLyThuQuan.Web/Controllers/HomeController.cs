using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;
using QuanLyThuQuan.Web.Services.AuthService;

namespace QuanLyThuQuan.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [Route("")]
        public IActionResult Index2()
        {
            return RedirectToAction("ViewSeat", "Booking");
        }

        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> Index()
        {
            var memberId = HttpContext.Session.GetString("memberId")??null;
            if (memberId == null) {
                TempData["err"] = "Xin hãy đăng nhập để truy cập!";
                return RedirectToAction(nameof(Index2));
            }
            var response = await _authService.GetById(memberId);
            if (response.Success)
            {
                return View(response.Data);

            }
            else
            {
                if(response.Data.Status == 3)
                {
                    TempData["err"] = response.Message;
                    return RedirectToAction("Logout", "Auth");
                }
                TempData["err"] = response.Message;
                return RedirectToAction(nameof(Index2));
            }
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit(Member member)
        {
            var response = await _authService.UpdateProfile(member);
            if (response.Success)
            {
                TempData["success"] = response.Message;
              
            }
            else
            {
                if (response.Data.Status == 3)
                {
                    TempData["err"] = response.Message;
                    return RedirectToAction("Logout", "Auth");
                }
                TempData["err"] = response.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> UpdatePassword(ChangePasswordDTO changePasswordDTO)
        {
            if (changePasswordDTO.Password.Equals(changePasswordDTO.NewPassword))
            {
                TempData["err"] = "Mật khẩu mới không được trùng với mật khẩu cũ";
                return RedirectToAction(nameof(ChangePassword));
            }
            if (changePasswordDTO.ConfirmPassword != changePasswordDTO.NewPassword)
            {
                TempData["err"] = "Xác nhận mật khẩu phải giống với mật khẩu mới";
                return RedirectToAction(nameof(ChangePassword));
            }
            var response = await _authService.UpdatePassword(changePasswordDTO, HttpContext.Session.GetString("memberId"));
            if (response.Success)
            {
                TempData["success"] = response.Message;
            }
            else
            {
                if (response.Data.Status == 3)
                {
                    TempData["err"] = response.Message;
                    return RedirectToAction("Logout", "Auth");
                }
                TempData["err"] = response.Message;
            }
            return RedirectToAction(nameof(ChangePassword));
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
