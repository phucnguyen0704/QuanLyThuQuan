using QuanLyThuQuan.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.BLL
{
    internal class StatisticalBLL
    {
        private StatisticalsDAL statisticalsDAL;

        public StatisticalBLL()
        {
            statisticalsDAL = new StatisticalsDAL();
        }

        public DataTable getMemberStatisticals()
        {
            return statisticalsDAL.CountMembersWithStatus();
        }

        public int getDeviceStatisticals()
        {
            return statisticalsDAL.CountDevicesWithStatus();
        }

        public DataTable getReservationStatisticals() { 
            return statisticalsDAL.CountReservationWithStatus();
        }

        public DataTable getSeatStatisticals()
        {
            return statisticalsDAL.CountSeatWithStatus();
        }
    }
}
