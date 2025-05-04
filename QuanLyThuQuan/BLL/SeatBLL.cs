using MySql.Data.MySqlClient;
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace QuanLyThuQuan.BLL
{
    class SeatBLL
    {
        private SeatDAL seatDAL;

        public SeatBLL()
        {
            seatDAL = new SeatDAL();
        }

        public string create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Vui lòng nhập tên chỗ! ";
            }
            //if (!Regex.IsMatch(name, @"^[A-Za-z0-9]+$"))
            //{
            //    return "Ten cho chi gom chu cai va so, vui long nhap lai!";
            //}
            if (seatDAL.checkName(name) == true)
            {
                return ("Tên chỗ đã tồn tại, vui lòng nhập lại!");
            }
            SeatDTO seat = new SeatDTO { seatName = name };
            
            if (seatDAL.create(seat))
            {
                return null;
            }
            return "Lỗi MySQL!";
        }

        public string update(int seatId, string newSeatName)
        {
            SeatDTO seat = seatDAL.getById(seatId);

            if (string.IsNullOrWhiteSpace(newSeatName))
            {
                return "Vui lòng nhập tên chỗ! ";
            }
            //if (!Regex.IsMatch(newSeatName, @"^[A-Za-z0-9]+$"))
            //{
            //    return "Ten cho chi gom chu cai va so, vui long nhap lai!";
            //}
            if (!newSeatName.Equals(seat.seatName, StringComparison.OrdinalIgnoreCase))
            {
                if (seatDAL.checkName(newSeatName) == true)
                {
                    return ("Tên chỗ đã tồn tại, vui lòng nhập lại!");
                }
            }

            seat.seatName = newSeatName;
            if (seatDAL.update(seat)) {
                return null;
            }
            return "Lỗi MySQL!";
        }

        public string delete(int seatId)
        {
            SeatDTO seat = seatDAL.getById(seatId);

            if (seatDAL.delete(seat.seatId))
            {
                return null;
            }
            return "Lỗi MySQL!!";
        }

        public List<SeatDTO> getAllSeat()
        {
            return seatDAL.getAll();
        }

        public SeatDTO getById(int id)
        {
            return (seatDAL.getById(id));
        }

        public SeatDTO getByName(String name)
        {
            return seatDAL.getByName(name);
        }

        public bool checkName(String name)
        {
            return seatDAL.checkName(name);
        }


    }
}