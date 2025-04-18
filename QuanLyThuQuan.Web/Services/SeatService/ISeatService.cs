using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.SeatService
{
    public interface ISeatService
    {
        public Task<Response<List<Seat>>> GetAllSeats();
    }
}
