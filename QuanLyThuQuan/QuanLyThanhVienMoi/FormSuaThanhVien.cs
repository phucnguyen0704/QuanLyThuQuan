using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace QuanLyThanhVienMoi
{
    public partial class FormSuaThanhVien : Form
    {
        private string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";
        private string idThanhVien; // ID của thành viên cần sửa

        public FormSuaThanhVien(string id)
        {
            InitializeComponent();
            this.idThanhVien = id;
        }

        private void FormSuaThanhVien_Load(object sender, EventArgs e)
        {
            LoadThongTinThanhVien();
        }

        private void LoadThongTinThanhVien()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ho_ten, email, ngay_dang_ky FROM thanhvien WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", idThanhVien);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtHoVaTenSua.Text = reader["ho_ten"].ToString();
                                txtEmailSua.Text = reader["email"].ToString();
                                dtpNgayDangKiSua.Value = Convert.ToDateTime(reader["ngay_dang_ky"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string hoVaTen = txtHoVaTenSua.Text.Trim();
            string email = txtEmailSua.Text.Trim();
            DateTime ngayDangKy = dtpNgayDangKiSua.Value;

            if (string.IsNullOrEmpty(hoVaTen) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string connStr = "server=localhost;user id=root;password=;database=librarydb;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE thanhvien SET ho_ten=@hoTen, email=@email, ngay_dang_ky=@ngayDangKy WHERE id=@id;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hoTen", hoVaTen); // Sử dụng biến hoVaTen
                    cmd.Parameters.AddWithValue("@email", email);   // Sử dụng biến email
                    cmd.Parameters.AddWithValue("@ngayDangKy", ngayDangKy); // Sử dụng biến ngayDangKy
                    cmd.Parameters.AddWithValue("@id", idThanhVien); // Sử dụng biến idThanhVien

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Sửa thành công!", "Thông báo");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thành viên để sửa!", "Thông báo");
                    }
                }
            }

        
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
