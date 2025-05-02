using QuanLyThuQuan.BLL; // Assuming MemberBLL is in this namespace
using System;
using System.Windows.Forms;

namespace QuanLyThuQuan
{
    public partial class LoginForm : Form
    {
        private readonly MemberBLL memberBLL; // Business logic layer for member operations

        public LoginForm()
        {
            InitializeComponent();
            memberBLL = new MemberBLL(); // Initialize BLL
            this.AutoScaleMode = AutoScaleMode.Font;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(textBoxMemberId.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ ID thành viên và mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure Member ID is numeric
            if (!int.TryParse(textBoxMemberId.Text, out int memberId))
            {
                MessageBox.Show("ID thành viên phải là số!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = textBoxPassword.Text;
            int loginResult = memberBLL.checkLogin(memberId, password, "admin");

            switch (loginResult)
            {
                case 1: // Successful login
                    this.Hide();
                    ManagerForm mainForm = new ManagerForm(); // Replace with actual main form
                    mainForm.ShowDialog(this);
                    mainForm = null;
                    // Clear input fields after successful login
                    textBoxMemberId.Clear();
                    textBoxPassword.Clear();
                    this.Show();
                    break;
                case 2: // Correct ID, wrong password
                    MessageBox.Show("Mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                    break;
                case 3: // Correct ID, correct password, wrong role
                    MessageBox.Show("Không đủ quyền hạn!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                    break;
                case 4: // Wrong ID
                    MessageBox.Show("ID thành viên không tồn tại!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMemberId.Clear();
                    textBoxPassword.Clear();
                    textBoxMemberId.Focus();
                    break;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void textBoxMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and enter
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow enter key to trigger login
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}