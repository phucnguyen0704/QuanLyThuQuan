using QuanLyThuQuan.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuQuan
{
    public partial class ManagerForm : Form //-------------------------------------------- MENU ---------------------------------------------------------------
    {
        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderColor = Color.FromArgb(51, 51, 76);
        private static readonly Color AccentColor = Color.FromArgb(40, 167, 69);
        private static readonly Color ButtonHoverColor = Color.FromArgb(72, 72, 108);

        private string currentUserName = "";

        public ManagerForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        public ManagerForm(string userName)
        {
            InitializeComponent();
            this.currentUserName = userName;
            CustomizeDesign();
            lblWelcome.Text = "Xin chào: " + userName;
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
            //fAccountProfile f = new fAccountProfile();
            //OpenChildForm(f);
        }

        private void btnSeats_Click(object sender, EventArgs e)
        {
            //fSeatManage f = new fSeatManage();
            //OpenChildForm(f);
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
            //fMember f = new fMember();
            //OpenChildForm(f);
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
            //OpenChildForm(f);
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
    }
}