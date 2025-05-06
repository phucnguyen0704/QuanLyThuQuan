using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    public class ViolationDTO
    {
        public int ViolationID { get; set; }
        public uint MemberID { get; set; }
        public int RegulationID { get; set; }
        public int? ReservationID { get; set; }
        public string Penalty { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DueTime { get; set; }
        public int Status { get; set; }

        public ViolationDTO() { }

        public ViolationDTO(uint memberID, int regulationID, int? reservationID, string penalty, DateTime? dueTime, int status)
        {
            MemberID = memberID;
            RegulationID = regulationID;
            ReservationID = reservationID;
            Penalty = penalty;
            DueTime = dueTime;
            Status = status;
        }

        public ViolationDTO(int violationID, uint memberID, int regulationID, int? reservationID, string penalty, DateTime? createdAt, DateTime? dueTime, int status)
        {
            ViolationID = violationID;
            MemberID = memberID;
            RegulationID = regulationID;
            ReservationID = reservationID;
            Penalty = penalty;
            CreatedAt = createdAt;
            DueTime = dueTime;
            Status = status;
        }

        public override string ToString()
        {
            return $"ViolationID: {ViolationID}, MemberID: {MemberID}, RegulationID: {RegulationID}, ReservationID: {ReservationID}, Penalty: {Penalty}, CreatedAt: {CreatedAt:dd-MM-yyyy}, DueTime: {DueTime:dd-MM-yyyy}, Status: {Status}";
        }
    }
}
