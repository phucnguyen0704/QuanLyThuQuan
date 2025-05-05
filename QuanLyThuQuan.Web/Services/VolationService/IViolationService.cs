using QuanLyThuQuan.Web.DTO;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Services.VolationService;

public interface IViolationService
{
    Task<Response<List<Violation>>> GetViolations(string memberId);
}
