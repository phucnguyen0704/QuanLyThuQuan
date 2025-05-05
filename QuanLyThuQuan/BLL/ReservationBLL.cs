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

            if (reservation.ReservationTime > reservation.DueTime || (reservation.ReservationType == 2 && reservation.SeatID == null))
            {
                return false;
            }
            return reservationDAL.create(reservation);
        }

        public bool update(ReservationDTO reservation)
        {
            if (reservation.DueTime < reservation.ReturnTime)
            {
                reservation.Status = 3; // Vi phạm 
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

        public List<ReservationDTO> getCurrentViolatedReservationsByMemberID(int memberID)
        {
            return reservationDAL.getCurrentViolatedReservationsByMemberID(memberID);
        }
    }
}
