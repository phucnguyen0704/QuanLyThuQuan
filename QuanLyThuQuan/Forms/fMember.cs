using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        private string connectionString = "Server=localhost;Database=LibraryDB;Uid=root;Pwd= ;";

        public fMember()
        {
            InitializeComponent();
            LoadMembersFromMySQL();
            LoadRoles();
            LoadStatuses();
            LoadDepartments();
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.ReadOnly = true;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.CellClick += dgvMembers_CellClick;
        }

        private void fMember_Load(object sender, EventArgs e)
        {
            // Dữ liệu sẽ được load trong constructor
            LoadComboBoxes();
        }

        private void LoadRoles()
        {
            cboVaiTro.Items.AddRange(new string[] { "member", "admin" });
        }

        private void LoadStatuses()
        {
            cboTrangThai.Items.AddRange(new string[] { "1", "2", "3" });
        }

        private void LoadDepartments()
        {
            cbKhoa.Items.AddRange(new string[] { "Khoa Công nghệ thông tin", "Khoa Điện tử - Viễn thông", "Khoa Cơ khí", "Khoa Kinh tế" });
        }

        private void LoadComboBoxes()
        {
            cboNganh.Items.AddRange(new string[] { "Ngành Phần mềm", "Ngành Mạng máy tính", "Ngành Điện tử", "Ngành Kinh tế" });
            cboLop.Items.AddRange(new string[] { "Lớp 1", "Lớp 2", "Lớp 3" });

            // Đặt giá trị mặc định
            cbKhoa.SelectedIndex = 0;
            cboNganh.SelectedIndex = 0;
            cboLop.SelectedIndex = 0;
            cboVaiTro.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
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

                            // Đổi tên cột trong DataGridView
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
                        // Gán giá trị cho các tham số
                        command.Parameters.AddWithValue("@member_id", txtMemberId.Text);
                        command.Parameters.AddWithValue("@full_name", txtHoVaTen.Text);
                        command.Parameters.AddWithValue("@birthday", dtpBirthday.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@phone_number", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@department", cbKhoa.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@major", cboNganh.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@class", cboLop.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@password", txtMatKhau.Text);
                        command.Parameters.AddWithValue("@role", cboVaiTro.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@status", cboTrangThai.SelectedItem?.ToString());

                        command.ExecuteNonQuery();
                        MessageBox.Show("Dữ liệu đã được lưu vào MySQL.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMembersFromMySQL();  // Cập nhật lại danh sách thành viên
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL: " + ex.Message + "\n" + ex.Number);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chung: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cboVaiTro.SelectedItem == null || cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveMemberToMySQL();
            ClearInputFields();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearInputFields()
        {
            txtMemberId.Clear();
            txtHoVaTen.Clear();
            dtpBirthday.Value = DateTime.Now;
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            cboVaiTro.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            cbKhoa.SelectedIndex = 0;
            cboNganh.SelectedIndex = 0;
            cboLop.SelectedIndex = 0;
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = (dgvMembers.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                txtMemberId.Text = row["member_id"].ToString();
                txtHoVaTen.Text = row["full_name"].ToString();
                dtpBirthday.Value = (DateTime)row["birthday"];
                txtPhoneNumber.Text = row["phone_number"].ToString();
                txtPhoneNumber.Text = row["password"].ToString();
                txtEmail.Text = row["email"].ToString();
                cboVaiTro.SelectedItem = row["role"].ToString();
                cboTrangThai.SelectedItem = row["status"].ToString();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
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

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (var workbook = new XLWorkbook(filePath))
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

        private void cboVaiTro_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cboTrangThai_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
