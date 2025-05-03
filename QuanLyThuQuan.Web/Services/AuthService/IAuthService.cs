using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.AuthService
{
    public interface IAuthService
    {
         Response<Member> Login(string memberid, string password);

        Task<Response<Member>> Register(Member member);

        Task<Response<Member>> UpdatePassword(ChangePasswordDTO changePasswordDTO, string memberId);

        Task<Response<Member>> UpdateProfile (Member member);

        Task<Response<Member>> GetById(string memberId);
    }
}
