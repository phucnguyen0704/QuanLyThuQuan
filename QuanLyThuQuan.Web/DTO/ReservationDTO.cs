using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.DTO
{
    public class ReservationDTO
    {
        public Reservation Reservation { get; set; }
        public List<ReservationDetail> ReservationDetails { get; set; }
    }
}
