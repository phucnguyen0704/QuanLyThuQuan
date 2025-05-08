using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyThuQuan.Utils
{
    class Checker
    {
        public static bool IsExitsMemberId(uint memberId)
        {
            // Check if the email exists in the database
            MemberBLL memberBLL = new MemberBLL();
            if (memberBLL.getByID(memberId) != null)
            {
                return true; // ID exists
            }
            return false; // ID does not exist
        }


        public static bool IsValidEmail(string email)
        {
            // Simple regex for email validation
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static uint IsExistEmail(string email)
        {
            // Check if the email exists in the database
            MemberBLL memberBLL = new MemberBLL();
            MemberDTO memberDTO = memberBLL.getByEmail(email);
            if (memberDTO != null)
            {
                return memberDTO.MemberId; // Email exists
            }
            return 0; // Email does not exist
        }

        public static bool IsValidPhone(string phoneNumber)
        {
            // Simple regex for phone number validation
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{9:}$");
        }

        public static uint IsExistPhone(string phone)
        {
            // Check if the email exists in the database
            MemberBLL memberBLL = new MemberBLL();
            MemberDTO memberDTO = memberBLL.getByPhone(phone);
            if (memberDTO != null)
            {
                return memberDTO.MemberId; // Phone exists
            }
            return 0; // Phone does not exist
        }

        public static bool IsValidPassword(string password)
        {
            // Check if the password meets certain criteria
            return password.Length >= 6; // Example condition
        }

        public static bool IsValidDate(DateTime date)
        {
            // Check if the date is in the past
            return date <= DateTime.Now;
        }
        public static string ValidatePasswordChange(uint memberId, string oldPassword, string newPassword, string confirmPassword, string role)
        {
            // Kiểm tra null hoặc rỗng
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                return "Vui lòng không để trống các trường.";
            }

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Vui lòng nhập đầy đủ thông tin và không được để mật khẩu chỉ khoảng trắng.";
            }

            // Kiểm tra mật khẩu mới và xác nhận khớp nhau
            if (newPassword != confirmPassword)
            {
                return "Mật khẩu mới và xác nhận mật khẩu không khớp.";
            }

            // Kiểm tra mật khẩu mới khác mật khẩu cũ
            if (oldPassword == newPassword)
            {
                return "Mật khẩu mới không được trùng mật khẩu cũ.";
            }

            // Gọi checkLogin từ MemberBLL để xác thực mật khẩu cũ
            MemberBLL memberBLL = new MemberBLL();
            int loginResult = memberBLL.checkLogin(memberId, oldPassword, role);

            if (loginResult != 1)
            {
                return "Mật khẩu cũ không chính xác.";
            }

            // Nếu mọi thứ đều hợp lệ
            return "VALID";
        }

        public static bool IsWhiteSpace(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Trim().Length == 0;
        }

    }
}
