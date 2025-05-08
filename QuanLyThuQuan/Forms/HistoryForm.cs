// HistoryForm.cs
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class HistoryForm : Form
    {
        private readonly MemberBLL memberBLL;
        private uint memberId;
        private MemberDTO member;

        // Định nghĩa các hằng số để tránh "magic numbers"
        private const int RESERVATION_TYPE_ONSITE = 1;
        private const int RESERVATION_TYPE_TAKEAWAY = 2;
        private const int RESERVATION_STATUS_ACTIVE = 1;
        private const int RESERVATION_STATUS_RETURNED = 2;
        private const int RESERVATION_STATUS_VIOLATION = 3;

        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderBackColor = Color.FromArgb(51, 51, 76);
        private static readonly Color HeaderForeColor = Color.White;
        private static readonly Color AlternatingRowColor = Color.FromArgb(240, 240, 240);
        private static readonly Color StatusActiveColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
        private static readonly Color StatusReturnedColor = Color.FromArgb(0, 123, 255); // Màu xanh dương
        private static readonly Color StatusViolationColor = Color.FromArgb(220, 53, 69); // Màu đỏ

        public HistoryForm(uint memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
            memberBLL = new MemberBLL();

            // Đăng ký sự kiện CellFormatting
            dgvReservations.CellFormatting += DgvReservations_CellFormatting;
            dgvViolations.CellFormatting += DgvViolations_CellFormatting;
            dgvDevices.CellFormatting += DgvDevices_CellFormatting;
            dgvCheckIns.CellFormatting += DgvCheckIns_CellFormatting;

            // Tải dữ liệu thành viên
            LoadMemberInfo();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu lịch sử
            LoadReservationHistory();
            LoadViolationHistory();
            LoadCheckInHistory();
        }

        private void LoadMemberInfo()
        {
            try
            {
                member = memberBLL.getByID(memberId);
                if (member != null)
                {
                    lblMemberName.Text = member.FullName;
                    lblMemberId.Text = member.MemberId.ToString();
                    lblClass.Text = member.Class;
                    lblDepartment.Text = member.Department;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin thành viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin thành viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReservationHistory()
        {
            try
            {
                DataTable dt = memberBLL.getReservationHistory(memberId);
                dgvReservations.DataSource = dt;
                ConfigureReservationGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadViolationHistory()
        {
            try
            {
                DataTable dt = memberBLL.getViolationHistory(memberId);
                dgvViolations.DataSource = dt;
                ConfigureViolationGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCheckInHistory()
        {
            try
            {
                DataTable dt = memberBLL.getCheckInHistory(memberId);
                dgvCheckIns.DataSource = dt;
                ConfigureCheckInGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử check-in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReservationDetails(uint reservationId)
        {
            try
            {
                DataTable dt = memberBLL.getReservationDetails(reservationId);
                dgvDevices.DataSource = dt;
                ConfigureDeviceGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureReservationGridView()
        {
            // Cấu hình hiển thị cột
            if (dgvReservations.Columns.Count > 0)
            {
                dgvReservations.Columns["reservation_id"].HeaderText = "Mã phiếu mượn";
                dgvReservations.Columns["reservation_type"].HeaderText = "Loại mượn";
                dgvReservations.Columns["reservation_time"].HeaderText = "Thời gian mượn";
                dgvReservations.Columns["due_time"].HeaderText = "Hạn trả";
                dgvReservations.Columns["return_time"].HeaderText = "Thời gian trả";
                dgvReservations.Columns["seat_name"].HeaderText = "Chỗ ngồi";
                dgvReservations.Columns["status"].HeaderText = "Trạng thái";

                // Định dạng ngày giờ
                dgvReservations.Columns["reservation_time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReservations.Columns["due_time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReservations.Columns["return_time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Định dạng bảng
                FormatDataGridView(dgvReservations);
            }
        }

        private void ConfigureViolationGridView()
        {
            // Cấu hình hiển thị cột
            if (dgvViolations.Columns.Count > 0)
            {
                dgvViolations.Columns["violation_id"].HeaderText = "Mã vi phạm";
                dgvViolations.Columns["regulation_name"].HeaderText = "Quy định";
                dgvViolations.Columns["description"].HeaderText = "Mô tả";
                dgvViolations.Columns["reservation_id"].HeaderText = "Mã phiếu mượn";
                dgvViolations.Columns["penalty"].HeaderText = "Hình phạt";
                dgvViolations.Columns["created_at"].HeaderText = "Ngày vi phạm";
                dgvViolations.Columns["due_time"].HeaderText = "Hạn xử lý";
                dgvViolations.Columns["status"].HeaderText = "Trạng thái";

                // Ẩn một số cột không cần thiết
                dgvViolations.Columns["member_id"].Visible = false;
                dgvViolations.Columns["regulation_id"].Visible = false;

                // Định dạng ngày giờ
                dgvViolations.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvViolations.Columns["due_time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Định dạng bảng
                FormatDataGridView(dgvViolations);
            }
        }

        private void ConfigureDeviceGridView()
        {
            // Cấu hình hiển thị cột
            if (dgvDevices.Columns.Count > 0)
            {
                dgvDevices.Columns["reservation_detail_id"].HeaderText = "Mã chi tiết";
                dgvDevices.Columns["device_id"].HeaderText = "Mã thiết bị";
                dgvDevices.Columns["device_name"].HeaderText = "Tên thiết bị";
                dgvDevices.Columns["image"].HeaderText = "Hình ảnh";
                dgvDevices.Columns["status"].HeaderText = "Trạng thái";

                // Định dạng bảng
                FormatDataGridView(dgvDevices);
            }
        }

        private void ConfigureCheckInGridView()
        {
            // Cấu hình hiển thị cột
            if (dgvCheckIns.Columns.Count > 0)
            {
                dgvCheckIns.Columns["log_id"].HeaderText = "Mã log";
                dgvCheckIns.Columns["checkin_time"].HeaderText = "Thời gian check-in";
                dgvCheckIns.Columns["status"].HeaderText = "Trạng thái";
                dgvCheckIns.Columns["created_at"].HeaderText = "Ngày tạo";

                // Định dạng ngày giờ
                dgvCheckIns.Columns["checkin_time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvCheckIns.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Định dạng bảng
                FormatDataGridView(dgvCheckIns);
            }
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowColor;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(230, 230, 230);

            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DgvReservations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReservations.Columns[e.ColumnIndex].Name == "status" && e.Value != null && e.Value != DBNull.Value)
            {
                try
                {
                    int status = Convert.ToInt32(e.Value);
                    e.CellStyle.ForeColor = HeaderForeColor;

                    switch (status)
                    {
                        case RESERVATION_STATUS_ACTIVE:
                            e.Value = "Đang mượn";
                            e.CellStyle.BackColor = StatusActiveColor;
                            break;
                        case RESERVATION_STATUS_RETURNED:
                            e.Value = "Đã trả";
                            e.CellStyle.BackColor = StatusReturnedColor;
                            break;
                        case RESERVATION_STATUS_VIOLATION:
                            e.Value = "Vi phạm";
                            e.CellStyle.BackColor = StatusViolationColor;
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
                catch
                {
                    e.Value = "Không xác định";
                }
            }

            if (dgvReservations.Columns[e.ColumnIndex].Name == "reservation_type" && e.Value != null && e.Value != DBNull.Value)
            {
                try
                {
                    int type = Convert.ToInt32(e.Value);
                    switch (type)
                    {
                        case RESERVATION_TYPE_ONSITE:
                            e.Value = "Tại chỗ";
                            break;
                        case RESERVATION_TYPE_TAKEAWAY:
                            e.Value = "Mang về";
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
                catch
                {
                    e.Value = "Không xác định";
                }
            }
        }

        private void DgvViolations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvViolations.Columns[e.ColumnIndex].Name == "status" && e.Value != null && e.Value != DBNull.Value)
            {
                try
                {
                    int status = Convert.ToInt32(e.Value);
                    switch (status)
                    {
                        case 1:
                            e.Value = "Đang xử lý";
                            break;
                        case 2:
                            e.Value = "Đã xử lý";
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
                catch
                {
                    e.Value = "Không xác định";
                }
            }
        }

        private void DgvDevices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDevices.Columns[e.ColumnIndex].Name == "status" && e.Value != null && e.Value != DBNull.Value)
            {
                try
                {
                    int status = Convert.ToInt32(e.Value);
                    e.CellStyle.ForeColor = HeaderForeColor;

                    switch (status)
                    {
                        case 1:
                            e.Value = "Đang mượn";
                            e.CellStyle.BackColor = StatusActiveColor;
                            break;
                        case 2:
                            e.Value = "Đã trả";
                            e.CellStyle.BackColor = StatusReturnedColor;
                            break;
                        case 3:
                            e.Value = "Vi phạm";
                            e.CellStyle.BackColor = StatusViolationColor;
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
                catch
                {
                    e.Value = "Không xác định";
                }
            }
        }

        private void DgvCheckIns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCheckIns.Columns[e.ColumnIndex].Name == "status" && e.Value != null && e.Value != DBNull.Value)
            {
                try
                {
                    int status = Convert.ToInt32(e.Value);
                    switch (status)
                    {
                        case 1:
                            e.Value = "Hoạt động";
                            break;
                        case 2:
                            e.Value = "Đã xóa";
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
                catch
                {
                    e.Value = "Không xác định";
                }
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvReservations.Rows.Count)
            {
                object cellValue = dgvReservations.Rows[e.RowIndex].Cells["reservation_id"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    try
                    {
                        uint reservationId = Convert.ToUInt32(cellValue);
                        LoadReservationDetails(reservationId);
                        lblSelectedReservation.Text = $"Chi tiết phiếu mượn: {reservationId}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lấy mã phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservationHistory();
            LoadViolationHistory();
            LoadCheckInHistory();
            dgvDevices.DataSource = null;
            lblSelectedReservation.Text = "Chi tiết phiếu mượn: Chưa chọn";
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}