using MySqlConnector;
using QuanLyThuQuan.Web.Data;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private string _connectionString;

        public AuthService(IConfiguration configuration, AppDbContext appDb)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _db = appDb;
        }

        public Response<Member> Login(string memberid, string password)
        {
            Response<Member> response = new();
            try
            {
                var member = _db.Members.SingleOrDefault(m => m.MemberId.ToString().Equals(memberid));
                if (member == null)
                {
                    response.Success = false;
                    response.Message = $"Không tồn tại ID thành viên {memberid}";
                    response.Data = null;
                    return response;
                }
                response.Success = BCrypt.Net.BCrypt.Verify(password, member.Password);
                if (response.Success)
                {
                    response.Message = "Đăng nhập thành công";
                    response.Data = member;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Sai mật khẩu";
                    response.Data = null;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }

        public async Task<Response<Member>> Register(Member member)
        {
           Response<Member> response = new();
            try
            {
                var memberId = await _db.Members.FindAsync(member.MemberId);
                if (memberId != null)
                {
                    response.Success = false;
                    response.Message = "Mã thành viên đã tồn tại";
                    response.Data = member;
                    return response;
                }
                member.Password = BCrypt.Net.BCrypt.HashPassword(member.Password);
                member.Role = "member"; 
                _db.Add(member);
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    response.Success = true;
                    response.Message = "Đăng ký thành viên thành công";
                    response.Data = member;
                }
            }
            catch(MySqlException mex)
            {
                response.Success = false;
                response.Message = mex.Message;
                response.Data = null;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }
    }
}
