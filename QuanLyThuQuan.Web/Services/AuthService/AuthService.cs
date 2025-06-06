﻿using Microsoft.EntityFrameworkCore;
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

        public bool IsWhiteSpace(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Trim().Length == 0;
        }

        public async Task<Response<Member>> GetById(string memberId)
        {
            Response<Member> response = new();
            try
            {
                var member = await _db.Members.FirstOrDefaultAsync(m => m.MemberId.ToString().Equals(memberId));
                if (member == null)
                {
                    response.Success = false;
                    response.Message = "Không tìm thấy thành viên";
                    return response;
                }
                response.Success = true;
                response.Data = member;
            }
            catch (MySqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
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
                if (member.Status == 3)
                {
                    response.Success = false;
                    response.Message = $"Tài khoản của bạn đã bị khóa! Xin vui lòng đến thư quán để biết thêm thông tin";
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
                //Check Email
                if (await IsEmailExists(member.Email??""))
                {
                    response.Success = false ;
                    response.Message = "Email đã tồn tại!";
                    response.Data = member;
                    return response;
                }

                //Check Phone Number
                if (await IsPhoneNumberExists(member.PhoneNumber ?? ""))
                {
                    response.Success = false;
                    response.Message = "Số điện thoại đã tồn tại!";
                    response.Data = member;
                    return response;
                }

                var memberId = await _db.Members.FirstOrDefaultAsync(m => m.MemberId == member.MemberId);
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
            catch (MySqlException mex)
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

        public async Task<bool> IsEmailExists(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false; // Email rỗng không nên xem là tồn tại
                }

                var member = await _db.Members
                    .FirstOrDefaultAsync(m => m.Email.ToLower() == email.ToLower());

                return member != null;
            }
            catch
            {
                // Tùy logic, có thể log lỗi rồi throw lại, hoặc trả về false
                return false;
            }
        }

        public async Task<bool> IsPhoneNumberExists(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    return false; // Số rỗng thì xem như không tồn tại
                }

                var member = await _db.Members
                    .FirstOrDefaultAsync(m => m.PhoneNumber == phoneNumber);

                return member != null;
            }
            catch
            {
                // Có thể ghi log và trả về false hoặc throw nếu cần
                return false;
            }
        }

        public async Task<Response<Member>> UpdatePassword(ChangePasswordDTO changePasswordDTO, string memberId)
        {
            Response<Member> response = new();
            try
            {
                var member = await _db.Members.Where(m => m.MemberId.ToString() == memberId).FirstOrDefaultAsync();
                if (member.Status == 3)
                {
                    response.Success = false;
                    response.Message = "Ohhh!No. Tài khoản của bạn đã bị khóa!Hẹn không gặp lại bạn!";
                    response.Data = member;
                    return response;

                }
                if (member != null)
                {
                    if (IsWhiteSpace(changePasswordDTO.Password) || IsWhiteSpace(changePasswordDTO.NewPassword) || IsWhiteSpace(changePasswordDTO.ConfirmPassword))
                    {
                        response.Success = false;
                        response.Message = "Vui lòng nhập mật khẩu không chỉ khoảng trắng!";
                        return response;
                    }

                    if (string.IsNullOrWhiteSpace(changePasswordDTO.Password) || string.IsNullOrWhiteSpace(changePasswordDTO.NewPassword) || IsWhiteSpace(changePasswordDTO.ConfirmPassword))
                    {
                        response.Success = false;
                        response.Message = "Vui lòng không để trống mật khẩu!";
                        return response;
                    }


                    if (!BCrypt.Net.BCrypt.Verify(changePasswordDTO.Password, member.Password))
                    {
                        if (!BCrypt.Net.BCrypt.Verify(changePasswordDTO.Password, member.Password))
                        {
                            response.Success = false;
                            response.Message = "Mật khẩu cũ không đúng. Xin vui lòng nhập lại!";
                            return response;
                        }
                        member.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDTO.NewPassword);
                        _db.Members.Update(member);
                        if (await _db.SaveChangesAsync() > 0)
                        {
                            response.Success = true;
                            response.Message = "Cập nhật mật khẩu thành công!";
                        }

                    }
                }
            }
            catch (MySqlException mex)
            {
                response.Success = false;
                response.Message = mex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<Member>> UpdateProfile(Member member)
        {
            Response<Member> response = new();
            try
            {
                var obj = await _db.Members.Where(m => m.MemberId == member.MemberId).FirstOrDefaultAsync();
               
                if (obj.Status == 3)
                {
                    response.Success = false;
                    response.Message = "Ohhh!No. Tài khoản của bạn đã bị khóa!Hẹn không gặp lại bạn!";
                    response.Data = obj;
                    return response;

                }
                if (obj != null)
                {
                    obj.PhoneNumber = member.PhoneNumber;
                    obj.Email = member.Email;
                    obj.Birthday = member.Birthday;

                    await _db.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Cập nhật thông tin cá nhân thành công";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Lỗi! Không tìm thấy thành viên";
                }
            }
            catch (MySqlException mex)
            {
                response.Success = false;
                response.Message = mex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
