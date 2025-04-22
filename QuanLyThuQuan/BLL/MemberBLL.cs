    using System.Collections.Generic;
    using QuanLyThuQuan.DAL;
    using QuanLyThuQuan.DTO;

    namespace QuanLyThuQuan.BLL
    {
        public class MemberBLL
        {
            private MemberDAL dal = new MemberDAL();

            // Lấy danh sách tất cả thành viên
            public List<MemberDTO> LayTatCa()
            {
                return dal.LayDanhSachThanhVien();
            }

            // Thêm một thành viên mới
            public bool ThemThanhVien(MemberDTO member)
            {
                return dal.ThemThanhVien(member);
            }

            // Xóa thành viên theo ID
            public bool XoaThanhVien(int id)
            {
                return dal.XoaThanhVien(id);
            }

            // Cập nhật thông tin thành viên
            public bool CapNhatThanhVien(MemberDTO member)
            {
                return dal.CapNhatThanhVien(member);
            }
        }
    }
