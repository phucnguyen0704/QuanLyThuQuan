using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using QuanLyThuQuan.Web.Data;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _db;

        public BookingService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Response<ReservationDTO>> CreateBooking(ReservationDTO reservationDTO, List<uint> deviceIds)
        {
            Response<ReservationDTO> response = new();
            var user = await _db.Members.FirstOrDefaultAsync(m => m.MemberId == reservationDTO.Reservation.MemberId);
            if (user.Status == 3)
            {
                response.Success = false;
                response.Message = "Ohhh!No. Tài khoản của bạn đã bị khóa!Hẹn không gặp lại bạn!";
                response.Data = new ReservationDTO
                {
                    Reservation = new Reservation
                    {
                        Member = user
                    }
                };
                return response;

            }
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {

                    await _db.Reservations.AddAsync(reservationDTO.Reservation);
                    if (reservationDTO.Reservation.ReservationType == 1)
                    {
                        var seat = _db.Seats.FirstOrDefault(s => s.SeatId == reservationDTO.Reservation.SeatId);
                        if (seat != null)
                        {
                            seat.Status = 3; // Đã được đặt
                            _db.Seats.Update(seat);
                        }
                    }
                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        reservationDTO.ReservationDetails = deviceIds.Select(deviceId => new ReservationDetail
                        {
                            DeviceId = deviceId,
                            ReservationId = reservationDTO.Reservation.ReservationId
                        }).ToList();
                        List<Device> devices = await _db.Devices.Where(d => deviceIds.Contains(d.DeviceId)).ToListAsync();
                        foreach (var device in devices)
                        {
                            device.Status = 3;//Đã được đặt
                            _db.Devices.Update(device);
                        }
                        await _db.ReservationDetails.AddRangeAsync(reservationDTO.ReservationDetails);
                        result = await _db.SaveChangesAsync();
                        if (result > 0)
                        {
                            response.Success = true;
                            response.Message = "Đặt chỗ thành công";
                            response.Data = reservationDTO;
                            await transaction.CommitAsync();
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            response.Success = false;
                            response.Message = "Đặt chỗ thất bại";
                        }
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        response.Success = false;
                        response.Message = "Đặt chỗ thất bại";
                    }

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                    await transaction.RollbackAsync();
                }
            }
            return response;

        }

        public async Task<Response<List<ReservationDTO>>> GetMemberBookings(long memberId)
        {
            Response<List<ReservationDTO>> response = new();
            try
            {
                var listReservation = await _db.Reservations.Where(r => r.MemberId == memberId)
                                            .Include(r => r.Member)
                                            .Include(r => r.Seat)
                                            .Include(r => r.ReservationDetails)
                                            .ToListAsync();
                if (!listReservation.Any())
                {
                    response.Success = true;
                    response.Message = "Bạn chưa có lịch sử đặt mượn ở đây!";
                    response.Data = null;
                    return response;
                }
                response.Data = listReservation.Select(reservation => new ReservationDTO
                {
                    Reservation = reservation,
                    ReservationDetails = _db.ReservationDetails
                    .Where(d => d.ReservationId == reservation.ReservationId)
                    .Include(r => r.Device)
                    .ToList()
                }).ToList();

                response.Success = true;
                response.Message = "";
                return response;
            }
            catch (MySqlException mysqlex)
            {
                response.Success = false;
                response.Message = mysqlex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<ReservationDetail>>> GetReservationDetails(int reservationId)
        {
            Response<List<ReservationDetail>> response = new();
            try
            {
                response.Data = await _db.ReservationDetails
                    .Where(d => d.ReservationId == reservationId)
                    .Include(r => r.Device)
                    .ToListAsync();
                if(response.Data.Count == 0)
                {
                    response.Success = false;
                    response.Data = new List<ReservationDetail>();
                    response.Message = "Không tìm thấy dữ liệu";
                    return response;

                }
                response.Success = true;
                

            }
            catch (MySqlException mysqlex)
            {
                response.Success = false;
                response.Message = mysqlex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
