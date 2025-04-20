using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.DAL
{
    public class BaseDAL
    {
        private MySqlConnection connection;
        //private string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=root;SslMode=none;";
        string connectionString = "server=localhost;port=3306;user=root;password=;database=librarydb;SslMode=none;";
        public BaseDAL()
        {
            connection = new MySqlConnection(connectionString);
        }


        public void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở kết nối! Lỗi: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("🔒 Đã đóng kết nối MySQL.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi đóng kết nối MySQL: " + ex.Message);
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}