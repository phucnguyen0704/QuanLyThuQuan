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
        public int Status { get; set; }

        public ReservationDetailDTO()
        {
            ReservationDetailID = 0;
            ReservationID = 0;
            DeviceID = 0;
            Status = 0;
        }

        public ReservationDetailDTO(int reservationDetailID, int reservationID, int deviceID, int status)
        {
            ReservationDetailID = reservationDetailID;
            ReservationID = reservationID;
            DeviceID = deviceID;
            Status = status;
        }

        public ReservationDetailDTO(int reservationID, int deviceID, int status)
        {
            ReservationDetailID = 0;
            ReservationID = reservationID;
            DeviceID = deviceID;
            Status = status;
        }

        public override string ToString()
        {
            return $"ID: {ReservationDetailID}, ReservationID: {ReservationID}, DeviceID: {DeviceID}, Status: {Status}";
        }
    }
}
