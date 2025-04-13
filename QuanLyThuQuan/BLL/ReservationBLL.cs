using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
