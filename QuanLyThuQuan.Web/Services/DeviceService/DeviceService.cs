using MySqlConnector;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.DeviceService
{
    public class DeviceService : IDeviceService
    {
        private string _connectionString;

        public DeviceService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Response<List<Device>>> GetAllAvailable()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var query = "SELECT * FROM device WHERE status =1";
                using (var command = new MySqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = command.ExecuteReader())
                    {
                        var devices = new List<Device>();
                        while (reader.Read())
                        {
                            devices.Add(new Device
                            {
                                DeviceId = reader.GetUInt32("device_id"),
                                Name = reader.GetString("name"),
                                Image = reader.GetString("image"),
                                Status = reader.GetSByte("status")
                            });
                        }
                        return new Response<List<Device>>
                        {
                            Data = devices,
                            Success = true,
                            Message = "Lấy danh sách thành công"
                        };
                    }
                }
            }
        }
    }
}
