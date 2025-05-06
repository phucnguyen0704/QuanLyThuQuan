using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;

namespace QuanLyThuQuan.BLL
{
    public class RegulationBLL : BaseBLL<RegulationBLL>
    {
        private RegulationDAL regulationDAL;

        public RegulationBLL()
        {
            regulationDAL = new RegulationDAL();
        }

        public bool Create(RegulationDTO regulation)
        {
            return regulationDAL.Create(regulation);
        }

        public bool Update(RegulationDTO regulation)
        {
            return regulationDAL.Update(regulation);
        }

        public bool Delete(int regulationID, out string errorMessage)
        {
            try
            {
                bool result = regulationDAL.Delete(regulationID);
                errorMessage = result ? null : "Không thể xóa quy định. Lý do không xác định.";
                return result;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                // 1451 - Mã lỗi ràng buộc khóa ngoại của MySQL
                if (ex.Number == 1451)
                {
                    errorMessage = "Không thể xóa quy định vì đã được áp dụng trong vi phạm.";
                }
                else
                {
                    errorMessage = "Lỗi cơ sở dữ liệu: " + ex.Message;
                }
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi hệ thống: " + ex.Message;
                return false;
            }
        }

        public List<RegulationDTO> GetAll()
        {
            return regulationDAL.GetAll();
        }

        public RegulationDTO GetById(int regulationID)
        {
            return regulationDAL.GetById(regulationID);
        }

        public List<RegulationDTO> GetByName(string name)
        {
            return regulationDAL.GetByName(name);
        }
    }
}
