using MySql.Data.MySqlClient; // Thêm dòng này
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data; // Đảm bảo dòng này có
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLyThanhVienMoi
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;"; 
        private int trangHienTai = 1;
        private int soLuongTrenTrang = 10; // Số lượng thành viên hiển thị trên mỗi trang
        private int tongSoThanhVien = 0;
        private int tongSoTrang = 0;
        private void LoadTongSoThanhVien()
        {
            string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";
            string query = "SELECT COUNT(*) FROM thanhvien";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        tongSoThanhVien = Convert.ToInt32(command.ExecuteScalar());
                        tongSoTrang = (int)Math.Ceiling((double)tongSoThanhVien / soLuongTrenTrang);
                        lblPhanTrang.Text = $"Trang {trangHienTai}/{tongSoTrang}";
                        btnTrangTruoc.Enabled = (trangHienTai > 1);
                        btnTrangSau.Enabled = (trangHienTai < tongSoTrang);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi lấy tổng số thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachThanhVien(int trang)
        {
            string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";
            int offset = (trang - 1) * soLuongTrenTrang;
            string query = $"SELECT id, ho_ten, email, ngay_dang_ky FROM thanhvien LIMIT {soLuongTrenTrang} OFFSET {offset}";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi tải danh sách thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTongSoThanhVien();
            LoadDanhSachThanhVien(trangHienTai);
            // Các code tải dữ liệu khác (nếu có)
        }
        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
            {
                trangHienTai--;
                LoadDanhSachThanhVien(trangHienTai);
                lblPhanTrang.Text = $"Trang {trangHienTai}/{tongSoTrang}";
                btnTrangTruoc.Enabled = (trangHienTai > 1);
                btnTrangSau.Enabled = (trangHienTai < tongSoTrang);
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (trangHienTai < tongSoTrang)
            {
                trangHienTai++;
                LoadDanhSachThanhVien(trangHienTai);
                lblPhanTrang.Text = $"Trang {trangHienTai}/{tongSoTrang}";
                btnTrangTruoc.Enabled = (trangHienTai > 1);
                btnTrangSau.Enabled = (trangHienTai < tongSoTrang);
            }
        }
        public Form1()
        {


            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            InitializeComponent();

        }

        // ... các phương thức khác sẽ được thêm vào đây ...
        private void LoadDanhSachThanhVien()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {   //	ho_ten	email	ngay_dang_ky
                    connection.Open();
                    string query = "SELECT id, ho_ten, email, ngay_dang_ky FROM thanhvien";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
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
       
        private void btnThemmoi_Click(object sender, EventArgs e)
        {


            FormThemThanhVien formThem = new FormThemThanhVien();
            formThem.Owner = this; // Thiết lập Form cha (tùy chọn)
            formThem.ShowDialog(); // Hiển thị Form thêm thành viên theo kiểu Modal
                                   // Hoặc bạn có thể sử dụng formThem.Show(); để hiển thị không theo kiểu Modal
        }

        private void tsbtnThem_ButtonClick(object sender, EventArgs e)
        {

            FormThemThanhVien formThem = new FormThemThanhVien();
            formThem.Owner = this;
            formThem.ShowDialog();

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Lấy worksheet đầu tiên (index 0)

                        int rowCount = worksheet.Dimension.Rows;
                        int addedCount = 0;

                        string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            using (MySqlTransaction transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng thứ 2
                                    {
                                        string id = worksheet.Cells[row, 1].Value?.ToString().Trim(); // Cột A
                                        string hoTen = worksheet.Cells[row, 2].Value?.ToString().Trim(); // Cột B
                                        string email = worksheet.Cells[row, 3].Value?.ToString().Trim(); // Cột C
                                        DateTime ngayDangKy = DateTime.Now; // Giá trị mặc định nếu không đọc được hoặc null
                                        if (worksheet.Cells[row, 4].Value != null && DateTime.TryParse(worksheet.Cells[row, 4].Value.ToString(), out DateTime parsedDate))
                                        {
                                            ngayDangKy = parsedDate; // Cột D
                                        }

                                        if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(hoTen) && !string.IsNullOrEmpty(email))
                                        {
                                            string query = "INSERT INTO thanhvien (id, ho_ten, email, ngay_dang_ky) " +
                                                           "VALUES (@id, @hoTen, @email, @ngayDangKy)";

                                            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                                            {
                                                command.Parameters.AddWithValue("@id", id);
                                                command.Parameters.AddWithValue("@hoTen", hoTen);
                                                command.Parameters.AddWithValue("@email", email);
                                                command.Parameters.AddWithValue("@ngayDangKy", ngayDangKy);

                                                command.ExecuteNonQuery();
                                                addedCount++;
                                            }
                                        }
                                    }
                                    transaction.Commit();
                                    MessageBox.Show($"Đã thêm thành công {addedCount} thành viên từ file Excel.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadDanhSachThanhVien(); // Gọi hàm tải lại danh sách (nếu có)
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show($"Lỗi khi nhập dữ liệu từ Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa các thành viên đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";
                    List<string> idsToDelete = new List<string>();

                    // Lấy ID của các thành viên đã chọn
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        // Giả sử cột ID có tên là "id" (HÃY CHẮC CHẮN THAY THẾ BẰNG TÊN CỘT ID THỰC TẾ TRONG DATAGRIDVIEW CỦA BẠN)
                        if (row.Cells["id"].Value != null)
                        {
                            idsToDelete.Add(row.Cells["id"].Value.ToString());
                        }
                    }

                    if (idsToDelete.Count > 0)
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "DELETE FROM thanhvien WHERE id IN (" + string.Join(",", idsToDelete.Select(id => "'" + id + "'")) + ")";

                                using (MySqlCommand command = new MySqlCommand(query, connection))
                                {
                                    int rowsAffected = command.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show($"Đã xóa thành công {rowsAffected} thành viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadDanhSachThanhVien(); // Gọi hàm tải lại danh sách
                                    }
                                    else
                                    {
                                        MessageBox.Show("Không có thành viên nào được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thành viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy ID của dòng đang chọn
                string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();

                // Mở form sửa
                FormSuaThanhVien formSua = new FormSuaThanhVien(id);
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi sửa xong thì load lại danh sách
                    LoadDanhSachThanhVien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thành viên để sửa.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào nút trong cột "Vào khu vực" không
            if (e.ColumnIndex == dataGridView1.Columns["colVaoKhuVuc"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của thành viên từ hàng được nhấp
                string thanhVienId = dataGridView1.Rows[e.RowIndex].Cells["id"].Value?.ToString();

                if (!string.IsNullOrEmpty(thanhVienId))
                {
                    // Lấy thời điểm hiện tại
                    DateTime thoiGianVao = DateTime.Now;

                    // (Tùy chọn) Lấy thông tin khu vực (ví dụ: có thể có một ComboBox trên Form để chọn khu vực)
                    string khuVuc = ""; // Để trống nếu không có thông tin khu vực

                    // Chuỗi kết nối đến cơ sở dữ liệu
                    string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";

                    // Câu lệnh SQL INSERT để thêm thông tin vào bảng thongtinvaokhuvuc (ĐÃ SỬA TÊN BẢNG)
                    string query = "INSERT INTO thongtinvaokhuvuc (id_thanh_vien, thoi_gian_vao, khu_vuc) " +
                                   "VALUES (@idThanhVien, @thoiGianVao, @khuVuc)";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@idThanhVien", thanhVienId);
                                command.Parameters.AddWithValue("@thoiGianVao", thoiGianVao);
                                command.Parameters.AddWithValue("@khuVuc", khuVuc);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show($"Đã ghi nhận thành viên có ID {thanhVienId} vào khu vực học tập lúc {thoiGianVao}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // (Tùy chọn) Bạn có thể muốn cập nhật lại giao diện hoặc thực hiện hành động khác sau khi ghi nhận thành công
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi khi ghi nhận thông tin vào khu vực học tập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            // Kiểm tra xem người dùng có nhấp vào nút trong cột "Ra khu vực" không
            if (e.ColumnIndex == dataGridView1.Columns["colRaKhuVuc"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của thành viên từ hàng được nhấp
                string thanhVienId = dataGridView1.Rows[e.RowIndex].Cells["id"].Value?.ToString();

                if (!string.IsNullOrEmpty(thanhVienId))
                {
                    // Lấy thời điểm hiện tại
                    DateTime thoiGianRa = DateTime.Now;

                    // Chuỗi kết nối đến cơ sở dữ liệu
                    string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";

                    // Câu lệnh SQL UPDATE để cập nhật thời gian ra cho bản ghi vào gần nhất của thành viên
                    string query = "UPDATE thongtinvaokhuvuc " +
                                   "SET thoi_gian_ra = @thoiGianRa " +
                                   "WHERE id_thanh_vien = @idThanhVien AND thoi_gian_ra IS NULL " +
                                   "ORDER BY thoi_gian_vao DESC " +
                                   "LIMIT 1";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@idThanhVien", thanhVienId);
                                command.Parameters.AddWithValue("@thoiGianRa", thoiGianRa);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show($"Đã ghi nhận thành viên có ID {thanhVienId} ra khỏi khu vực học tập lúc {thoiGianRa}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // (Tùy chọn) Bạn có thể muốn cập nhật lại giao diện
                                }
                                else
                                {
                                    MessageBox.Show($"Không tìm thấy lượt vào nào chưa ghi nhận thời gian ra cho thành viên có ID {thanhVienId}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
        }



        private void btnTimKiemThanhVien_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemThanhVien.Text.Trim(); // Lấy từ khóa tìm kiếm và loại bỏ khoảng trắng thừa

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu từ khóa trống, có thể hiển thị lại toàn bộ danh sách thành viên
                LoadDanhSachThanhVien(); // Giả sử bạn đã có phương thức này để tải lại toàn bộ danh sách
                return;
            }

            string connectionString = "Server=localhost;Database=librarydb;Uid=root;Pwd=;";
            string query = "SELECT id, ho_ten, email FROM thanhvien " +
                           "WHERE id LIKE @keyword OR ho_ten LIKE @keyword OR email LIKE @keyword";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Sử dụng tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Gán DataTable kết quả tìm kiếm cho DataSource của DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi tìm kiếm thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem DataGridView có dữ liệu để xuất không
            if (dataGridView1.Rows.Count > 0)
            {
                // Tạo một ứng dụng Excel mới
                Excel.Application excelApp = new Excel.Application();

                // Tạo một Workbook mới
                Excel.Workbook workbook = excelApp.Workbooks.Add();

                // Tạo một Worksheet mới
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Đặt tiêu đề cho các cột trong Excel từ header của DataGridView
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // Đổ dữ liệu từ DataGridView vào Worksheet
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Hiển thị ứng dụng Excel
                excelApp.Visible = true;

                // Giải phóng các đối tượng COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    }
}





