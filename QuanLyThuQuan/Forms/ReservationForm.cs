// ReservationForm.cs
using DocumentFormat.OpenXml.Office2010.Drawing;
using Org.BouncyCastle.Asn1.Cmp;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class ReservationForm : Form //-------------------------------------------- MƯỢN TRẢ ---------------------------------------------------------------
    {
        private readonly ReservationBLL reservationBLL;
        private readonly ReservationDetailBLL reservationDetailBLL;
        private readonly MemberBLL memberBLL;

        private List<ReservationDTO> reservationList;
        private bool isEditing = false;
        private ReservationDTO currentReservation; // Lưu trữ thông tin reservation hiện tại để khôi phục khi cần

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

        // Biến để theo dõi trạng thái trước đó
        private string previousStatus = "";

        public ReservationForm()
        {
            InitializeComponent();
            reservationBLL = new ReservationBLL();
            reservationDetailBLL = new ReservationDetailBLL();
            memberBLL = new MemberBLL();

            // Đăng ký sự kiện CellFormatting
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            // Đăng ký sự kiện SelectedIndexChanged cho combobox Status
            cboStatus.SelectedIndexChanged += CboStatus_SelectedIndexChanged;

            // Khởi tạo các ComboBox trước khi tải dữ liệu
            InitializeComboBoxes();

            // Tải dữ liệu
            LoadReservations();

            // Ẩn nút Lưu khi khởi động form
            btnSave.Visible = false;

            SetButtonsForViewMode();
        }

        private void CboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentStatus = cboStatus.SelectedItem.ToString();

            // Nếu chuyển sang trạng thái "Đã trả" và ReturnTime là null, tự động cập nhật ReturnTime
            if (currentStatus == "Đã trả" && string.IsNullOrEmpty(lblReturnTimeValue.Text))
            {
                lblReturnTimeValue.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }
            // Nếu chuyển từ "Đã trả" sang trạng thái khác và đang chỉnh sửa, khôi phục giá trị từ database
            else if (previousStatus == "Đã trả" && currentStatus != "Đã trả" && isEditing && currentReservation != null)
            {
                // Khôi phục giá trị ReturnTime từ database
                if (currentReservation.ReturnTime.HasValue)
                {
                    lblReturnTimeValue.Text = currentReservation.ReturnTime.Value.ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    lblReturnTimeValue.Text = "";
                }
            }

            // Cập nhật trạng thái trước đó
            previousStatus = currentStatus;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Xử lý cột Status
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

            // Xử lý cột ReturnTime để hiển thị trống khi null
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ReturnTime" && e.Value == DBNull.Value)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }

            // Xử lý cột SeatID để hiển thị trống khi null
            if (dataGridView1.Columns[e.ColumnIndex].Name == "SeatID" && e.Value == DBNull.Value)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void InitializeComboBoxes()
        {
            SetupStatusComboBox();
            SetupReservationTypeComboBox();
            SetupSearchCategoryComboBox();
        }

        private void LoadReservations()
        {
            try
            {
                reservationList = reservationBLL.getAll();

                if (reservationList == null)
                {
                    MessageBox.Show("Không thể tải dữ liệu thông tin mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = CreateDataTableFromReservations(reservationList);
                dataGridView1.DataSource = dt;
                ConfigureDataGridViewColumns();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thông tin mượn: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateDataTableFromReservations(List<ReservationDTO> reservations)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ReservationID", typeof(int));
            dt.Columns.Add("MemberID", typeof(uint));
            dt.Columns.Add("SeatID", typeof(int)).AllowDBNull = true; // Cho phép null
            dt.Columns.Add("ReservationType", typeof(string));
            dt.Columns.Add("ReservationTime", typeof(DateTime));
            dt.Columns.Add("DueTime", typeof(DateTime));
            dt.Columns.Add("ReturnTime", typeof(DateTime)).AllowDBNull = true;
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("CreatedAt", typeof(DateTime));

            foreach (ReservationDTO reservation in reservations)
            {
                dt.Rows.Add(
                    reservation.ReservationID,
                    reservation.MemberID,
                    reservation.SeatID.HasValue ? (object)reservation.SeatID.Value : DBNull.Value,
                    GetReservationTypeText(reservation.ReservationType),
                    reservation.ReservationTime,
                    reservation.DueTime,
                    reservation.ReturnTime.HasValue ? (object)reservation.ReturnTime.Value : DBNull.Value,
                    GetStatusText(reservation.Status),
                    reservation.CreatedAt
                );
            }

            return dt;
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridView1.Columns["ReservationID"].HeaderText = "Mã phiếu mượn";
            dataGridView1.Columns["MemberID"].HeaderText = "Mã thành viên";
            dataGridView1.Columns["SeatID"].HeaderText = "Mã chỗ";
            dataGridView1.Columns["ReservationType"].HeaderText = "Loại mượn";
            dataGridView1.Columns["ReservationTime"].HeaderText = "Thời gian đặt";
            dataGridView1.Columns["DueTime"].HeaderText = "Thời hạn";
            dataGridView1.Columns["ReturnTime"].HeaderText = "Thời gian trả";
            dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Ngày tạo";

            dataGridView1.Columns["ReservationTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView1.Columns["DueTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView1.Columns["ReturnTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView1.Columns["ReturnTime"].DefaultCellStyle.NullValue = "";
            dataGridView1.Columns["SeatID"].DefaultCellStyle.NullValue = ""; // Hiển thị trống khi null
            dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
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
                    return TYPE_ONSITE;
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
                    return STATUS_BORROWING;
            }
        }

        private void FormatDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowColor;

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
                "Mã mượn",
                "Mã thành viên",
                "Mã ghế",
                "Loại mượn",
                "Trạng thái"
            });
            cboSearchCategory.SelectedIndex = 0;
        }

        private void PopulateFormFields(ReservationDTO reservation, List<int> selectedDeviceIDs)
        {
            txtReservationID.Text = reservation.ReservationID.ToString();
            txtMemberID.Text = reservation.MemberID.ToString();
            txtSeatID.Text = reservation.SeatID.HasValue ? reservation.SeatID.Value.ToString() : "";

            string deviceIDList = string.Join(Environment.NewLine, selectedDeviceIDs);
            richTxtDeviceIDList.Text = deviceIDList;


            cboReservationType.SelectedIndex = reservation.ReservationType - 1;

            // Hiển thị thời gian đặt trong label
            //lblReservationTimeValue.Text = reservation.ReservationTime.ToString("dd/MM/yyyy HH:mm");
            dtpReservationTime.Value = reservation.ReservationTime;

            dtpDueTime.Value = reservation.DueTime;

            // Hiển thị thời gian trả trong label
            if (reservation.ReturnTime.HasValue)
            {
                lblReturnTimeValue.Text = reservation.ReturnTime.Value.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                lblReturnTimeValue.Text = "";
            }

            cboStatus.SelectedIndex = reservation.Status - 1;
            dtpCreatedAt.Value = reservation.CreatedAt;
        }

        private void SetButtonsForViewMode()
        {
            isEditing = false;

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = false;
            //btnDelete.Visible = true;

            if (GetStatusValue(cboStatus.Text) == STATUS_VIOLATION || GetStatusValue(cboStatus.Text) == STATUS_RETURNED) 
            {
                btnEdit.Visible = false;
            } else {
                btnEdit.Visible = true;
            }

            txtMemberID.Enabled = false;
            cboReservationType.Enabled = false;
            btnChonMaGhe.Enabled = false;
            btnChonThietBi.Enabled = false;
            dtpReservationTime.Enabled = false;
            dtpDueTime.Enabled = false;
            cboStatus.Enabled = false;
        }

        private void SetButtonsForEditMode()
        {
            btnSave.Visible = true;
            btnClear.Visible = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            //btnDelete.Visible = false;

            // txtMemberID.Enabled = true;
            // cboReservationType.Enabled = true;
            // btnChonMaGhe.Enabled = true;
            // btnChonThietBi.Enabled = true;
            // if(!isEditing) dtpReservationTime.Enabled = true;
            // dtpDueTime.Enabled = true;
            cboStatus.Enabled = true;
        }

        private void SetButtonsForAddMode()
        {
                        btnSave.Visible = true;
            btnClear.Visible = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            //btnDelete.Visible = false;

            txtMemberID.Enabled = true;
            cboReservationType.Enabled = true;
            btnChonMaGhe.Enabled = true;
            btnChonThietBi.Enabled = true;
            dtpReservationTime.Enabled = true;
            dtpDueTime.Enabled = true;
            cboStatus.Enabled = true;

            cboStatus.SelectedIndex = 0;
            cboStatus.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            currentReservation = null; // Xóa reservation hiện tại khi thêm mới
            isEditing = false;
            SetButtonsForAddMode();
            txtMemberID.Focus();
            dtpReservationTime.Value = DateTime.Now;

            // Cập nhật trạng thái trước đó
            previousStatus = cboStatus.SelectedItem.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Text))
            {
                MessageBox.Show("Vui lòng chọn thông tin mượn cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            SetButtonsForEditMode();
            txtMemberID.Focus();

            // Cập nhật trạng thái trước đó
            previousStatus = cboStatus.SelectedItem.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                ReservationDTO reservation = GetReservationFromForm();
                List<ReservationDetailDTO> reservationDetails = getReservationDetailFromForm();

                bool result;

                if (isEditing)
                {
                    if (reservationDetails.Count == 0) 
                    { 
                        result = reservationBLL.update(reservation);
                    }
                    else
                    {
                        result = reservationBLL.update(reservation, reservationDetails);
                    }

                    if (result)
                    {
                        MessageBox.Show("Cập nhật thông tin mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // dataGridView1.SelectedRows[0].Cells["Status"].Value = cboStatus.Text;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin mượn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (reservationDetails.Count == 0)
                    {
                        result = reservationBLL.create(reservation);
                    }
                    else 
                    {
                        result = reservationBLL.create(reservation, reservationDetails);
                    }

                    if (result)
                    {
                        MessageBox.Show("Thêm thông tin mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thông tin mượn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                ClearForm();
                LoadReservations();
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

            if (!uint.TryParse(txtMemberID.Text, out _))
            {
                MessageBox.Show("Mã thành viên phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return false;
            }

            MemberDTO member = memberBLL.getByID(uint.Parse(txtMemberID.Text));

            if (member == null)
            {
                MessageBox.Show("Mã thành viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return false;
            }

            if (member.Status == 3)
            {
                MessageBox.Show("Mã thành viên đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return false;
            }

            // Kiểm tra SeatID: Nếu không trống, phải là số
            if (!string.IsNullOrEmpty(txtSeatID.Text) && !int.TryParse(txtSeatID.Text, out _))
            {
                MessageBox.Show("Mã ghế phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeatID.Focus();
                return false;
            }

            if(string.IsNullOrEmpty(txtSeatID.Text) && string.IsNullOrEmpty(richTxtDeviceIDList.Text))
            {
                MessageBox.Show("Vui lòng chọn chỗ hoặc thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChonThietBi.Focus();
                return false;
            }

            return true;
        }

        private ReservationDTO GetReservationFromForm()
        {
            int reservationID = isEditing ? int.Parse(txtReservationID.Text) : 0;
            uint memberID = uint.Parse(txtMemberID.Text);
            int? seatID;
            if (string.IsNullOrEmpty(txtSeatID.Text))
            {
                seatID = null;
            }
            else
            {
                seatID = int.Parse(txtSeatID.Text);
            }

            int reservationType = cboReservationType.SelectedIndex + 1;
            int status = cboStatus.SelectedIndex + 1;

            // Lấy thời gian đặt
            DateTime reservationTime;
            if (isEditing && !string.IsNullOrEmpty(lblReservationTimeValue.Text))
            {
                // Nếu đang chỉnh sửa, giữ nguyên thời gian đặt cũ
                reservationTime = DateTime.ParseExact(lblReservationTimeValue.Text, "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                // Nếu đang thêm mới, đặt thời gian hiện tại
                reservationTime = DateTime.Now;
            }

            // Lấy thời gian trả
            DateTime? returnTime = null;
            if (!string.IsNullOrEmpty(lblReturnTimeValue.Text))
            {
                returnTime = DateTime.ParseExact(lblReturnTimeValue.Text, "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
            }

            // Tự động cập nhật thời gian trả khi chọn trạng thái "Đã trả"
            if (status == STATUS_RETURNED && returnTime == null)
            {
                returnTime = DateTime.Now;
            }

            return new ReservationDTO(
                reservationID,
                memberID,
                seatID,
                reservationType,
                reservationTime,
                dtpDueTime.Value,
                returnTime,
                status,
                dtpCreatedAt.Value
            );
        }

        private List<ReservationDetailDTO> getReservationDetailFromForm() 
        {
            List<ReservationDetailDTO> reservationDetails = new List<ReservationDetailDTO>();
            List<int> selectedDeviceIDs = getSelectedDeviceIDList();

            if (selectedDeviceIDs.Count != 0)
            {
                int reservationID = txtReservationID.Text != "" ? int.Parse(txtReservationID.Text) : 0;
                if (reservationID == 0)
                {
                    foreach (int deviceID in selectedDeviceIDs)
                    {
                        reservationDetails.Add(new ReservationDetailDTO(reservationID, deviceID, GetStatusValue(cboStatus.Text)));
                    }
                }
                else {
                    reservationDetails = reservationDetailBLL.getByReservationID(reservationID);
                    foreach (var detail in reservationDetails)
                    {
                       detail.Status = GetStatusValue(cboStatus.Text);
                    }
                }
            }

            return reservationDetails;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtReservationID.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin mượn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationID = int.Parse(txtReservationID.Text);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin mượn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = reservationBLL.delete(reservationID);
                    if (success)
                    {
                        MessageBox.Show("Xóa thông tin mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservations();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin mượn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            currentReservation = null; // Xóa reservation hiện tại khi làm mới form
            loadFormFromSelectedRow();
            SetButtonsForViewMode();
        }

        private void ClearForm()
        {
            txtReservationID.Text = "";
            txtMemberID.Text = "";
            txtSeatID.Text = "";
            richTxtDeviceIDList.Text = "";
            cboReservationType.SelectedIndex = 0;

            // Đặt thời gian đặt là thời gian hiện tại
            //lblReservationTimeValue.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            dtpReservationTime.Value = DateTime.Now;

            dtpDueTime.Value = DateTime.Now.AddHours(2);

            // Xóa thời gian trả
            lblReturnTimeValue.Text = "";

            cboStatus.SelectedIndex = 0;
            dtpCreatedAt.Value = DateTime.Now;

            // Cập nhật trạng thái trước đó
            previousStatus = cboStatus.SelectedItem.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadReservations();
                return;
            }

            List<ReservationDTO> filteredList = FilterReservations(searchText);
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
                        (reservation.SeatID.HasValue && reservation.SeatID.Value.ToString().Contains(searchText)) ||
                        GetReservationTypeText(reservation.ReservationType).ToLower().Contains(searchText) ||
                        GetStatusText(reservation.Status).ToLower().Contains(searchText)
                    ).ToList();
                case 1: // Mã mượn
                    return reservationList.Where(reservation =>
                        reservation.ReservationID.ToString().Contains(searchText)
                    ).ToList();
                case 2: // Mã thành viên
                    return reservationList.Where(reservation =>
                        reservation.MemberID.ToString().Contains(searchText)
                    ).ToList();
                case 3: // Mã ghế
                    return reservationList.Where(reservation =>
                        reservation.SeatID.HasValue && reservation.SeatID.Value.ToString().Contains(searchText)
                    ).ToList();
                case 4: // Loại mượn
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
            DataTable dt = CreateDataTableFromReservations(filteredList);
            dataGridView1.DataSource = dt;
            FormatDataGridView();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void btnChonMaGhe_Click(object sender, EventArgs e)
        {
            int? currentSeatID = null;

            if (int.TryParse(txtSeatID.Text, out int seatId))
                currentSeatID = seatId;

            using (var form = new SelectAvailableSeatForm(currentSeatID))
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedSeatID.HasValue) {
                    txtSeatID.Text = form.SelectedSeatID.Value.ToString();
                }
            }
        }

        private List<int> getSelectedDeviceIDList() 
        {
            List<int> selectedIDs = new List<int>();
            if (!string.IsNullOrWhiteSpace(richTxtDeviceIDList.Text))
            {
                string[] lines = richTxtDeviceIDList.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                selectedIDs = lines
                    .Select(s => s.Trim())
                    .Select(s => int.TryParse(s, out int id) ? id : -1)
                    .Where(id => id != -1)
                    .ToList();
            }
            return selectedIDs;
        }

        private void btnChonThietBi_Click(object sender, EventArgs e)
        {
            List<int> selectedIDs = getSelectedDeviceIDList();

            using (var form = new SelectAvailableDeviceForm(selectedIDs))
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedDeviceIDs.Any())
                {
                    string deviceIDList = string.Join(Environment.NewLine, form.SelectedDeviceIDs);
                    richTxtDeviceIDList.Text = deviceIDList;
                }
            }
        }

        private void loadFormFromSelectedRow() 
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int reservationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                    ReservationDTO selectedReservation = reservationList.FirstOrDefault(r => r.ReservationID == reservationID);

                    if (selectedReservation != null)
                    {
                        // Lưu reservation hiện tại để có thể khôi phục khi cần
                        currentReservation = selectedReservation;

                        List<int> selectedDeviceIDs = reservationDetailBLL.getByReservationID(reservationID)
                            .Select(rd => rd.DeviceID)
                            .ToList();

                        PopulateFormFields(selectedReservation, selectedDeviceIDs);
                        SetButtonsForViewMode();

                        // Cập nhật trạng thái trước đó
                        previousStatus = cboStatus.SelectedItem.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            loadFormFromSelectedRow();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadReservations();
            loadFormFromSelectedRow();
        }

        private void txtSeatID_TextChanged(object sender, EventArgs e)
        {
            if (txtSeatID.Text == "")
            {
                cboReservationType.Enabled = true;
            }
            else
            {
                cboReservationType.SelectedIndex = 0;
                cboReservationType.Enabled = false;
            }
        }
    }
}