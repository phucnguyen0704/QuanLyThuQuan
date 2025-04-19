using MySql.Data.MySqlClient;
using System;

namespace QuanLyThuQuan.DAL
{
    class BaseDAL
    {
        private MySqlConnection connection;

        public BaseDAL()
        {
            string connectionString = @"
                Server=localhost;
                Port=3306;
                Database=librarydb;
                User ID=root;
                Password=root;
                Charset=utf8mb4;
            ";
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("✅ Đã kết nối MySQL thành công.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi mở kết nối MySQL: " + ex.Message);
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

        public void createTable() { }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
