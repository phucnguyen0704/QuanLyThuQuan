using MySqlConnector;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.SeatService
{
    public class SeatService : ISeatService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SeatService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Response<List<Seat>>> GetAllSeats()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Seat WHERE status != 2";
                using (var command = new MySqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = command.ExecuteReader())
                    {
                        var seats = new List<Seat>();
                        while (await reader.ReadAsync())
                        {
                            var seat = new Seat
                            {
                                SeatId = reader.GetUInt32("seat_id"),
                                Name = reader.GetString("name"),
                                Status = reader.GetSByte("status")
                            };
                            seats.Add(seat);
                        }
                        return new Response<List<Seat>>
                        {
                            Data = seats,
                            Message = "Seats retrieved successfully",
                            Success = true
                        };
                    }

                }
            }
        }
    }
}
