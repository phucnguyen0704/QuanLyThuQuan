using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class SeatForm : Form
    {
        private readonly SeatBLL seatBLL;
        private List<SeatDTO> seatList;
        private bool isEditing = false;

        // Định nghĩa các hằng số trạng thái
        private const int STATUS_AVAILABLE = 1;  // Còn
        private const int STATUS_BORROWED = 2;   // Đã đặt
        private const int STATUS_DELETED = 0;    // Đã xóa

        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderBackColor = Color.FromArgb(51, 51, 76);
        private static readonly Color HeaderForeColor = Color.White;
        private static readonly Color AlternatingRowColor = Color.FromArgb(240, 240, 240);
        private static readonly Color StatusAvailableColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
        private static readonly Color StatusOccupiedColor = Color.FromArgb(220, 53, 69); // Màu đỏ

        public SeatForm()
        {
            InitializeComponent();
            seatBLL = new SeatBLL();

            // Đăng ký sự kiện CellFormatting để tô màu trạng thái
            dataGridViewSeat.CellFormatting += DataGridViewSeat_CellFormatting;

            // Khởi tạo các ComboBox
            InitializeComboBoxes();

            // Tải dữ liệu
            LoadSeats();

            // Ẩn nút Lưu khi khởi động form
            btnSave.Visible = false;
        }

        private void DataGridViewSeat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewSeat.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                // Convert the integer status to text for display
                int statusValue = Convert.ToInt32(e.Value);
                e.Value = GetStatusText(statusValue);
                e.CellStyle.ForeColor = HeaderForeColor;

                switch (statusValue)
                {
                    case STATUS_AVAILABLE:
                        e.CellStyle.BackColor = StatusAvailableColor;
                        break;
                    case STATUS_BORROWED:
                        e.CellStyle.BackColor = StatusOccupiedColor;
                        break;
                    case STATUS_DELETED:
                        e.CellStyle.BackColor = Color.FromArgb(108, 117, 125); // Gray color for deleted
                        break;
                }
            }
        }

        private void InitializeComboBoxes()
        {
            SetupSearchCategoryComboBox();
        }

        private void SetupSearchCategoryComboBox()
        {
            cboSearchCategory.Items.Clear();
            cboSearchCategory.Items.AddRange(new string[]
            {
                "Tất cả",
                "Mã chỗ ngồi",
                "Tên chỗ ngồi",
                "Trạng thái"
            });
            cboSearchCategory.SelectedIndex = 0;
        }

        private void LoadSeats()
        {
            try
            {
                seatList = seatBLL.getAllSeat();
                if (seatList == null)
                {
                    MessageBox.Show("Không thể tải dữ liệu chỗ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridViewSeat.DataSource = seatList;
                ConfigureDataGridViewColumns();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu chỗ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridViewSeat.Columns["seatId"].HeaderText = "Mã chỗ ngồi";
            dataGridViewSeat.Columns["seatName"].HeaderText = "Tên chỗ ngồi";
            dataGridViewSeat.Columns["status"].HeaderText = "Trạng thái";
        }

        private void FormatDataGridView()
        {
            dataGridViewSeat.EnableHeadersVisualStyles = false;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewSeat.ColumnHeadersHeight = 40;

            dataGridViewSeat.RowTemplate.Height = 40;
            dataGridViewSeat.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridViewSeat.AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowColor;

            dataGridViewSeat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewSeat.GridColor = Color.FromArgb(230, 230, 230);

            dataGridViewSeat.ReadOnly = true;
            dataGridViewSeat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSeat.MultiSelect = false;
            dataGridViewSeat.AllowUserToAddRows = false;
            dataGridViewSeat.AllowUserToDeleteRows = false;
            dataGridViewSeat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case STATUS_AVAILABLE: return "Còn";
                case STATUS_BORROWED: return "Đã đặt";
                case STATUS_DELETED: return "Đã xóa";
                default: return "Không xác định";
            }
        }

        private int GetStatusValue(string statusText)
        {
            switch (statusText)
            {
                case "Còn": return STATUS_AVAILABLE;
                case "Đã đặt": return STATUS_BORROWED;
                case "Đã xóa": return STATUS_DELETED;
                default: return STATUS_AVAILABLE;
            }
        }

        private void dataGridViewSeat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewSeat.Rows.Count)
                return;

            int seatId = Convert.ToInt32(dataGridViewSeat.Rows[e.RowIndex].Cells["seatId"].Value);
            SeatDTO selectedSeat = seatList.FirstOrDefault(s => s.seatId == seatId);

            if (selectedSeat != null)
            {
                PopulateFormFields(selectedSeat);
                SetButtonsForViewMode();
            }
        }

        private void PopulateFormFields(SeatDTO seat)
        {
            txtSeatID.Text = seat.seatId.ToString();
            txtSeatName.Text = seat.seatName;

            // Set the status label based on the integer status
            string statusText = GetStatusText(seat.status);
            lblStatusValue.Text = statusText;

            // Update the status label color
            UpdateStatusLabelColor(seat.status);

            // Make the status label visible
            lblStatusValue.Visible = true;
        }

        private void UpdateStatusLabelColor(int status)
        {
            switch (status)
            {
                case STATUS_AVAILABLE:
                    lblStatusValue.BackColor = StatusAvailableColor;
                    break;
                case STATUS_BORROWED:
                    lblStatusValue.BackColor = StatusOccupiedColor;
                    break;
                case STATUS_DELETED:
                    lblStatusValue.BackColor = Color.FromArgb(108, 117, 125); // Gray color for deleted
                    break;
            }
        }

        private void SetButtonsForViewMode()
        {
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            isEditing = false;
        }

        private void SetButtonsForEditMode()
        {
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditing = false;
            SetButtonsForEditMode();
            txtSeatName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSeatID.Text))
            {
                MessageBox.Show("Vui lòng chọn chỗ ngồi cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            SetButtonsForEditMode();
            txtSeatName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                string name = txtSeatName.Text.Trim();
                string result;

                // Use the current status from the selected seat
                int statusValue = STATUS_AVAILABLE; // Default to available
                if (!string.IsNullOrEmpty(txtSeatID.Text))
                {
                    int seatId = int.Parse(txtSeatID.Text);
                    SeatDTO selectedSeat = seatList.FirstOrDefault(s => s.seatId == seatId);
                    if (selectedSeat != null)
                    {
                        statusValue = selectedSeat.status;
                    }
                }

                if (isEditing)
                {
                    int seatId = int.Parse(txtSeatID.Text);
                    result = seatBLL.update(seatId, name);
                    if (result == null)
                    {
                        MessageBox.Show("Cập nhật chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSeats();
                        ClearForm();
                        SetButtonsForViewMode();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    result = seatBLL.create(name);
                    if (result == null)
                    {
                        MessageBox.Show("Thêm chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSeats();
                        ClearForm();
                        SetButtonsForViewMode();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtSeatName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeatName.Focus();
                return false;
            }

            //// Kiểm tra tên chỗ chỉ chứa chữ cái và số
            //if (!Regex.IsMatch(txtSeatName.Text.Trim(), @"^[A-Za-z0-9]+$"))
            //{
            //    MessageBox.Show("Tên chỗ chỉ gồm chữ cái và số, vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtSeatName.Focus();
            //    return false;
            //}

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSeatID.Text))
                {
                    MessageBox.Show("Vui lòng chọn chỗ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int seatId = int.Parse(txtSeatID.Text);
                string seatName = txtSeatName.Text;

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc muốn xóa chỗ {seatName} khỏi danh sách chứ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    string result = seatBLL.delete(seatId);
                    if (result == null)
                    {
                        MessageBox.Show("Xóa chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSeats();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadSeats();
            ClearForm();
            SetButtonsForViewMode();
        }

        private void ClearForm()
        {
            txtSeatID.Text = "";
            txtSeatName.Text = "";
            lblStatusValue.Text = "Còn";
            lblStatusValue.BackColor = StatusAvailableColor;
            lblStatusValue.Visible = false;

            dataGridViewSeat.ClearSelection();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadSeats();
                return;
            }

            List<SeatDTO> filteredList = FilterSeats(searchText);
            dataGridViewSeat.DataSource = filteredList;
            FormatDataGridView();
        }

        private List<SeatDTO> FilterSeats(string searchText)
        {
            if (seatList == null)
                return new List<SeatDTO>();

            switch (cboSearchCategory.SelectedIndex)
            {
                case 0: // Tất cả
                    return seatList.Where(seat =>
                        seat.seatId.ToString().Contains(searchText) ||
                        seat.seatName.ToLower().Contains(searchText) ||
                        GetStatusText(seat.status).ToLower().Contains(searchText)
                    ).ToList();

                case 1: // Mã chỗ
                    return seatList.Where(seat =>
                        seat.seatId.ToString().Contains(searchText)
                    ).ToList();

                case 2: // Tên chỗ
                    return seatList.Where(seat =>
                        seat.seatName.ToLower().Contains(searchText)
                    ).ToList();

                case 3: // Trạng thái
                    return seatList.Where(seat =>
                        GetStatusText(seat.status).ToLower().Contains(searchText)
                    ).ToList();

                default:
                    return seatList;
            }
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void SeatForm_Load(object sender, EventArgs e)
        {
            // Khởi tạo form
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
