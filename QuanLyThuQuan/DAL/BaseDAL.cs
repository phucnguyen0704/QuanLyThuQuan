﻿using MySql.Data.MySqlClient;
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

        public BaseDAL()
        {
            string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;SslMode=none;";
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