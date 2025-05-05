using Microsoft.AspNetCore.Mvc;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;
using QuanLyThuQuan.Web.Services.AuthService;

namespace QuanLyThuQuan.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string memberId, string password)
        {
           
                var response = _authService.Login(memberId, password);
                if (response.Success)
                {
                    HttpContext.Session.SetString("memberId", memberId);
                TempData["success"] = "Đăng nhập thành công";
                    return RedirectToAction("ViewSeat", "Booking");
                }
            TempData["err"] = "Thông tin tài khoản không hợp lệ";
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Member member)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.Register(member);
                if (response.Success)
                {
                    return RedirectToAction("Login");
                }
               TempData["err"] = response.Message;
                return View(member);
            }
            TempData["err"] = "Xin vui lòng kiểm tra lại và nhập đủ thông tin";
            return View(member);
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("memberId") != null)
            {
                HttpContext.Session.Remove("memberId");
            }
            return RedirectToAction("ViewSeat", "Booking");
        }
    }
}
