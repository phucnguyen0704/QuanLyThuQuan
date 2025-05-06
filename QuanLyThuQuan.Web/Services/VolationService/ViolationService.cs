using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using QuanLyThuQuan.Web.Data;
using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.VolationService;

public class ViolationService : IViolationService
{
    private readonly AppDbContext _db;

    public ViolationService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Response<List<Violation>>> GetViolations(string memberId)
    {
        Response<List<Violation>> response = new();
        response.Data = new List<Violation>();
        try
        {
            var listViolation =await _db.Violations.Where(v => v.MemberId.ToString()!.Equals(memberId))
                .Include(v => v.Member)
                .Include(v => v.Regulation)
                .Include(v => v.Reservation)
                .ToListAsync();
            response.Success = true;
            response.Data = listViolation.Count > 0 ? listViolation : new List<Violation>();
        }
        catch (MySqlException e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        return response;
    }
}
