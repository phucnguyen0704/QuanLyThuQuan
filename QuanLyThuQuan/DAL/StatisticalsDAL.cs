using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.DAL
{
    public class StatisticalsDAL : BaseDAL
    {
        public StatisticalsDAL() : base() { }
        
        public DataTable CountMembersWithStatus()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT status, COUNT(*) as count FROM member GROUP BY status";
                MySqlCommand cmd = new MySqlCommand(sql, GetConnection());
                OpenConnection();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public int CountDevicesWithStatus()
        {
            int count = 0;
            try
            {
                string sql = "SELECT COUNT(*) FROM device WHERE status = 1";

                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                OpenConnection();
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tổng số thành viên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return count;
        }

        public DataTable CountReservationWithStatus()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT status, COUNT(*) as count FROM reservation GROUP BY status";
                MySqlCommand cmd = new MySqlCommand(sql, GetConnection());
                OpenConnection();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public DataTable CountSeatWithStatus()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT status, COUNT(*) as count FROM seat GROUP BY status";
                MySqlCommand cmd = new MySqlCommand(sql, GetConnection());
                OpenConnection();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}
