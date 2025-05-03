using System;
using System.Collections.Generic;
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;

namespace QuanLyThuQuan.BLL
{
    public class MemberBLL
    {
        private MemberDAL dal = new MemberDAL();

        // Tạo một đối tượng MemberDTO rỗng
        public MemberDTO CreateEmptyMember()
        {
            return new MemberDTO
            {
                MemberId = 0,
                FullName = string.Empty,
                Email = string.Empty,
                Birthday = DateTime.Today,
                PhoneNumber = string.Empty,
                Department = string.Empty,
                Major = string.Empty,
                Class = string.Empty,
                Password = string.Empty,
                Role = string.Empty,
                Status = 0,
                CreatedAt = DateTime.Today
            };
        }

        // Lấy danh sách tất cả thành viên
        public List<MemberDTO> GetAllMembers()
        {
            return dal.GetAllMembers();
        }

        // Thêm một thành viên mới
        public bool AddMember(MemberDTO member)
        {
            try
            {
                dal.AddMember(member);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        // Xóa thành viên theo ID
        public bool DeleteMember(int id)
        {
            try
            {
                dal.DeleteMember(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        // Cập nhật thông tin thành viên
        public bool UpdateMember(MemberDTO member)
        {
            try
            {
                dal.UpdateMember(member);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        // Lấy thông tin thành viên theo ID
        public MemberDTO GetMemberById(int id)
        {
            return dal.GetMemberById(id);
        }
    }
}
