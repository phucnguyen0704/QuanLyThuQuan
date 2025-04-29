using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.BLL
{
    class ReservationBLL
    {
        private ReservationDAL reservationDAL;

        public ReservationBLL()
        {
            reservationDAL = new ReservationDAL();
        }

        public bool create(ReservationDTO reservation)
        {
            return reservationDAL.create(reservation);
        }

        public bool update(ReservationDTO reservation)
        {
            return reservationDAL.update(reservation);
        }

        public bool updateReturnTime(ReservationDTO reservation)
        {
            switch (reservation.Status)
            {
                case 1: // đang mượn
                    reservation.ReturnTime = null; 
                    break;
                default: // đã trả hoặc vi phạm
                    reservation.ReturnTime = DateTime.Now;
                    break;
            }
            return reservationDAL.update(reservation);
        }


        public bool updateStatus(ReservationDTO reservation, int status)
        {
            if (reservation.ReturnTime < reservation.DueTime)
            {
                reservation.Status = 3; // Vi phạm
            } else {
                reservation.Status = status;
            }
            return reservationDAL.update(reservation);
        }

        public bool delete(int reservationId)
        {
            return reservationDAL.delete(reservationId);
        }

        public List<ReservationDTO> getAll()
        {
            return reservationDAL.getAll();
        }

        public ReservationDTO getByID(int reservationID)
        {
            return reservationDAL.getByID(reservationID);
        }
    }
}
