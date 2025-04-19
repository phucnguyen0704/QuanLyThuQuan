using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.DeviceService
{
    public interface IDeviceService
    {
        Task<Response<List<Device>>> GetAllAvailable();

    }
}
