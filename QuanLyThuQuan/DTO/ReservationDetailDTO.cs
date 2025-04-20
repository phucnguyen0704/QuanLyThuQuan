using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    class ReservationDetailDTO
    {
        public int ReservationDetailID { get; set; }
        public int ReservationID { get; set; }
        public int DeviceID { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Status { get; set; }

        public ReservationDetailDTO()
        {
            ReservationDetailID = 0;
            ReservationID = 0;
            DeviceID = 0;
            BorrowTime = DateTime.Now;
            DueTime = DateTime.Now;
            ReturnTime = DateTime.Now;
            Status = 0;
        }

        public ReservationDetailDTO(int reservationDetailID, int reservationID, int deviceID, DateTime borrowTime, DateTime dueTime, DateTime returnTime, int status)
        {
            ReservationDetailID = reservationDetailID;
            ReservationID = reservationID;
            DeviceID = deviceID;
            BorrowTime = borrowTime;
            DueTime = dueTime;
            ReturnTime = returnTime;
            Status = status;
        }

        public override string ToString()
        {
            return $"ID: {ReservationDetailID}, ReservationID: {ReservationID}, DeviceID: {DeviceID}, BorrowTime: {BorrowTime}, DueTime: {DueTime}, ReturnTime: {ReturnTime}, Status: {Status}";
        }
    }
}
