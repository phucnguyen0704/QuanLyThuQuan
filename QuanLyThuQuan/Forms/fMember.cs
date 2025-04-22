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
using ClosedXML.Excel;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
namespace QuanLyThuQuan
{
    public partial class fMember : Form
    {
        private List<Member> members = new List<Member>();
        private const string filePath = "members.csv";
        private string connectionString = "Server=localhost;Database=LibraryDB;Uid=root;Pwd= ;";

        public fMember()
        {
            InitializeComponent();
            LoadMembersFromMySQL();
            LoadRoles();
            LoadStatuses();
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.ReadOnly = true;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.CellClick += dgvMembers_CellClick;
        }

        private void fMember_Load(object sender, EventArgs e)
        {
            // Dữ liệu sẽ được load trong constructor
            // Thêm các giá trị vào cboKhoa
            cboKhoa.Items.Add("Khoa Công nghệ thông tin");
            cboKhoa.Items.Add("Khoa Điện tử - Viễn thông");
            cboKhoa.Items.Add("Khoa Cơ khí");
            cboKhoa.Items.Add("Khoa Kinh tế");

            // Thêm các giá trị vào cboNganh
            cboNganh.Items.Add("Ngành Phần mềm");
            cboNganh.Items.Add("Ngành Mạng máy tính");
            cboNganh.Items.Add("Ngành Điện tử");
            cboNganh.Items.Add("Ngành Kinh tế");

            // Thêm các giá trị vào cboLop
            cboLop.Items.Add("Lớp 1");
            cboLop.Items.Add("Lớp 2");
            cboLop.Items.Add("Lớp 3");

            // Thêm các giá trị vào cboGioiTinh
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");

            // Chọn giá trị mặc định cho các ComboBox
            cboKhoa.SelectedIndex = 0;
            cboNganh.SelectedIndex = 0;
            cboLop.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
        }

        private void LoadRoles()
        {
            cboVaiTro.Items.AddRange(new string[] { "member", "admin" });
        }

        private void LoadStatuses()
        {
            cboTrangThai.Items.AddRange(new string[] { "1", "2", "3" });
        }

        private void LoadMembersFromMySQL()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT member_id, full_name, birthday, phone_number, email, department, major, class, password, role, status FROM member";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable memberTable = new DataTable();
                            adapter.Fill(memberTable);
                            dgvMembers.DataSource = memberTable;

                            dgvMembers.Columns["member_id"].HeaderText = "ID";
                            dgvMembers.Columns["full_name"].HeaderText = "Họ và tên";
                            dgvMembers.Columns["birthday"].HeaderText = "Ngày sinh";
                            dgvMembers.Columns["phone_number"].HeaderText = "Điện thoại";
                            dgvMembers.Columns["email"].HeaderText = "Email";
                            dgvMembers.Columns["department"].HeaderText = "Khoa";
                            dgvMembers.Columns["major"].HeaderText = "Chuyên ngành";
                            dgvMembers.Columns["class"].HeaderText = "Lớp";
                            dgvMembers.Columns["role"].HeaderText = "Vai trò";
                            dgvMembers.Columns["status"].HeaderText = "Trạng thái";
                            dgvMembers.Columns["sex"].HeaderText = "Giới tính";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn MySQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMemberToMySQL()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO member (member_id, full_name, birthday, phone_number, email, department, major, class, password, role, status) " +
                                   "VALUES (@member_id, @full_name, @birthday, @phone_number, @email, @department, @major, @class, @password, @role, @status)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@member_id", txtMemberId.Text);
                        command.Parameters.AddWithValue("@full_name", txtHoVaTen.Text);
                        command.Parameters.AddWithValue("@birthday", dtpBirthday.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@phone_number", txtDangNhap.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@department", "");
                        command.Parameters.AddWithValue("@major", "");
                        command.Parameters.AddWithValue("@class", "");
                        command.Parameters.AddWithValue("@password", txtMatKhau.Text);
                        command.Parameters.AddWithValue("@role", cboVaiTro.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@status", cboTrangThai.SelectedItem?.ToString());

                        command.ExecuteNonQuery();
                        MessageBox.Show("Dữ liệu đã được lưu vào MySQL.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMembersFromMySQL();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu vào MySQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text) || string.IsNullOrWhiteSpace(txtDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cboVaiTro.SelectedItem == null || cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveMemberToMySQL();
            ClearInputFields();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearInputFields()
        {
            txtMemberId.Text = "";
            txtHoVaTen.Text = "";
            dtpBirthday.Value = DateTime.Now;
            txtDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtEmail.Text = "";
            dtpNgayDangKy.Value = DateTime.Now;
            cboVaiTro.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = (dgvMembers.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                txtMemberId.Text = row["member_id"].ToString();
                txtHoVaTen.Text = row["full_name"].ToString();
                dtpBirthday.Value = (DateTime)row["birthday"];
                txtDangNhap.Text = row["phone_number"].ToString();
                txtMatKhau.Text = row["password"].ToString();
                txtEmail.Text = row["email"].ToString();
                cboVaiTro.SelectedItem = row["role"].ToString();
                cboTrangThai.SelectedItem = row["status"].ToString();
                dtpNgayDangKy.Value = DateTime.Now;
            }
        }

        

        private void btnXuatExcel_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Chọn nơi lưu file Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        DataTable dt = (dgvMembers.DataSource as DataTable)?.Copy();
                        if (dt != null)
                        {
                            workbook.Worksheets.Add(dt, "Members");
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                }
            }
        }


        public class Member
        {
            public string MemberId { get; set; }
            public string HoVaTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public string DangNhap { get; set; }
            public string MatKhau { get; set; }
            public string Email { get; set; }
            public DateTime NgayDangKy { get; set; }
            public string VaiTro { get; set; }
            public string TrangThai { get; set; }
        }

        private void txtHoVaTen_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm/lọc dữ liệu nếu cần
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheets.First();
                        var dataTable = new DataTable();

                        bool firstRow = true;
                        foreach (var row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                // Thêm tiêu đề cột
                                foreach (var cell in row.Cells())
                                    dataTable.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else
                            {
                                dataTable.Rows.Add();
                                int i = 0;
                                foreach (var cell in row.Cells())
                                    dataTable.Rows[dataTable.Rows.Count - 1][i++] = cell.Value.ToString();
                            }
                        }

                        dgvMembers.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message);
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string memberId = txtMemberId.Text.Trim();
            string hoVaTen = txtHoVaTen.Text.Trim();
            DateTime ngaySinh = dtpBirthday.Value;
            string dangNhap = txtDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime ngayDangKy = dtpNgayDangKy.Value;
            string vaiTro = cboVaiTro.SelectedItem?.ToString();
            string trangThai = cboTrangThai.SelectedItem?.ToString();

            // Thêm các trường mới
            string khoa = cboKhoa.SelectedItem?.ToString();
            string nganh = cboNganh.SelectedItem?.ToString();
            string lop = cboLop.SelectedItem?.ToString();
            string gioiTinh = cboGioiTinh.SelectedItem?.ToString();

            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(hoVaTen) ||
                string.IsNullOrWhiteSpace(dangNhap) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrEmpty(vaiTro) ||
                string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO member (member_id, full_name, birthday, phone_number, email, department, major, class, password, role, status, gender, register_date) " +
                                   "VALUES (@member_id, @full_name, @birthday, @phone_number, @email, @department, @major, @class, @password, @role, @status, @gender, @register_date)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@member_id", memberId);
                        command.Parameters.AddWithValue("@full_name", hoVaTen);
                        command.Parameters.AddWithValue("@birthday", ngaySinh.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@phone_number", dangNhap);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@department", khoa);
                        command.Parameters.AddWithValue("@major", nganh);
                        command.Parameters.AddWithValue("@class", lop);
                        command.Parameters.AddWithValue("@password", matKhau);
                        command.Parameters.AddWithValue("@role", vaiTro);
                        command.Parameters.AddWithValue("@status", trangThai);
                        command.Parameters.AddWithValue("@gender", gioiTinh);
                        command.Parameters.AddWithValue("@register_date", ngayDangKy.ToString("yyyy-MM-dd"));

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Lưu thành viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembersFromMySQL();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DanhSachThanhVien");

                    // Header
                    for (int i = 0; i < dgvMembers.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgvMembers.Columns[i].HeaderText;
                    }

                    // Data
                    for (int i = 0; i < dgvMembers.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvMembers.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dgvMembers.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Excel Workbook|*.xlsx";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(save.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }


    }
}
