
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyThuQuan.BLL
{
    class LogBLL
    {
        private LogDAL logDAL;

        public LogBLL()
        {
            logDAL = new LogDAL();
        }

        public string create(string memberId, DateTime checkin)
        {
            if (string.IsNullOrWhiteSpace(memberId))
            {
                return "Vui lòng nhập mã sinh viên! ";
            }
            //if (!Regex.IsMatch(memberId, @"^[A-Za-z0-9\s]+$"))
            //{
            //    return "Mã sinh viên chỉ bao gồm chữ cái và số, vui lòng nhập lại!";
            //}
            if (checkin == null)
            {
                return "Vui lòng chọn thời gian vào thư quán!";
            }
            
            LogDTO logDTO = new LogDTO() { memberId = memberId, checkinTime = checkin };
            if (logDAL.create(logDTO)){
                return null;
            }
            return "Lỗi MySQL!";
        }

        public string update(int logId, string memberid, DateTime checkin)
        {
            LogDTO log = logDAL.getById(logId);

            if (string.IsNullOrWhiteSpace(memberid))
            {
                return "Vui lòng nhập tên mã sinh viên! ";
            }
            if (!Regex.IsMatch(memberid, @"^[A-Za-z0-9\s]+$"))
            {
                return "Mã sinh viên chỉ bao gồm chữ cái và số, vui lòng nhập lại!";
            }
            if (checkin == null)
            {
                return "Vui lòng chọn thời gian vào thư quán!";
            }

            log.memberId = memberid;
            log.checkinTime = checkin;
            if (logDAL.update(log))
            {
                return null;
            }
            return "Lỗi MySQL!";
        }

        public string delete(int logId)
        {
            LogDTO log = logDAL.getById(logId);
            if (logDAL.delete(log.logId))
            {
                return null;
            }
            return "Lỗi MySQL!";
        }
    }
}
