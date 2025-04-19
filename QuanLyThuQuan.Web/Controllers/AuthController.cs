using Microsoft.AspNetCore.Mvc;

namespace QuanLyThuQuan.Web.Controllers
{
    public class AuthController : Controller
    {
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
    }
}
