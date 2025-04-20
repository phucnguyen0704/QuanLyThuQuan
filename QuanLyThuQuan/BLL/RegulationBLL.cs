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

        public bool Delete(int regulationID)
        {
            return regulationDAL.Delete(regulationID);
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
