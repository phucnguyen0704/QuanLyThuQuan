// ManagerForm.cs
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using QuanLyThuQuan.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyThuQuan
{
    public partial class ManagerForm : Form //-------------------------------------------- MENU ---------------------------------------------------------------
    {
        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderColor = Color.FromArgb(51, 51, 76);
        private static readonly Color AccentColor = Color.FromArgb(40, 167, 69);
        private static readonly Color ButtonHoverColor = Color.FromArgb(72, 72, 108);
        private MemberDTO member = new MemberDTO();

        public ManagerForm()
        {
            InitializeComponent();
            CustomizeDesign();
            LoadAllCharts();
        }

        // Update the constructor to create an instance of MemberBLL
        private readonly MemberBLL memberBLL = new MemberBLL();

        public ManagerForm(int memberId)
        {
            InitializeComponent();
            this.member = memberBLL.getByID(memberId); // Use the instance of MemberBLL
            if (member == null)
            {
                MessageBox.Show("Không tìm thấy thông tin thành viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CustomizeDesign();
            lblWelcome.Text = "Xin chào: " + this.member.FullName;
            LoadAllCharts();
        }

        private void CustomizeDesign()
        {
            // Đăng ký sự kiện cho các nút menu
            foreach (Control control in panelMenu.Controls)
            {
                if (control is Button)
                {
                    control.MouseEnter += Button_MouseEnter;
                    control.MouseLeave += Button_MouseLeave;
                }
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = ButtonHoverColor;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = HeaderColor;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(this.member.MemberId);
            OpenChildForm(changePasswordForm);
            this.Close();
        }

        private void btnSeats_Click(object sender, EventArgs e)
        {
            SeatForm f = new SeatForm();
            OpenChildForm(f);
        }

        private void btnDevices_Click(object sender, EventArgs e)
        {
            DeviceForm f = new DeviceForm();
            OpenChildForm(f);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            ReservationForm f = new ReservationForm();
            OpenChildForm(f);
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            MemberForm f = new MemberForm();
            OpenChildForm(f);
        }

        private void btnRegulations_Click(object sender, EventArgs e)
        {
            //fRegulationManage f = new fRegulationManage();
            //OpenChildForm(f);
        }

        private void btnViolations_Click(object sender, EventArgs e)
        {
            //fRegulationManage f = new fRegulationManage();
            //OpenChildForm(f);
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            //fLogManage f = new fLogManage();
            LogForm f = new LogForm();
            OpenChildForm(f);
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            // Hiển thị thời gian hiện tại
            timerClock.Start();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        // Phương thức tải tất cả các biểu đồ
        private void LoadAllCharts()
        {
            try
            {
                LoadMemberChart();
                LoadDeviceChart();
                LoadReservationChart();
                LoadSeatChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức tải biểu đồ thành viên
        private void LoadMemberChart()
        {
            memberChart.Series.Clear();
            memberChart.Titles.Clear();

            memberChart.Titles.Add("Biểu đồ trạng thái thành viên");

            // Giả lập dữ liệu - thay thế bằng dữ liệu thực từ StatisticalBLL
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("status", typeof(int));
            dataTable.Columns.Add("count", typeof(int));

            dataTable.Rows.Add(1, 25); // Hoạt động
            dataTable.Rows.Add(2, 5);  // Đã xóa
            dataTable.Rows.Add(3, 3);  // Bị khóa

            // Thử lấy dữ liệu từ BLL nếu có
            try
            {
                // Nếu có StatisticalBLL, sử dụng nó
                // dataTable = new StatisticalBLL().getMemberStatisticals();
            }
            catch { }

            Series series = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dataTable.Rows)
            {
                int status = Convert.ToInt32(row["status"]);
                int count = Convert.ToInt32(row["count"]);
                string label = "";

                switch (status)
                {
                    case 1: label = "Đang hoạt động"; break;
                    case 2: label = "Đã xóa"; break;
                    case 3: label = "Đang bị khóa"; break;
                    default: label = "Không rõ"; break;
                }

                series.Points.AddXY(label, count);
            }

            memberChart.Series.Add(series);
        }

        // Phương thức tải biểu đồ thiết bị
        private void LoadDeviceChart()
        {
            deviceChart.Series.Clear();
            deviceChart.Titles.Clear();

            deviceChart.Titles.Add("Biểu đồ thiết bị đang hoạt động");

            // Giả lập dữ liệu - thay thế bằng dữ liệu thực từ StatisticalBLL
            int count = 42;

            // Thử lấy dữ liệu từ BLL nếu có
            try
            {
                // Nếu có StatisticalBLL, sử dụng nó
                // count = new StatisticalBLL().getDeviceStatisticals();
            }
            catch { }

            Series series = new Series
            {
                Name = "Đang hoạt động",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.CadetBlue
            };

            series.Points.AddXY("", count);

            deviceChart.Series.Add(series);
            deviceChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            deviceChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            deviceChart.ChartAreas[0].BackColor = Color.Transparent;
            deviceChart.ChartAreas[0].AxisX.LineWidth = 0;
            deviceChart.ChartAreas[0].AxisY.LineWidth = 0;
            deviceChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            deviceChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
        }

        // Phương thức tải biểu đồ chỗ ngồi
        private void LoadSeatChart()
        {
            seatChart.Series.Clear();
            seatChart.Titles.Clear();

            seatChart.Titles.Add("Biểu đồ trạng thái chỗ");

            // Giả lập dữ liệu - thay thế bằng dữ liệu thực từ StatisticalBLL
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("status", typeof(int));
            dataTable.Columns.Add("count", typeof(int));

            dataTable.Rows.Add(1, 15); // Còn trống
            dataTable.Rows.Add(3, 8);  // Đã được đặt

            // Thử lấy dữ liệu từ BLL nếu có
            try
            {
                // Nếu có StatisticalBLL, sử dụng nó
                // dataTable = new StatisticalBLL().getSeatStatisticals();
            }
            catch { }

            Series series = new Series
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dataTable.Rows)
            {
                int status = Convert.ToInt32(row["status"]);
                int count = Convert.ToInt32(row["count"]);
                string label = "";

                // Bỏ qua trạng thái đã xóa
                if (status == 2) continue;

                switch (status)
                {
                    case 1: label = "Còn trống"; break;
                    case 3: label = "Đã được đặt"; break;
                    default: label = "Không rõ"; break;
                }

                int pointIndex = series.Points.AddXY(label, count);

                // Gán màu cho từng cột
                switch (status)
                {
                    case 1:
                        series.Points[pointIndex].Color = Color.CornflowerBlue;
                        break;
                    case 3:
                        series.Points[pointIndex].Color = Color.Red;
                        break;
                }
            }

            seatChart.Series.Add(series);
            seatChart.Legends[0].Enabled = false;
        }

        // Phương thức tải biểu đồ phiếu mượn
        private void LoadReservationChart()
        {
            reservationChart.Series.Clear();
            reservationChart.Titles.Clear();

            reservationChart.Titles.Add("Biểu đồ trạng thái phiếu mượn");

            // Giả lập dữ liệu - thay thế bằng dữ liệu thực từ StatisticalBLL
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("status", typeof(int));
            dataTable.Columns.Add("count", typeof(int));

            dataTable.Rows.Add(1, 12); // Đang mượn
            dataTable.Rows.Add(2, 30); // Đã trả
            dataTable.Rows.Add(3, 5);  // Vi phạm

            // Thử lấy dữ liệu từ BLL nếu có
            try
            {
                // Nếu có StatisticalBLL, sử dụng nó
                // dataTable = new StatisticalBLL().getReservationStatisticals();
            }
            catch { }

            Series series = new Series
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dataTable.Rows)
            {
                int status = Convert.ToInt32(row["status"]);
                int count = Convert.ToInt32(row["count"]);
                string label = "";

                switch (status)
                {
                    case 1: label = "Đang mượn"; break;
                    case 2: label = "Đã trả"; break;
                    case 3: label = "Vi phạm"; break;
                    default: label = "Không rõ"; break;
                }

                series.Points.AddXY(label, count);
            }

            reservationChart.Series.Add(series);
        }

        private void memberChart_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi click vào biểu đồ thành viên
        }

        private void deviceChart_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi click vào biểu đồ thiết bị
        }

        private void reservationChart_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi click vào biểu đồ phiếu mượn
        }

        private void seatChart_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi click vào biểu đồ chỗ ngồi
        }
    }
}