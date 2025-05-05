using QuanLyThuQuan.BLL;
using QuanLyThuQuan.Utils;
using System;
using System.Windows.Forms;

namespace QuanLyThuQuan
{
    public partial class ChangePasswordForm : Form
    {
        private readonly MemberBLL memberBLL;
        private int memberId;

        public ChangePasswordForm(int memberId)
        {
            InitializeComponent();
            memberBLL = new MemberBLL();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.memberId = memberId;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(textBoxOldPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxNewPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Checker.IsValidPassword(textBoxNewPassword.Text))
            {
                MessageBox.Show("Mật khẩu tối thiểu 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxConfirmPassword.Clear();
                textBoxConfirmPassword.Focus();
                return;
            }

            // Check if new password and confirm password match
            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxConfirmPassword.Clear();
                textBoxConfirmPassword.Focus();
                return;
            }

            string oldPassword = textBoxOldPassword.Text;
            string newPassword = textBoxNewPassword.Text;

            // Verify old password is correct
            int loginResult = memberBLL.checkLogin(memberId, oldPassword, "admin");

            if (loginResult == 1 || loginResult == 3) // Correct ID and password (regardless of role)
            {
                // Change password logic
                bool success = memberBLL.changePassword(memberId, newPassword);

                if (success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Clear all fields
                    textBoxOldPassword.Clear();
                    textBoxNewPassword.Clear();
                    textBoxConfirmPassword.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (loginResult == 2) // Correct ID, wrong password
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOldPassword.Clear();
                textBoxOldPassword.Focus();
            }
            else // Wrong ID (shouldn't happen as we're passing the ID)
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow enter key to trigger password change
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonChangePassword.PerformClick();
            }
        }

        private void textBoxOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow enter key to move to next field
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBoxNewPassword.Focus();
            }
        }

        private void textBoxConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow enter key to trigger password change
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonChangePassword.PerformClick();
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            // Any initialization code can go here
        }

        private void panelChangePassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxOldPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}