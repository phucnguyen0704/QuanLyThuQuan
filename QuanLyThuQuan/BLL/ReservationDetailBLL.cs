using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.BLL
{
    class ReservationDetailBLL
    {
        private ReservationDetailDAL reservationDetailDAL;

        public ReservationDetailBLL()
        {
            reservationDetailDAL = new ReservationDetailDAL();
        }

        public bool create(ReservationDetailDTO reservationDetail)
        {
            return reservationDetailDAL.create(reservationDetail);
        }

        public bool update(ReservationDetailDTO reservationDetail)
        {
            return reservationDetailDAL.update(reservationDetail);
        }

        public bool delete(int reservationDetailId)
        {
            return reservationDetailDAL.delete(reservationDetailId);
        }

        public List<ReservationDetailDTO> getAll()
        {
            return reservationDetailDAL.getAll();
        }

        public ReservationDetailDTO getByID(int reservationDetailID)
        {
            return reservationDetailDAL.getByID(reservationDetailID);
        }
    }
}
