using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    class ReservationDTO
    {
        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public int SeatID { get; set; }
        public int ReservationType { get; set; }
        public DateTime ReservationTime { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public ReservationDTO()
        {
            ReservationID = 0;
            MemberID = 0;
            SeatID = 0;
            ReservationType = 0;
            ReservationTime = DateTime.Now;
            DueTime = DateTime.Now;
            ReturnTime = DateTime.Now;
            Status = 0;
            CreatedAt = DateTime.Now;
        }

        public ReservationDTO(int reservationID, int memberID, int seatID, int reservationType, DateTime reservationTime, DateTime dueTime, DateTime returnTime, int status, DateTime createdAt)
        {
            ReservationID = reservationID;
            MemberID = memberID;
            SeatID = seatID;
            ReservationType = reservationType;
            ReservationTime = reservationTime;
            DueTime = dueTime;
            ReturnTime = returnTime;
            Status = status;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"ID: {ReservationID}, UserID: {MemberID}, SeatID: {SeatID}, ReservationType: {ReservationType}, ReservationTime: {ReservationTime}, DueTime: {DueTime}, ReturnTime: {ReturnTime}, Status: {Status}, CreatedAt: {CreatedAt}";
        }
    }
}
