using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using QuanLyThuQuan.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class LogForm : Form
    {
        private readonly LogDAL logDAL = new LogDAL();
        private readonly LogBLL logBLL = new LogBLL();
        private List<LogDTO> logList;

        // Định nghĩa các hằng số cho trạng thái
        private const int STATUS_ACTIVE = 1;
        private const int STATUS_DELETED = 2;

        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderBackColor = Color.FromArgb(51, 51, 76);
        private static readonly Color HeaderForeColor = Color.White;
        private static readonly Color AlternatingRowColor = Color.FromArgb(240, 240, 240);
        private static readonly Color StatusActiveColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
        private static readonly Color StatusDeletedColor = Color.FromArgb(220, 53, 69); // Màu đỏ

        public LogForm()
        {
            InitializeComponent();

            // Đăng ký sự kiện CellFormatting
            dataGridViewLog.CellFormatting += DataGridViewLog_CellFormatting;

            // Thiết lập các ComboBox trước khi tải dữ liệu
            SetupSearchCategoryComboBox();

            // Tải dữ liệu
            LoadLogs();
        }

        private void DataGridViewLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Xử lý cột Status
            if (dataGridViewLog.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                int status;
                if (int.TryParse(e.Value.ToString(), out status))
                {
                    e.CellStyle.ForeColor = HeaderForeColor;

                    switch (status)
                    {
                        case STATUS_ACTIVE:
                            e.Value = "Đã ghi nhận";
                            e.CellStyle.BackColor = StatusActiveColor;
                            break;
                        case STATUS_DELETED:
                            e.Value = "Đã xóa";
                            e.CellStyle.BackColor = StatusDeletedColor;
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
            }

            // Xử lý cột CheckInTime để hiển thị định dạng thời gian
            if (dataGridViewLog.Columns[e.ColumnIndex].Name == "CheckInTime" && e.Value != null)
            {
                if (e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }

            // Xử lý cột CreatedAt để hiển thị định dạng thời gian
            if (dataGridViewLog.Columns[e.ColumnIndex].Name == "CreatedAt" && e.Value != null)
            {
                if (e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        public void LoadLogs()
        {
            try
            {
                logList = logDAL.getAll();

                if (logList == null)
                {
                    MessageBox.Show("Không thể tải dữ liệu nhật ký.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = CreateDataTableFromLogs(logList);
                dataGridViewLog.DataSource = dt;
                ConfigureDataGridViewColumns();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nhật ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateDataTableFromLogs(List<LogDTO> logs)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("LogId", typeof(int));
            dt.Columns.Add("MemberId", typeof(string));
            dt.Columns.Add("CheckInTime", typeof(DateTime));
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("CreatedAt", typeof(DateTime));

            foreach (LogDTO log in logs)
            {
                dt.Rows.Add(
                    log.logId,
                    log.memberId,
                    log.checkinTime,
                    log.status,
                    log.createdAt
                );
            }

            return dt;
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridViewLog.Columns["LogId"].HeaderText = "Mã nhật ký";
            dataGridViewLog.Columns["MemberId"].HeaderText = "Mã sinh viên";
            dataGridViewLog.Columns["CheckInTime"].HeaderText = "Thời gian check-in";
            dataGridViewLog.Columns["Status"].HeaderText = "Trạng thái";
            dataGridViewLog.Columns["CreatedAt"].HeaderText = "Ngày tạo";

            // Định dạng thời gian
            dataGridViewLog.Columns["CheckInTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridViewLog.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void FormatDataGridView()
        {
            dataGridViewLog.EnableHeadersVisualStyles = false;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewLog.ColumnHeadersHeight = 40;

            dataGridViewLog.RowTemplate.Height = 40;
            dataGridViewLog.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridViewLog.AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowColor;

            dataGridViewLog.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewLog.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void dataGridViewLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewLog.Rows.Count)
                return;

            try
            {
                int logId = Convert.ToInt32(dataGridViewLog.Rows[e.RowIndex].Cells["LogId"].Value);
                LogDTO selectedLog = logList.FirstOrDefault(r => r.logId == logId);

                if (selectedLog != null)
                {
                    PopulateFormFields(selectedLog);

                    // Kích hoạt nút Delete
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFormFields(LogDTO log)
        {
            txtLogID.Text = log.logId.ToString();
            txtMemberID.Text = log.memberId;

            lblCheckInTimeValue.Text = log.checkinTime.ToString("dd/MM/yyyy HH:mm");

            // Hiển thị trạng thái
            string status = log.status == STATUS_ACTIVE ? "Đã ghi nhận" : "Đã xóa";
            lblStatusValue.Text = status;

            // Đổi màu cho trạng thái
            if (log.status == STATUS_ACTIVE)
                lblStatusValue.ForeColor = StatusActiveColor;
            else
                lblStatusValue.ForeColor = StatusDeletedColor;

            lblCreatedAtValue.Text = log.createdAt.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMemberID.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMemberID.Focus();
                    return;
                }

                if (!Checker.IsExitsMemberId(Int32.Parse(txtMemberID.Text)))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMemberID.Focus();
                    return;
                }

                // Lấy thời gian hiện tại cho check-in
                DateTime checkInTime = DateTime.Now;

                string memberId = txtMemberID.Text;

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn ghi nhận sinh viên {memberId} vào danh sách với thời gian {checkInTime:dd/MM/yyyy HH:mm}?",
                    "Ghi nhận nhật ký",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string error = logBLL.create(memberId, checkInTime);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Ghi nhận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLogs();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLogID.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhật ký cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int logId = int.Parse(txtLogID.Text);
                string memberId = txtMemberID.Text;

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhật ký của sinh viên {memberId}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    string error = logBLL.delete(logId);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Xóa nhật ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLogs();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void ClearForm()
        {
            txtLogID.Text = "";
            txtMemberID.Text = "";
            lblCheckInTimeValue.Text = "";
            lblStatusValue.Text = "";
            lblCreatedAtValue.Text = "";

            // Vô hiệu hóa nút Delete
            btnDelete.Enabled = false;

            // Đặt focus vào txtMemberID
            txtMemberID.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadLogs();
                return;
            }

            List<LogDTO> filteredList = FilterLogs(searchText);
            DisplayFilteredLogs(filteredList);
        }

        private List<LogDTO> FilterLogs(string searchText)
        {
            if (logList == null)
                return new List<LogDTO>();

            switch (cboSearchCategory.SelectedIndex)
            {
                case 0: // Tất cả
                    return logList.Where(log =>
                        log.logId.ToString().Contains(searchText) ||
                        log.memberId.ToLower().Contains(searchText)
                    ).ToList();
                case 1: // Mã nhật ký
                    return logList.Where(log =>
                        log.logId.ToString().Contains(searchText)
                    ).ToList();
                case 2: // Mã sinh viên
                    return logList.Where(log =>
                        log.memberId.ToLower().Contains(searchText)
                    ).ToList();
                default:
                    return logList;
            }
        }

        private void DisplayFilteredLogs(List<LogDTO> filteredList)
        {
            DataTable dt = CreateDataTableFromLogs(filteredList);
            dataGridViewLog.DataSource = dt;
            FormatDataGridView();
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void SetupSearchCategoryComboBox()
        {
            cboSearchCategory.Items.Clear();
            cboSearchCategory.Items.AddRange(new string[] {
                "Tất cả",
                "Mã nhật ký",
                "Mã sinh viên"
            });
            cboSearchCategory.SelectedIndex = 0;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            SetupSearchCategoryComboBox();
            ClearForm();
        }

        private void txtLogID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}