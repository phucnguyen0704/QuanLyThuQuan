using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.AuthService
{
    public interface IAuthService
    {
         Response<Member> Login(string memberid, string password);

        Task<Response<Member>> Register(Member member);
    }
}
