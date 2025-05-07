using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    public class LogDTO
    {
        public int logId { get; set; }
        public string memberId { get; set; }
        public DateTime checkinTime { get; set; }
        public int status { get; set; }
        public DateTime createdAt { get; set; }

        public LogDTO()
        {
            logId = 0;
            memberId = string.Empty;
            checkinTime = DateTime.MinValue;
            status = 0;
            createdAt = DateTime.MinValue;
        }

        public LogDTO(int logId, string memberId, DateTime checkinTime, int status, DateTime createdAt)
        {
            this.logId = logId;
            this.memberId = memberId;
            this.checkinTime = checkinTime;
            this.status = status;
            this.createdAt = createdAt;
        }

        public override string ToString()
        {
            return $"LogID: {logId}, MemberID: {memberId}, Check-in Time: {checkinTime}, Status: {status}, Created At: {createdAt}";
        }
    }
}