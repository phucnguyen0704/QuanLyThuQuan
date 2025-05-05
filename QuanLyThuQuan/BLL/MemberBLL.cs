using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using QuanLyThuQuan.Utils;
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
            member.Password = SecurityCoder.Encrypt(member.Password);
            return memberDAL.create(member);
        }

        public bool update(MemberDTO member)
        {
            return memberDAL.update(member);
        }

        public bool delete(uint memberId)
        {
            return memberDAL.delete(memberId);
        }

        public List<MemberDTO> getAll()
        {
            return memberDAL.getAll();
        }

        public int checkLogin(uint memberId, string password, string role)
        {
            MemberDTO member = memberDAL.getByID(memberId);
            if (member != null)
            {
                bool resultOfCheckPass = SecurityCoder.Verify(password, member.Password);
                if (member.MemberId == memberId && resultOfCheckPass && member.Role == role)
                {
                    return 1; // đăng nhập thành công
                }
                else if (member.MemberId == memberId && !resultOfCheckPass)
                {
                    return 2; // đúng ID, sai mật khẩu
                }
                else if (member.MemberId == memberId && resultOfCheckPass && member.Role != role)
                {
                    return 3; // đúng ID, đúng mật khẩu, sai quyền hạn
                }
            }
            return 4; // không tìm thấy ID
        }

        public bool changePassword(uint memberId, string newPassword)
        {
            MemberDTO member = memberDAL.getByID(memberId);
            if (member != null)
            {
                member.Password = SecurityCoder.Encrypt(newPassword);
                return memberDAL.update(member);
            }
            return false; // không tìm thấy ID
        }

        public MemberDTO getByID(uint memberId)
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

        public DataTable getReservationHistory(uint memberId)
        {
            return memberDAL.getReservationHistory(memberId);
        }

        public DataTable getReservationDetails(uint memberId)
        {
            return memberDAL.getReservationDetails(memberId);
        }

        public DataTable getViolationHistory(uint memberId)
        {
            return memberDAL.getViolationHistory(memberId);
        }

        public DataTable getCheckInHistory(uint memberId)
        {
            return memberDAL.getCheckInHistory(memberId);
        }
    }
}
