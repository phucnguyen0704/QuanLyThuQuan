using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.BLL
{
    public class ViolationBLL : BaseBLL<ViolationBLL>
    {
        private ViolationDAL violationDAL;

        public ViolationBLL() : base()
        {
            violationDAL = new ViolationDAL();
        }

        public bool Create(ViolationDTO violation)
        {
            return violationDAL.Create(violation);
        }

        public bool Update(ViolationDTO violation)
        {
            return violationDAL.Update(violation);
        }

        public bool Delete(int id)
        {
            return violationDAL.Delete(id);
        }

        public List<ViolationDTO> GetAll()
        {
            return violationDAL.GetAll();
        }

        public ViolationDTO GetById(int id)
        {
            return violationDAL.GetById(id);
        }

        public List<ViolationDTO> GetByMemberId(uint memberId)
        {
            return violationDAL.GetByMemberId(memberId);
        }

        public List<ViolationDTO> GetByMemberIdLikeAndOptionalStatus(string partialMemberId, int? status) {
            return violationDAL.GetByMemberIdLikeAndOptionalStatus(partialMemberId, status);
        }
    }
}
