// MemberForm.cs
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuQuan.Utils;

namespace QuanLyThuQuan.Forms
{
    public partial class MemberForm : Form //-------------------------------------------- QUẢN LÝ THÀNH VIÊN ---------------------------------------------------------------
    {
        private readonly MemberBLL memberBLL;
        private List<MemberDTO> memberList;
        private bool isEditing = false;
        private MemberDTO currentMember; // Lưu trữ thông tin thành viên hiện tại để khôi phục khi cần

        // Định nghĩa các hằng số để tránh "magic numbers"
        private const int STATUS_ACTIVE = 1;
        private const int STATUS_BLOCKED = 3;

        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderBackColor = Color.FromArgb(51, 51, 76);
        private static readonly Color HeaderForeColor = Color.White;
        private static readonly Color AlternatingRowColor = Color.FromArgb(240, 240, 240);
        private static readonly Color StatusActiveColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
        private static readonly Color StatusBlockedColor = Color.FromArgb(220, 53, 69); // Màu đỏ

        public MemberForm()
        {
            InitializeComponent();
            memberBLL = new MemberBLL();

            // Đăng ký sự kiện CellFormatting
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            // Khởi tạo các ComboBox trước khi tải dữ liệu
            InitializeComboBoxes();

            // Tải dữ liệu
            LoadMembers();

            // Ẩn nút Lưu khi khởi động form
            btnSave.Visible = false;
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
                    case "Hoạt động":
                        e.CellStyle.BackColor = StatusActiveColor;
                        break;
                    case "Bị khóa":
                        e.CellStyle.BackColor = StatusBlockedColor;
                        break;
                }
            }
        }

        private void InitializeComboBoxes()
        {
            SetupStatusComboBox();
            SetupRoleComboBox();
            SetupSearchCategoryComboBox();
        }

        private void LoadMembers()
        {
            try
            {
                memberList = memberBLL.getAll();

                if (memberList == null)
                {
                    MessageBox.Show("Không thể tải dữ liệu thông tin thành viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = CreateDataTableFromMembers(memberList);
                dataGridView1.DataSource = dt;
                ConfigureDataGridViewColumns();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thông tin thành viên: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateDataTableFromMembers(List<MemberDTO> members)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MemberId", typeof(int));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Birthday", typeof(DateTime));
            dt.Columns.Add("PhoneNumber", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Major", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Role", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("CreatedAt", typeof(DateTime));

            foreach (MemberDTO member in members)
            {
                dt.Rows.Add(
                    member.MemberId,
                    member.FullName,
                    member.Birthday,
                    member.PhoneNumber,
                    member.Email,
                    member.Department,
                    member.Major,
                    member.Class,
                    member.Role,
                    GetStatusText(member.Status),
                    member.CreatedAt
                );
            }

            return dt;
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridView1.Columns["MemberId"].HeaderText = "Mã thành viên";
            dataGridView1.Columns["FullName"].HeaderText = "Họ và tên";
            dataGridView1.Columns["Birthday"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["Department"].HeaderText = "Khoa";
            dataGridView1.Columns["Major"].HeaderText = "Chuyên ngành";
            dataGridView1.Columns["Class"].HeaderText = "Lớp";
            dataGridView1.Columns["Role"].HeaderText = "Vai trò";
            dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Ngày tạo";

            // Đảm bảo hiển thị tất cả các cột
            dataGridView1.Columns["Department"].Visible = true;
            dataGridView1.Columns["Major"].Visible = true;
            dataGridView1.Columns["Class"].Visible = true;

            dataGridView1.Columns["Birthday"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case STATUS_ACTIVE:
                    return "Hoạt động";
                case STATUS_BLOCKED:
                    return "Bị khóa";
                default:
                    return "Không xác định";
            }
        }

        private int GetStatusValue(string statusText)
        {
            switch (statusText)
            {
                case "Hoạt động":
                    return STATUS_ACTIVE;
                case "Bị khóa":
                    return STATUS_BLOCKED;
                default:
                    return STATUS_ACTIVE;
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
            cboStatus.Items.AddRange(new string[] { "Hoạt động", "Bị khóa" });
            cboStatus.SelectedIndex = 0;
        }

        private void SetupRoleComboBox()
        {
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "member", "admin" });
            cboRole.SelectedIndex = 0;
        }

        private void SetupSearchCategoryComboBox()
        {
            cboSearchCategory.Items.Clear();
            cboSearchCategory.Items.AddRange(new string[] {
                "Tất cả",
                "Mã thành viên",
                "Họ và tên",
                "Số điện thoại",
                "Email",
                "Khoa",
                "Chuyên ngành",
                "Lớp",
                "Vai trò",
                "Trạng thái"
            });
            cboSearchCategory.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            try
            {
                int memberId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberId"].Value);
                MemberDTO selectedMember = memberList.FirstOrDefault(m => m.MemberId == memberId);

                if (selectedMember != null)
                {
                    // Lưu thành viên hiện tại để có thể khôi phục khi cần
                    currentMember = selectedMember;

                    PopulateFormFields(selectedMember);
                    SetButtonsForViewMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFormFields(MemberDTO member)
        {
            txtMemberId.Text = member.MemberId.ToString();
            txtFullName.Text = member.FullName;
            dtpBirthday.Value = member.Birthday;
            txtPhoneNumber.Text = member.PhoneNumber;
            txtEmail.Text = member.Email;
            txtDepartment.Text = member.Department ?? "";
            txtMajor.Text = member.Major ?? "";
            txtClass.Text = member.Class ?? "";
            txtPassword.Text = member.Password;

            // Thiết lập vai trò
            if (member.Role.ToLower() == "admin")
            {
                cboRole.SelectedIndex = 1;
            }
            else
            {
                cboRole.SelectedIndex = 0; // Mặc định là "member"
            }

            // Thiết lập trạng thái
            cboStatus.SelectedIndex = member.Status == STATUS_ACTIVE ? 0 : 1;

            dtpCreatedAt.Value = member.CreatedAt;
        }

        private void SetButtonsForViewMode()
        {
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            isEditing = false;
        }

        private void SetButtonsForEditMode()
        {
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            currentMember = null; // Xóa thành viên hiện tại khi thêm mới
            isEditing = false;
            SetButtonsForEditMode();

            // Cho phép nhập ID khi thêm mới
            txtMemberId.Enabled = true;

            // Đảm bảo trường mật khẩu có thể nhập khi thêm mới
            txtPassword.Enabled = true;

            txtMemberId.Focus(); // Focus vào trường ID đầu tiên
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                MessageBox.Show("Vui lòng chọn thành viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            SetButtonsForEditMode();

            // Không cho phép chỉnh sửa ID khi cập nhật
            txtMemberId.Enabled = false;

            // Vô hiệu hóa trường mật khẩu khi sửa
            txtPassword.Enabled = false;

            txtFullName.Focus(); // Focus vào trường họ tên thay vì ID
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                MemberDTO member = GetMemberFromForm();
                bool result;

                if (isEditing)
                {
                    result = memberBLL.update(member);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật thông tin thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại danh sách sau khi sửa
                        LoadMembers();

                        // Cập nhật lại thông tin hiển thị
                        currentMember = member;
                        PopulateFormFields(member);

                        SetButtonsForViewMode();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thành viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        result = memberBLL.create(member);
                        if (result)
                        {
                            MessageBox.Show("Thêm thông tin thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại danh sách sau khi thêm
                            LoadMembers();
                            ClearForm();
                            SetButtonsForViewMode();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thông tin thành viên thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm thành viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra Member ID
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            // Kiểm tra ID có phải là số nguyên hợp lệ không
            if (!int.TryParse(txtMemberId.Text, out int memberId) || memberId <= 0)
            {
                MessageBox.Show("Mã thành viên phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }


            // Kiểm tra ID có bị trùng không (chỉ khi thêm mới)
            if (!isEditing)
            {
                if (Checker.IsExitsMemberId(uint.Parse(txtMemberId.Text)))
                {
                    MessageBox.Show("Mã thành viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMemberId.Focus();
                    return false;
                }
            }

            // Kiểm tra Full Name
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            // Kiểm tra Phone Number
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return false;
            }

            if (Checker.IsExistPhone(txtPhoneNumber.Text) != UInt32.Parse(txtMemberId.Text) && Checker.IsExistPhone(txtPhoneNumber.Text) != 0)
            {
                MessageBox.Show("Sdt thành viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            //if (!Checker.IsValidPhone(txtPhoneNumber.Text))
            if (!int.TryParse(txtPhoneNumber.Text, out int phone) && phone > 0)
            {
                MessageBox.Show("Sdt thành viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            // Kiểm tra Email
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (Checker.IsExistEmail(txtEmail.Text) != UInt32.Parse(txtMemberId.Text) && Checker.IsExistEmail(txtEmail.Text) != 0)
            {
                MessageBox.Show("Email thành viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            if (!Checker.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email thành viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            // Kiểm tra Department
            if (string.IsNullOrEmpty(txtDepartment.Text))
            {
                MessageBox.Show("Vui lòng nhập khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartment.Focus();
                return false;
            }

            // Kiểm tra Major
            if (string.IsNullOrEmpty(txtMajor.Text))
            {
                MessageBox.Show("Vui lòng nhập chuyên ngành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMajor.Focus();
                return false;
            }

            // Kiểm tra Class
            if (string.IsNullOrEmpty(txtClass.Text))
            {
                MessageBox.Show("Vui lòng nhập lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClass.Focus();
                return false;
            }

            // Kiểm tra Password (chỉ khi thêm mới)
            if (!isEditing && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (!Checker.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu tối thiểu 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            return true;
        }

        private MemberDTO GetMemberFromForm()
        {
            // Khi đang sửa, sử dụng ID của thành viên hiện tại
            uint memberId = isEditing ? currentMember.MemberId : uint.Parse(txtMemberId.Text);
            string fullName = txtFullName.Text.Trim();
            DateTime birthday = dtpBirthday.Value;
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Xử lý các trường có thể null
            string department = txtDepartment.Text.Trim();
            string major = txtMajor.Text.Trim();
            string memberClass = txtClass.Text.Trim();

            // Nếu đang sửa, giữ nguyên mật khẩu cũ
            string password = isEditing ? currentMember.Password : txtPassword.Text.Trim();

            string role = cboRole.SelectedIndex == 1 ? "admin" : "member";

            int status = cboStatus.SelectedIndex == 0 ? STATUS_ACTIVE : STATUS_BLOCKED;
            DateTime createdAt = isEditing ? currentMember.CreatedAt : DateTime.Now;

            return new MemberDTO
            {
                MemberId = memberId,
                FullName = fullName,
                Birthday = birthday,
                PhoneNumber = phoneNumber,
                Email = email,
                Department = department,
                Major = major,
                Class = memberClass,
                Password = password,
                Role = role,
                Status = status,
                CreatedAt = createdAt
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMemberId.Text))
                {
                    MessageBox.Show("Vui lòng chọn thành viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                uint memberId = uint.Parse(txtMemberId.Text);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = memberBLL.delete(memberId);
                    if (success)
                    {
                        MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMembers();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thành viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            currentMember = null; // Xóa thành viên hiện tại khi làm mới form
            SetButtonsForViewMode();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                MessageBox.Show("Vui lòng chọn thành viên để xem lịch sử!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            uint memberId = uint.Parse(txtMemberId.Text);

            // Mở form lịch sử thành viên
            HistoryForm historyForm = new HistoryForm(memberId);
            historyForm.ShowDialog();
        }

        private void ClearForm()
        {
            txtMemberId.Text = "";
            txtMemberId.Enabled = true; // Đảm bảo trường ID được bật
            txtFullName.Text = "";
            dtpBirthday.Value = DateTime.Now;
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtDepartment.Text = "";
            txtMajor.Text = "";
            txtClass.Text = "";
            txtPassword.Text = "";
            txtPassword.Enabled = true; // Đảm bảo trường mật khẩu được bật lại
            cboRole.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            dtpCreatedAt.Value = DateTime.Now;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadMembers();
                return;
            }

            List<MemberDTO> filteredList = FilterMembers(searchText);
            DisplayFilteredMembers(filteredList);
        }

        private List<MemberDTO> FilterMembers(string searchText)
        {
            if (memberList == null)
                return new List<MemberDTO>();

            switch (cboSearchCategory.SelectedIndex)
            {
                case 0: // Tất cả
                    return memberList.Where(member =>
                        member.MemberId.ToString().Contains(searchText) ||
                        member.FullName.ToLower().Contains(searchText) ||
                        member.PhoneNumber?.ToLower().Contains(searchText) == true ||
                        member.Email.ToLower().Contains(searchText) ||
                        member.Department?.ToLower().Contains(searchText) == true ||
                        member.Major?.ToLower().Contains(searchText) == true ||
                        member.Class?.ToLower().Contains(searchText) == true ||
                        member.Role.ToLower().Contains(searchText) ||
                        GetStatusText(member.Status).ToLower().Contains(searchText)
                    ).ToList();
                case 1: // Mã thành viên
                    return memberList.Where(member =>
                        member.MemberId.ToString().Contains(searchText)
                    ).ToList();
                case 2: // Họ và tên
                    return memberList.Where(member =>
                        member.FullName.ToLower().Contains(searchText)
                    ).ToList();
                case 3: // Số điện thoại
                    return memberList.Where(member =>
                        member.PhoneNumber?.ToLower().Contains(searchText) == true
                    ).ToList();
                case 4: // Email
                    return memberList.Where(member =>
                        member.Email.ToLower().Contains(searchText)
                    ).ToList();
                case 5: // Khoa
                    return memberList.Where(member =>
                        member.Department?.ToLower().Contains(searchText) == true
                    ).ToList();
                case 6: // Chuyên ngành
                    return memberList.Where(member =>
                        member.Major?.ToLower().Contains(searchText) == true
                    ).ToList();
                case 7: // Lớp
                    return memberList.Where(member =>
                        member.Class?.ToLower().Contains(searchText) == true
                    ).ToList();
                case 8: // Vai trò
                    return memberList.Where(member =>
                        member.Role.ToLower().Contains(searchText)
                    ).ToList();
                case 9: // Trạng thái
                    return memberList.Where(member =>
                        GetStatusText(member.Status).ToLower().Contains(searchText)
                    ).ToList();
                default:
                    return memberList;
            }
        }

        private void DisplayFilteredMembers(List<MemberDTO> filteredList)
        {
            DataTable dt = CreateDataTableFromMembers(filteredList);
            dataGridView1.DataSource = dt;
            FormatDataGridView();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMemberId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}