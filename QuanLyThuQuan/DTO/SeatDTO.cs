using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    public class SeatDTO
    {
        public int seatId { get; set; }
        public string seatName { get; set; }
        public int status { get; set; }

        public SeatDTO()
        {
            seatId = 0;
            seatName = string.Empty;
            status = 1;
        }

        public SeatDTO(int seatId, string seatName, int status)
        {
            this.seatId = seatId;
            this.seatName = seatName;
            this.status = status;
        }

        public override string ToString()
        {
            return $"SeatID: {seatId}, Seat name: {seatName}, status: {status}";
        }
    }
}
