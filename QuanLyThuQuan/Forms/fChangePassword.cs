using System;
using System.Windows.Forms;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using QuanLyThuQuan.Utils;

namespace QuanLyThuQuan.Forms
{
    public partial class fChangePassword : Form
    {
        private int memberId;
        private string role;

        public fChangePassword(int memberId, string role)
        {
            InitializeComponent();
            this.memberId = memberId;
            this.role = role;
        }

        public fChangePassword()
        {
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtXacNhanMatKhau.Text.Trim();

            string result = Checker.ValidatePasswordChange(memberId, oldPass, newPass, confirmPass, role);

            if (result == "VALID")
            {
                MemberBLL bll = new MemberBLL();
                MemberDTO member = bll.getByID(memberId);
                member.Password = newPass;

                if (bll.update(member))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(result, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPassword_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
                
        }

        private void lblOldPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtNewPassword_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtXacNhanMatKhau_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
