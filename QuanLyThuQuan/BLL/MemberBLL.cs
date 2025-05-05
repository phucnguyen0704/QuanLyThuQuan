using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuQuan.BLL
{
    class MemberBLL
    {
        private MemberDAL memberDAL;

        public MemberBLL()
        {
            memberDAL = new MemberDAL();
        }

        public bool create(MemberDTO member)
        {
            return memberDAL.create(member);
        }

        public bool update(MemberDTO member)
        {
            return memberDAL.update(member);
        }

        public bool delete(int memberId)
        {
            return memberDAL.delete(memberId);
        }

        public List<MemberDTO> getAll()
        {
            return memberDAL.getAll();
        }

        public int checkLogin(int memberId, string password, string role)
        {
            MemberDTO member = memberDAL.getByID(memberId);
            if (member != null)
            {
                if (member.MemberId == memberId && member.Password == password && member.Role == role)
                {
                    return 1; // đăng nhập thành công
                }
                else if (member.MemberId == memberId && member.Password != password)
                {
                    return 2; // đúng ID, sai mật khẩu
                }
                else if (member.MemberId == memberId && member.Password == password && member.Role != role)
                {
                    return 3; // đúng ID, đúng mật khẩu, sai quyền hạn
                }
            }
            return 4; // không tìm thấy ID
        }

        public MemberDTO getByID(int memberId)
        {
            return memberDAL.getByID(memberId);
        }

        public MemberDTO getByPhone(string memberPhone)
        {
            return memberDAL.getByPhone(memberPhone);
        }

        public MemberDTO getByEmail(string memberEmail)
        {
            return memberDAL.getByEmail(memberEmail);
        }

        public DataTable getReservationHistory(int memberId)
        {
            return memberDAL.getReservationHistory(memberId);
        }

        public DataTable getReservationDetails(int memberId)
        {
            return memberDAL.getReservationDetails(memberId);
        }

        public DataTable getViolationHistory(int memberId)
        {
            return memberDAL.getViolationHistory(memberId);
        }

        public DataTable getCheckInHistory(int memberId)
        {
            return memberDAL.getCheckInHistory(memberId);
        }
    }
}
