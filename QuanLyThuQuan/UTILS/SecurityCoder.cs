using BCrypt.Net;                   
using System;                       
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.Utils
{
    class SecurityCoder
    {
        public static string Encrypt(string input)
        {
                return BCrypt.Net.BCrypt.HashPassword(input);

        }

        public static bool Verify(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
    }
}
