using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.BookingService
{
    public interface IBookingService
    {
        Task<Response<List<ReservationDTO>>> GetMemberBookings(long memberId);

        Task<Response<ReservationDTO>> CreateBooking(ReservationDTO reservationDTO, List<uint> deviceIds);

        Task<Response<List<ReservationDetail>>> GetReservationDetails(int reservationId);

        
    }
}
