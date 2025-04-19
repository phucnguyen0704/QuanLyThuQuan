using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThanhVienMoi
{
    public partial class FormThemThanhVien : Form
    {
        public FormThemThanhVien()
        {
            InitializeComponent();
        }

        private void FormThemThanhVien_Load(object sender, EventArgs e)
        {
                
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayDangKi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
                
        }

        private void txtHoVaTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
         
            // Lấy dữ liệu từ các control nhập liệu
            string id = txtId.Text.Trim();
            string hoTen = txtHoVaTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime ngayDangKy = dtpNgayDangKi.Value;
            

            // Chuỗi kết nối đến cơ sở dữ liệu (nên lấy từ Form chính nếu có)
            string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";

            // Câu lệnh SQL INSERT
            string query = "INSERT INTO thanhvien (id, ho_ten, email, ngay_dang_ky) " +
                           "VALUES (@id, @hoTen, @email, @ngayDangKy)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Thêm các tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@hoTen", hoTen);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@ngayDangKy", ngayDangKy);
                       

                        // Thực thi câu lệnh INSERT
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm thành viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Bạn có thể đóng Form này sau khi thêm thành công
                            this.Close();

                            // Hoặc làm trống các ô nhập liệu để thêm tiếp
                            // txtID.Text = "";
                            // txtHoTen.Text = "";
                            // txtEmail.Text = "";
                            // dtpNgayDangKy.Value = DateTime.Now;
                            // txtDienThoai.Text = "";

                            // Gọi phương thức tải lại danh sách thành viên trên Form chính (nếu cần)
                            // ((Form1)this.Owner)?.LoadDanhSachThanhVien();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thành viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Lỗi MySQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
