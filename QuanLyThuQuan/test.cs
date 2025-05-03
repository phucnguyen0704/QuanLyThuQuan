using MySql.Data.MySqlClient;
using QuanLyThuQuan.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan
{
    public partial class test : Form
    {
        string connectionString = "Server=localhost;port=3308;Database=LibraryDB;Uid=root;Pwd=123456;SslMode=none;";
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("✅ Kết nối MySQL thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Kết nối thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            try
            {
                connect.Close();
                MessageBox.Show("Dong ket noi thanh cong!");
            }
            catch (Exception ex) { 
                Console.WriteLine("Loi: "+ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SeatBLL seatBLL = new SeatBLL();
            string name = txtSeatName.Text;
            string error = seatBLL.create(name);
            if (error != null)
            {
                MessageBox.Show(error);
            }
            else {
                MessageBox.Show("Them thanh cong!");
            }
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
