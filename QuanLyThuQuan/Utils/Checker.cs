using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;

namespace QuanLyThuQuan.Utils
{
    class Checker
    {
        public static bool IsExitsMemberId(int memberId)
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

        public static int IsExistEmail(string email)
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

        public static int IsExistPhone(string phone)
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
    }
}
