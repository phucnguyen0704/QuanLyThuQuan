using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class ReservationForm : Form //-------------------------------------------- ĐẶT CHỖ ---------------------------------------------------------------
    {
        private readonly ReservationBLL reservationBLL;
        private List<ReservationDTO> reservationList;
        private bool isEditing = false;
        
        // Định nghĩa các hằng số để tránh "magic numbers"
        private const int STATUS_BORROWING = 1;
        private const int STATUS_RETURNED = 2;
        private const int STATUS_VIOLATION = 3;
        private const int STATUS_CANCELED = 4;
        
        private const int TYPE_ONSITE = 1;
        private const int TYPE_TAKEAWAY = 2;
        
        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderBackColor = Color.FromArgb(51, 51, 76);
        private static readonly Color HeaderForeColor = Color.White;
        private static readonly Color AlternatingRowColor = Color.FromArgb(240, 240, 240);
        private static readonly Color StatusBorrowingColor = Color.FromArgb(255, 193, 7); // Màu vàng
        private static readonly Color StatusReturnedColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
        private static readonly Color StatusViolationColor = Color.FromArgb(220, 53, 69); // Màu đỏ

        public ReservationForm()
        {
            InitializeComponent();
            reservationBLL = new ReservationBLL();

            // Đăng ký sự kiện CellFormatting
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            // Khởi tạo các ComboBox trước khi tải dữ liệu
            InitializeComboBoxes();
            
            // Tải dữ liệu
            LoadReservations();

            // Ẩn nút Lưu khi khởi động form
            btnSave.Visible = false;
        }

        private void InitializeComboBoxes()
        {
            SetupStatusComboBox();
            SetupReservationTypeComboBox();
            SetupSearchCategoryComboBox();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem cột hiện tại có phải là cột Status không
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.ForeColor = HeaderForeColor;

                switch (status)
                {
                    case "Đang mượn":
                        e.CellStyle.BackColor = StatusBorrowingColor;
                        break;
                    case "Đã trả":
                        e.CellStyle.BackColor = StatusReturnedColor;
                        break;
                    case "Vi phạm":
                        e.CellStyle.BackColor = StatusViolationColor;
                        break;
                }
            }
        }

        // Load dữ liệu lên dataGridView
        private void LoadReservations()
        {
            try
            {
                reservationList = reservationBLL.getAll();
                
                if (reservationList == null)
                {
                    MessageBox.Show("Không thể tải dữ liệu đặt chỗ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sử dụng phương thức tạo DataTable riêng biệt
                DataTable dt = CreateDataTableFromReservations(reservationList);
                
                // Gán dữ liệu cho DataGridView
                dataGridView1.DataSource = dt;

                // Cấu hình các cột
                ConfigureDataGridViewColumns();
                
                // Định dạng DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đặt chỗ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateDataTableFromReservations(List<ReservationDTO> reservations)
        {
            DataTable dt = new DataTable();
            
            // Tạo cấu trúc DataTable
            dt.Columns.Add("ReservationID", typeof(int));
            dt.Columns.Add("MemberID", typeof(int));
            dt.Columns.Add("SeatID", typeof(int));
            dt.Columns.Add("ReservationType", typeof(string));
            dt.Columns.Add("ReservationTime", typeof(DateTime));
            dt.Columns.Add("DueTime", typeof(DateTime));
            dt.Columns.Add("ReturnTime", typeof(DateTime));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("CreatedAt", typeof(DateTime));

            // Thêm dữ liệu vào DataTable
            foreach (ReservationDTO reservation in reservations)
            {
                dt.Rows.Add(
                    reservation.ReservationID,
                    reservation.MemberID,
                    reservation.SeatID,
                    GetReservationTypeText(reservation.ReservationType),
                    reservation.ReservationTime,
                    reservation.DueTime,
                    reservation.ReturnTime,
                    GetStatusText(reservation.Status),
                    reservation.CreatedAt
                );
            }
            
            return dt;
        }

        private void ConfigureDataGridViewColumns()
        {
            // Đặt tiêu đề cho các cột
            dataGridView1.Columns["ReservationID"].HeaderText = "Mã đặt chỗ";
            dataGridView1.Columns["MemberID"].HeaderText = "Mã thành viên";
            dataGridView1.Columns["SeatID"].HeaderText = "Mã ghế";
            dataGridView1.Columns["ReservationType"].HeaderText = "Loại đặt chỗ";
            dataGridView1.Columns["ReservationTime"].HeaderText = "Thời gian đặt";
            dataGridView1.Columns["DueTime"].HeaderText = "Thời hạn";
            dataGridView1.Columns["ReturnTime"].HeaderText = "Thời gian trả";
            dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Ngày tạo";

            // Định dạng cột ngày tháng
            dataGridView1.Columns["ReservationTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView1.Columns["DueTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView1.Columns["ReturnTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private string GetReservationTypeText(int reservationType)
        {
            switch (reservationType)
            {
                case TYPE_ONSITE:
                    return "Tại chỗ";
                case TYPE_TAKEAWAY:
                    return "Mang về";
                default:
                    return "Không xác định";
            }
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case STATUS_BORROWING:
                    return "Đang mượn";
                case STATUS_RETURNED:
                    return "Đã trả";
                case STATUS_VIOLATION:
                    return "Vi phạm";
                case STATUS_CANCELED:
                    return "Đã hủy";
                default:
                    return "Không xác định";
            }
        }

        private int GetReservationTypeValue(string typeText)
        {
            switch (typeText)
            {
                case "Đặt tại chỗ":
                    return TYPE_ONSITE;
                case "Mang về":
                    return TYPE_TAKEAWAY;
                default:
                    return TYPE_ONSITE; // Mặc định
            }
        }

        private int GetStatusValue(string statusText)
        {
            switch (statusText)
            {
                case "Đang mượn":
                    return STATUS_BORROWING;
                case "Đã trả":
                    return STATUS_RETURNED;
                case "Vi phạm":
                    return STATUS_VIOLATION;
                case "Đã hủy":
                    return STATUS_CANCELED;
                default:
                    return STATUS_BORROWING; // Mặc định
            }
        }

        private void FormatDataGridView()
        {
            // Định dạng tiêu đề cột
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // Định dạng các dòng
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowColor;

            // Định dạng đường viền
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void SetupStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new string[] { "Đang mượn", "Đã trả", "Vi phạm" });
            cboStatus.SelectedIndex = 0;
        }

        private void SetupReservationTypeComboBox()
        {
            cboReservationType.Items.Clear();
            cboReservationType.Items.AddRange(new string[] { "Đặt tại chỗ", "Mang về" });
            cboReservationType.SelectedIndex = 0;
        }

        private void SetupSearchCategoryComboBox()
        {
            cboSearchCategory.Items.Clear();
            cboSearchCategory.Items.AddRange(new string[] { 
                "Tất cả", 
                "Mã đặt chỗ", 
                "Mã thành viên", 
                "Mã ghế", 
                "Loại đặt chỗ", 
                "Trạng thái" 
            });
            cboSearchCategory.SelectedIndex = 0;
        }

        // Hàm này có chức năng khi click nào một dòng bất kỳ sẽ cho ra từng giá trị ở từng textBox
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            try
            {
                // Lấy ID đặt chỗ từ dòng được chọn
                int reservationID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ReservationID"].Value);

                // Tìm đặt chỗ trong danh sách
                ReservationDTO selectedReservation = reservationList.FirstOrDefault(r => r.ReservationID == reservationID);

                if (selectedReservation != null)
                {
                    PopulateFormFields(selectedReservation);
                    
                    // Hiển thị nút Sửa và Xóa, ẩn nút Lưu
                    SetButtonsForViewMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFormFields(ReservationDTO reservation)
        {
            txtReservationID.Text = reservation.ReservationID.ToString();
            txtMemberID.Text = reservation.MemberID.ToString();
            txtSeatID.Text = reservation.SeatID.ToString();

            // Đặt loại đặt chỗ
            cboReservationType.SelectedIndex = reservation.ReservationType - 1;

            // Đặt thời gian
            dtpReservationTime.Value = reservation.ReservationTime;
            dtpDueTime.Value = reservation.DueTime;
            dtpReturnTime.Value = (DateTime) reservation.ReturnTime;

            // Đặt trạng thái
            cboStatus.SelectedIndex = reservation.Status - 1;

            dtpCreatedAt.Value = reservation.CreatedAt;
        }

        private void SetButtonsForViewMode()
        {
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            isEditing = false;
        }

        private void SetButtonsForEditMode()
        {
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }

        // Xử lý trong Button Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditing = false;

            // Hiển thị nút Lưu, ẩn nút Sửa và Xóa
            SetButtonsForEditMode();

            // Focus vào ô mã thành viên
            txtMemberID.Focus();
        }

        // Xử lý trong Button Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Text))
            {
                MessageBox.Show("Vui lòng chọn đặt chỗ cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;

            // Hiển thị nút Lưu, ẩn nút Sửa và Xóa
            SetButtonsForEditMode();

            // Focus vào ô mã thành viên
            txtMemberID.Focus();
        }

        // Xử lý trong Button Lưu
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (!ValidateInput())
                    return;

                // Lấy dữ liệu từ form
                ReservationDTO reservation = GetReservationFromForm();
                bool result;

                if (isEditing)
                {
                    // Cập nhật đặt chỗ
                    result = reservationBLL.update(reservation);
                    
                    if (result)
                    {
                        MessageBox.Show("Cập nhật đặt chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đặt chỗ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Thêm đặt chỗ mới
                    result = reservationBLL.create(reservation);
                    
                    if (result)
                    {
                        MessageBox.Show("Thêm đặt chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm đặt chỗ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Làm mới form và tải lại dữ liệu
                LoadReservations();
                ClearForm();

                // Hiển thị lại nút Sửa và Xóa, ẩn nút Lưu
                SetButtonsForViewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSeatID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeatID.Focus();
                return false;
            }

            // Kiểm tra định dạng số
            if (!int.TryParse(txtMemberID.Text, out _))
            {
                MessageBox.Show("Mã thành viên phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return false;
            }

            if (!int.TryParse(txtSeatID.Text, out _))
            {
                MessageBox.Show("Mã ghế phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeatID.Focus();
                return false;
            }

            return true;
        }

        private ReservationDTO GetReservationFromForm()
        {
            int reservationID = isEditing ? int.Parse(txtReservationID.Text) : 0;
            int memberID = int.Parse(txtMemberID.Text);
            int seatID = int.Parse(txtSeatID.Text);
            
            // Lấy loại đặt chỗ và trạng thái từ ComboBox
            int reservationType = cboReservationType.SelectedIndex + 1;
            int status = cboStatus.SelectedIndex + 1;

            return new ReservationDTO(
                reservationID,
                memberID,
                seatID,
                reservationType,
                dtpReservationTime.Value,
                dtpDueTime.Value,
                dtpReturnTime.Value,
                status,
                dtpCreatedAt.Value
            );
        }

        // Xử lý trong Button Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtReservationID.Text))
                {
                    MessageBox.Show("Vui lòng chọn đặt chỗ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationID = int.Parse(txtReservationID.Text);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đặt chỗ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = reservationBLL.delete(reservationID);

                    if (success)
                    {
                        MessageBox.Show("Xóa đặt chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservations();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đặt chỗ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();

            // Hiển thị lại nút Sửa và Xóa, ẩn nút Lưu
            SetButtonsForViewMode();
        }

        private void ClearForm()
        {
            txtReservationID.Text = "";
            txtMemberID.Text = "";
            txtSeatID.Text = "";
            cboReservationType.SelectedIndex = 0;
            dtpReservationTime.Value = DateTime.Now;
            dtpDueTime.Value = DateTime.Now.AddHours(2); // Mặc định thời hạn là 2 giờ sau
            dtpReturnTime.Value = DateTime.Now;
            cboStatus.SelectedIndex = 0;
            dtpCreatedAt.Value = DateTime.Now;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu ô tìm kiếm trống, hiển thị tất cả đặt chỗ
                LoadReservations();
                return;
            }

            // Lọc danh sách đặt chỗ theo loại tìm kiếm đã chọn
            List<ReservationDTO> filteredList = FilterReservations(searchText);

            // Hiển thị danh sách đã lọc
            DisplayFilteredReservations(filteredList);
        }

        private List<ReservationDTO> FilterReservations(string searchText)
        {
            if (reservationList == null)
                return new List<ReservationDTO>();

            switch (cboSearchCategory.SelectedIndex)
            {
                case 0: // Tất cả
                    return reservationList.Where(reservation =>
                        reservation.ReservationID.ToString().Contains(searchText) ||
                        reservation.MemberID.ToString().Contains(searchText) ||
                        reservation.SeatID.ToString().Contains(searchText) ||
                        GetReservationTypeText(reservation.ReservationType).ToLower().Contains(searchText) ||
                        GetStatusText(reservation.Status).ToLower().Contains(searchText)
                    ).ToList();

                case 1: // Mã đặt chỗ
                    return reservationList.Where(reservation =>
                        reservation.ReservationID.ToString().Contains(searchText)
                    ).ToList();

                case 2: // Mã thành viên
                    return reservationList.Where(reservation =>
                        reservation.MemberID.ToString().Contains(searchText)
                    ).ToList();

                case 3: // Mã ghế
                    return reservationList.Where(reservation =>
                        reservation.SeatID.ToString().Contains(searchText)
                    ).ToList();

                case 4: // Loại đặt chỗ
                    return reservationList.Where(reservation =>
                        GetReservationTypeText(reservation.ReservationType).ToLower().Contains(searchText)
                    ).ToList();

                case 5: // Trạng thái
                    return reservationList.Where(reservation =>
                        GetStatusText(reservation.Status).ToLower().Contains(searchText)
                    ).ToList();

                default:
                    return reservationList;
            }
        }

        private void DisplayFilteredReservations(List<ReservationDTO> filteredList)
        {
            // Tạo DataTable từ danh sách đã lọc
            DataTable dt = CreateDataTableFromReservations(filteredList);
            
            // Gán dữ liệu cho DataGridView
            dataGridView1.DataSource = dt;
            
            // Định dạng DataGridView
            FormatDataGridView();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            // Có thể thêm code khởi tạo bổ sung ở đây nếu cần
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi thay đổi loại tìm kiếm, thực hiện tìm kiếm lại
            txtSearch_TextChanged(sender, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Phương thức này không cần thiết, có thể xóa
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboReservationType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}