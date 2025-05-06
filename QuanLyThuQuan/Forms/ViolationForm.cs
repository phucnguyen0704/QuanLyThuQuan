using DocumentFormat.OpenXml.Wordprocessing;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace QuanLyThuQuan.Forms
{
    public partial class ViolationForm : Form
    {
        private bool isAdding = false;

        // Trạng thái xử lý vi phạm
        private const int Dang_Xu_Ly = 1;
        private const int Da_Xu_Ly = 2;

        public ViolationForm()
        {
            InitializeComponent();
            init();
        }

        private void init() 
        {
            initDataGridView();
            loadData(ViolationBLL.Instance.GetAll());

            cbTieuChiTrangThai.SelectedIndex = 0; // 0: Tất cả
        }

        private void switchToViewMode()
        {
            bool hasDueTime = !string.IsNullOrWhiteSpace(cbThoiGianKhoa.Text);
            bool hasPenalty = !string.IsNullOrWhiteSpace(txtTienBoiThuong.Text);

            // Xác định hình thức xử lý dựa vào dữ liệu đã load
            if (hasDueTime && hasPenalty)
            {
                cbHthucXuLy.Text = "Khóa tài khoản & Bồi thường";
                flpnThoiGianKhoa.Visible = true;
                flpnBoiThuong.Visible = true;
            }
            else if (hasDueTime)
            {
                cbHthucXuLy.Text = "Khóa tài khoản";
                flpnThoiGianKhoa.Visible = true;
                flpnBoiThuong.Visible = false;
            }
            else if (hasPenalty)
            {
                cbHthucXuLy.Text = "Bồi thường";
                flpnThoiGianKhoa.Visible = false;
                flpnBoiThuong.Visible = true;
            }
            else
            {
                cbHthucXuLy.Text = "Không xác định";
                flpnThoiGianKhoa.Visible = false;
                flpnBoiThuong.Visible = false;
            }

            btnChonMaSV.Enabled = false;
            btnChonQD.Enabled = false;
            btnChonMaDatCho.Enabled = false;
            cbHthucXuLy.Enabled = false;
            cbThoiGianKhoa.Enabled = false;
            txtTienBoiThuong.Enabled = false;
            cbTrangThai.Enabled = false;
            flpnNgayTao.Visible = true;

            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThem.Visible = true;
            btnChiTiet.Visible = true;

            if (cbTrangThai.Text == "Đang xử lý")
            {
                btnChinhSua.Visible = true;
                btnXoa.Visible = true;
            }
            else
            {
                btnChinhSua.Visible = false;
                btnXoa.Visible = false;
            }
        }

        private void switchToAddMode() {
            txtID.Text = string.Empty;

            btnChonMaSV.Enabled = true;
            btnChonQD.Enabled = true;
            btnChonMaDatCho.Enabled = true;
            cbHthucXuLy.Enabled = true;
            flpnThoiGianKhoa.Visible = false;
            cbThoiGianKhoa.Enabled = true;
            flpnBoiThuong.Visible = false;
            txtTienBoiThuong.Enabled = true;
            flpnNgayTao.Visible = false;
            cbTrangThai.Enabled = true;

            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThem.Visible = false;
            btnChinhSua.Visible = false;
            btnXoa.Visible = false;
            btnChiTiet.Visible = false;
        }

        private void switchToEditMode()
        {
            btnChonMaSV.Enabled = false;
            btnChonMaDatCho.Enabled = false;

            if (cbTrangThai.Text == "Đang xử lý") {
                btnChonQD.Enabled = true;

                cbHthucXuLy.Enabled = true;
                cbThoiGianKhoa.Enabled = true;
                txtTienBoiThuong.Enabled = true;
                flpnNgayTao.Visible = true;
                cbTrangThai.Enabled = true;
                displayHinhThucXuLy();

                btnLuu.Visible = true;
                btnHuy.Visible = true;
                btnThem.Visible = false;
                btnChinhSua.Visible = false;
                btnXoa.Visible = false;
                btnChiTiet.Visible = false;
            }
        }

        private void initDataGridView()
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.MultiSelect = false;
            dataGridView.AllowUserToAddRows = false;

            dataGridView.Columns.Add("ViolationID", "ID");
            dataGridView.Columns.Add("MemberID", "Mã TV");
            dataGridView.Columns.Add("RegulationID", "Mã quy định");
            dataGridView.Columns.Add("ReservationID", "Mã phiếu mượn");
            dataGridView.Columns.Add("Penalty", "Số tiền bồi thường");
            dataGridView.Columns.Add("DueTime", "Thời gian khóa(tháng)");
            dataGridView.Columns.Add("Status", "Trạng thái");
            dataGridView.Columns.Add("CreatedAt", "Ngày tạo");

            dataGridView.Columns["ViolationID"].FillWeight = 5;
            dataGridView.Columns["MemberID"].FillWeight = 10;
            dataGridView.Columns["RegulationID"].FillWeight = 10;
            dataGridView.Columns["ReservationID"].FillWeight = 8;
            dataGridView.Columns["Penalty"].FillWeight = 13;
            dataGridView.Columns["DueTime"].FillWeight = 12;
            dataGridView.Columns["Status"].FillWeight = 15;
            dataGridView.Columns["CreatedAt"].FillWeight = 17;
        }

        private void loadData(List<ViolationDTO> violations)
        {
            dataGridView.Rows.Clear();

            foreach (var violation in violations)
            {
                string statusText = "";
                switch (violation.Status)
                {
                    case Dang_Xu_Ly:
                        statusText = "Đang xử lý";
                        break;
                    case Da_Xu_Ly:
                        statusText = "Đã xử lý";
                        break;
                    default:
                        statusText = "Không xác định";
                        break;
                }

                string thoiGianKhoaText = "";

                if (violation.DueTime != null)
                {
                    if (violation.DueTime.Value.Year >= 9999)
                    {
                        thoiGianKhoaText = "Vĩnh viễn";
                    }
                    else if (violation.CreatedAt != null)
                    {
                        int soThang = ((violation.DueTime.Value.Year - violation.CreatedAt.Value.Year) * 12)
                                    + violation.DueTime.Value.Month - violation.CreatedAt.Value.Month;

                        if (soThang > 0)
                        {
                            thoiGianKhoaText = soThang.ToString();
                        }
                    }
                }

                dataGridView.Rows.Add(
                    violation.ViolationID,
                    violation.MemberID,
                    violation.RegulationID,
                    violation.ReservationID.HasValue ? violation.ReservationID.Value.ToString() : "",
                    violation.Penalty,
                    thoiGianKhoaText,
                    statusText,
                    violation.CreatedAt?.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        private void LoadFormFromSelectedRow()
        {
            if (dataGridView.SelectedRows.Count == 0) return;

            var row = dataGridView.SelectedRows[0];
            if (row.Cells["ViolationID"].Value != null)
            {
                txtID.Text = row.Cells["ViolationID"].Value.ToString();
                txtMaTV.Text = row.Cells["MemberID"].Value.ToString();
                txtMaQD.Text = row.Cells["RegulationID"].Value.ToString();
                txtMaDatCho.Text = row.Cells["ReservationID"].Value.ToString();

                cbThoiGianKhoa.Text = row.Cells["DueTime"].Value?.ToString();
                txtTienBoiThuong.Text = row.Cells["Penalty"].Value?.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["CreatedAt"].Value);

                //cbTrangThai.Text = row.Cells["Status"].Value.ToString();
                cbTrangThai.SelectedIndex = cbTrangThai.FindStringExact(row.Cells["Status"].Value.ToString());

                switchToViewMode();
            }
            else
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtMaTV.Text = string.Empty;
            txtMaQD.Text = string.Empty;
            txtMaDatCho.Text = string.Empty;

            cbHthucXuLy.Text = "Chọn hình thức";
            cbThoiGianKhoa.Text = "Chọn thời gian";

            txtTienBoiThuong.Text = string.Empty;

            flpnThoiGianKhoa.Visible = false;
            flpnBoiThuong.Visible = false;
            flpnNgayTao.Visible = false;

            cbTrangThai.SelectedIndex = 0;
        }

        private int? GetSelectedStatusFromCbTieuChiTrangThai()
        {
            switch (cbTieuChiTrangThai.SelectedIndex)
            {
                case 1: return 1; // Đang xử lý
                case 2: return 2; // Đã xử lý
                default: return null; // Tất cả
            }
        }

        private void displayHinhThucXuLy() 
        {
            switch (cbHthucXuLy.Text)
            {
                case "Khóa tài khoản":
                    flpnThoiGianKhoa.Visible = true;
                    flpnBoiThuong.Visible = false;
                    break;
                case "Bồi thường":
                    flpnThoiGianKhoa.Visible = false;
                    flpnBoiThuong.Visible = true;
                    break;
                case "Khóa tài khoản & Bồi thường":
                    flpnThoiGianKhoa.Visible = true;
                    flpnBoiThuong.Visible = true;
                    break;
            }
        }

        private void GetFilteredViolations()
        {
            string searchText = txtTimKiem.Text.Trim();
            loadData(ViolationBLL.Instance.GetByMemberIdLikeAndOptionalStatus(searchText, GetSelectedStatusFromCbTieuChiTrangThai()));
        }

        private bool IsComboBoxValueValid(ComboBox comboBox)
        {
            string input = comboBox.Text;
            foreach (var item in comboBox.Items)
            {
                if (string.Equals(item.ToString(), input, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsValidThoiGianKhoa(string input)
        {
            input = input.Trim();
            if (string.IsNullOrEmpty(input)) return false;

            if (cbThoiGianKhoa.Items.Contains(input)) return true; // mục có sẵn

            // Cho phép nhập số nguyên dương
            return int.TryParse(input, out int value) && value > 0;
        }

        private bool validateForm() 
        {
            if (string.IsNullOrWhiteSpace(txtMaTV.Text))
            {
                MessageBox.Show("Vui lòng chọn mã thành viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaQD.Text))
            {
                MessageBox.Show("Vui lòng chọn mã quy định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsComboBoxValueValid(cbHthucXuLy))
            {
                MessageBox.Show("Hình thức xử lý không hợp lệ. Vui lòng chọn lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ( (cbHthucXuLy.Text == "Khóa tài khoản" || cbHthucXuLy.Text == "Khóa tài khoản & Bồi thường") && !IsValidThoiGianKhoa(cbThoiGianKhoa.Text))
            {
                MessageBox.Show("Thời gian khóa không hợp lệ. Vui lòng chọn hoặc nhập số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbHthucXuLy.Text == "Bồi thường" || cbHthucXuLy.Text == "Khóa tài khoản & Bồi thường") {
                string tienBoiThuongInput = txtTienBoiThuong.Text.Trim();

                if (string.IsNullOrEmpty(tienBoiThuongInput))
                {
                    MessageBox.Show("Tiền bồi thường không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!decimal.TryParse(tienBoiThuongInput, out decimal value) || value < 0)
                {
                    MessageBox.Show("Tiền bồi thường phải là một số không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!IsComboBoxValueValid(cbTrangThai))
            {
                MessageBox.Show("Trạng thái không hợp lệ. Vui lòng chọn lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void HandleAddViolation()
        {
            DateTime? dueTime = null;
            if (!string.IsNullOrWhiteSpace(cbThoiGianKhoa.Text))
            {
                if (cbThoiGianKhoa.Text == "Vĩnh viễn")
                {
                    dueTime = new DateTime(9999, 12, 31);
                }
                else if (int.TryParse(cbThoiGianKhoa.Text, out int months))
                {
                    dueTime = dtpNgayTao.Value.AddMonths(months);
                }
            }

            int status = 1;
            if (cbTrangThai.Text == "Đang xử lý")
            {
                status = Dang_Xu_Ly;
            }
            else if (cbTrangThai.Text == "Đã xử lý")
            {
                status = Da_Xu_Ly;
            }

            int? maDatCho = null;
            if (int.TryParse(txtMaDatCho.Text, out int tempId))
            {
                maDatCho = tempId;
            }

            ViolationDTO violation = new ViolationDTO(
                                        uint.Parse(txtMaTV.Text),
                                        int.Parse(txtMaQD.Text),
                                        maDatCho,
                                        txtTienBoiThuong.Text,
                                        dueTime,
                                        status
                                    );
            bool result = ViolationBLL.Instance.Create(violation);

            if (result)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isAdding = false;
                loadData(ViolationBLL.Instance.GetAll());
                //ClearForm();
                switchToViewMode();
                if (dataGridView.Rows.Count >= 0)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[0].Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = 0;
                }
                LoadFormFromSelectedRow();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleUpdateViolation() 
        {
            string tienBoiThuong = null;
            if (cbHthucXuLy.Text == "Bồi thường" || cbHthucXuLy.Text == "Khóa tài khoản & Bồi thường")
            {
                tienBoiThuong = txtTienBoiThuong.Text;
            }

            DateTime? dueTime = null;
            if (cbHthucXuLy.Text == "Khóa tài khoản" || cbHthucXuLy.Text == "Khóa tài khoản & Bồi thường") 
            {
                if (!string.IsNullOrWhiteSpace(cbThoiGianKhoa.Text))
                {
                    if (cbThoiGianKhoa.Text == "Vĩnh viễn")
                    {
                        dueTime = new DateTime(9999, 12, 31);
                    }
                    else if (int.TryParse(cbThoiGianKhoa.Text, out int months))
                    {
                        dueTime = dtpNgayTao.Value.AddMonths(months);
                    }
                }
            }
            
            int status = 1;

            if(cbTrangThai.Text == "Đang xử lý") {
                status = Dang_Xu_Ly;
            } else if (cbTrangThai.Text == "Đã xử lý") { 
                status = Da_Xu_Ly;
            }

            int? reservationId = null;
            if (!string.IsNullOrWhiteSpace(txtMaDatCho.Text))
            {
                if (int.TryParse(txtMaDatCho.Text, out int tempId))
                {
                    reservationId = tempId;
                }
            }

            ViolationDTO violation = new ViolationDTO(
                                        int.Parse(txtID.Text),
                                        uint.Parse(txtMaTV.Text),
                                        int.Parse(txtMaQD.Text),
                                        reservationId,
                                        tienBoiThuong,
                                        null,
                                        dueTime,
                                        status
                                    );

            bool result = ViolationBLL.Instance.Update(violation);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView.SelectedRows[0].Cells["MemberID"].Value = violation.MemberID;
                dataGridView.SelectedRows[0].Cells["RegulationID"].Value = violation.RegulationID;
                dataGridView.SelectedRows[0].Cells["ReservationID"].Value = violation.ReservationID.HasValue ? violation.ReservationID.Value.ToString() : "";
                dataGridView.SelectedRows[0].Cells["Penalty"].Value = violation.Penalty;
                if (dueTime.HasValue)
                {
                    dataGridView.SelectedRows[0].Cells["DueTime"].Value = cbThoiGianKhoa.Text;
                }
                else
                {
                    dataGridView.SelectedRows[0].Cells["DueTime"].Value = "";
                }
                dataGridView.SelectedRows[0].Cells["Status"].Value = cbTrangThai.Text;

                LoadFormFromSelectedRow();
                switchToViewMode();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleDeleteRegulation()
        {
            var row = dataGridView.SelectedRows[0];
            int ViolationID = Convert.ToInt32(row.Cells["ViolationID"].Value);

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            bool result = ViolationBLL.Instance.Delete(ViolationID);

            if (result)
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(ViolationBLL.Instance.GetAll());
                ClearForm();
                LoadFormFromSelectedRow();
            }
            else
            {
                MessageBox.Show("Xóa thất bại! Có lỗi xảy ra! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearForm();
            switchToAddMode();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switchToEditMode();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HandleDeleteRegulation();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;

            if (isAdding)
            {
                HandleAddViolation();
            }
            else
            {
                HandleUpdateViolation();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            LoadFormFromSelectedRow();
            switchToViewMode();
        }

        private void btnChonMaTV_Click(object sender, EventArgs e)
        {
            int.TryParse(txtMaTV.Text, out int id);

            using (var form = new SelectMemberForm(id))
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedMemberID.HasValue)
                    txtMaTV.Text = form.SelectedMemberID.Value.ToString();
            }
        }

        private void btnChonQD_Click(object sender, EventArgs e)
        {
            int.TryParse(txtMaQD.Text, out int id);

            using (var form = new SelectRegulationForm(id))
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedRegulationID.HasValue)
                    txtMaQD.Text = form.SelectedRegulationID.Value.ToString();
            }
        }

        private void btnChonMaDatCho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTV.Text))
            {
                MessageBox.Show("Vui lòng chọn mã thành viên trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? maDatCho = null;
            if (int.TryParse(txtMaDatCho.Text, out int tempId))
            {
                maDatCho = tempId;
            }

            using (var form = new SelectViolatedReservationForm(maDatCho, int.Parse(txtMaTV.Text)))
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedReservationID.HasValue)
                    txtMaDatCho.Text = form.SelectedReservationID.Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            cbTieuChiTrangThai.SelectedIndex = 0;

            loadData(ViolationBLL.Instance.GetAll());
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            GetFilteredViolations();
        }

        private void cbTieuChiTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilteredViolations();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                LoadFormFromSelectedRow();
                switchToViewMode();
            }
        }

        private void cbHthucXuLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayHinhThucXuLy();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            var form = new ViolationDetailForm(ViolationBLL.Instance.GetById(int.Parse(txtID.Text)), cbHthucXuLy.Text, cbThoiGianKhoa.Text, txtTienBoiThuong.Text);
            form.ShowDialog();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                switch (status)
                {
                    case "Đang xử lý":
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.FromArgb(255, 193, 7);
                        break;
                    case "Đã xử lý":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(40, 167, 69);
                        break;
                }
            }
        }
    }
}
