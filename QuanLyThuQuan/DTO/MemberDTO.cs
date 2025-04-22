using System;

namespace QuanLyThuQuan.DTO
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        // Thêm thuộc tính Username ở đây
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }

        // Bạn có thể có thêm các thuộc tính khác tùy theo cấu trúc bảng thanhvien của bạn
    }
}