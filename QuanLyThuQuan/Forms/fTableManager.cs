
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.Forms;

namespace QuanLyThuQuan
{
    public partial class fTableManager : Form //-------------------------------------------- MENU ---------------------------------------------------------------
    {
        //private Account loginAccount;

        //public Account LoginAccount { get => loginAccount; set => loginAccount = value; }

        public fTableManager()
        {
            InitializeComponent();
            LoadMemberChart();
            LoadDeviceChart();
            LoadReservationChart();
            LoadSeatChart();
        }

        //public fTableManager(Account loginAccount)
        //{
        //    InitializeComponent();
        //    this.LoginAccount = loginAccount;
        //    lblWelcome.Text = "Welcome:  " + loginAccount.UserName;
        //}

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBookManage f = new fBookManage();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStaffManage f = new fStaffManage();
            f.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReaderManage f = new fReaderManage();
            f.ShowDialog();
        }

        private void thẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCardReaderManage f = new fCardReaderManage();
            f.ShowDialog();
        }

        private void theoDõiMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBorrow_ReturnBook f = new fBorrow_ReturnBook();
            f.ShowDialog();
        }

        private void traCứuSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSearchBook f = new fSearchBook();
            f.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStatistical f = new fStatistical();
            f.ShowDialog();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fContact f = new fContact();
            f.ShowDialog();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fGuideToUse f = new fGuideToUse();
            f.ShowDialog();
        }

        private void chỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSeatManage f = new fSeatManage();
            f.ShowDialog();
        }

        private void thiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceForm f = new DeviceForm();
            f.ShowDialog();
        }

        private void quyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fRegulationManage f = new fRegulationManage();
            f.ShowDialog();
        }

        private void thànhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMember f = new fMember();
            f.ShowDialog();
        }

        private void NhậtKíVàoThưQuánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLogManage f = new fLogManage();
            f.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void LoadMemberChart()
        {
            memberChart.Series.Clear();
            memberChart.Titles.Clear();

            memberChart.Titles.Add("Biểu đồ trạng thái thành viên");

            var dataTable = new StatisticalBLL().getMemberStatisticals();

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

        private void LoadDeviceChart()
        {
            deviceChart.Series.Clear();
            deviceChart.Titles.Clear();

            deviceChart.Titles.Add("Biểu đồ thiết bị đang hoạt động");
            var count = new StatisticalBLL().getDeviceStatisticals();
            Series series = new Series
            {
                Name = "Đang hoạt động",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true, // Hiển thị số trên cột
                Color = System.Drawing.Color.CadetBlue // Đặt màu xanh cho cột
            };

            series.Points.AddXY("", count);

            deviceChart.Series.Add(series);
            deviceChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; // Loại bỏ lưới trục X
            deviceChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false; // Loại bỏ lưới trục Y
            deviceChart.ChartAreas[0].BackColor = System.Drawing.Color.Transparent; // Nền trong suốt
            deviceChart.ChartAreas[0].AxisX.LineWidth = 0; // Ẩn đường trục X
            deviceChart.ChartAreas[0].AxisY.LineWidth = 0; // Ẩn đường trục Y
            deviceChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False; // Ẩn nhãn và số trên trục X
            deviceChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False; // Ẩn nhãn và số trên trục Y
        }

        private void LoadSeatChart()
        {
            seatChart.Series.Clear();
            seatChart.Titles.Clear();

            seatChart.Titles.Add("Biểu đồ trạng thái chỗ");

            var dataTable = new StatisticalBLL().getSeatStatisticals();

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
                if (status == 2) { continue; }

                switch (status)
                {
                    case 1: label = "Còn trống"; break;
                    case 3: label = "Đã được đặt"; break;
                    default: label = ""; break;
                }
                
                // Thêm điểm dữ liệu và gán màu
                int pointIndex = series.Points.AddXY(label, count);
                switch (status)
                {
                    case 1:
                        series.Points[pointIndex].Color = System.Drawing.Color.CornflowerBlue; 
                        break;
                    case 2:
                        series.Points[pointIndex].Color = System.Drawing.Color.Orange; 
                        break;
                    case 3:
                        series.Points[pointIndex].Color = System.Drawing.Color.Red; 
                        break;
                }

                // Tắt hiển thị chú thích (legend) để ẩn "Series1"
                seatChart.Legends[0].Enabled = false;
            }



            seatChart.Series.Add(series);
        }

        private void LoadReservationChart()
        {

            reservationChart.Series.Clear();
            reservationChart.Titles.Clear();

            reservationChart.Titles.Add("Biểu đồ trạng thái phiếu mượn");

            var dataTable = new StatisticalBLL().getReservationStatisticals();

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
                    case 3: label = "Vi phạm"; break;
                    case 1: label = "Đang mượn"; break;
                    case 2: label = "Đã trả"; break;
                    default: label = ""; break;
                }

                series.Points.AddXY(label, count);
            }

            reservationChart.Series.Add(series);
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }
    }
}
