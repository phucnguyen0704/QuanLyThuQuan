using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DAL;
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
using RegulationDTO = QuanLyThuQuan.DTO.RegulationDTO;

namespace QuanLyThuQuan.Forms
{
    public partial class RegulationForm : Form
    {

        private bool isAdding = false;

        public RegulationForm()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initDataGridView();
            loadData(RegulationBLL.Instance.GetAll());
            switchToViewMode();

            dateNgayTao.Value = dateNgayTao.MinDate;
        }

        private void initDataGridView()
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.MultiSelect = false;
            dataGridView.AllowUserToAddRows = false;

            dataGridView.Columns.Add("RegulationID", "ID");
            dataGridView.Columns.Add("Name", "Tên");
            dataGridView.Columns.Add("Type", "Loại");
            dataGridView.Columns.Add("Description", "Mô tả");
            dataGridView.Columns.Add("CreatedAt", "Ngày tạo");

            dataGridView.Columns["RegulationID"].FillWeight = 5;
            dataGridView.Columns["Name"].FillWeight = 25;
            dataGridView.Columns["Type"].FillWeight = 15;
            dataGridView.Columns["Description"].FillWeight = 30;
            dataGridView.Columns["CreatedAt"].FillWeight = 25;
        }

        private void loadData(List<RegulationDTO> regulations)
        {
            dataGridView.Rows.Clear();

            foreach (var regulation in regulations)
            {
                dataGridView.Rows.Add(
                    regulation.RegulationID,
                    regulation.Name,
                    regulation.Type,
                    regulation.Description,
                    regulation.CreatedAt
                );
            }
        }

        private void LoadFormFromSelectedRow()
        {
            if (dataGridView.SelectedRows.Count == 0) return;

            var row = dataGridView.SelectedRows[0];
            if (row.Cells["RegulationID"].Value != null)
            {
                txtID.Text = row.Cells["RegulationID"].Value.ToString();
                txtTen.Text = row.Cells["Name"].Value.ToString();
                txtLoai.Text = row.Cells["Type"].Value.ToString();
                richTxtMoTa.Text = row.Cells["Description"].Value.ToString();
                dateNgayTao.Value = Convert.ToDateTime(row.Cells["CreatedAt"].Value);
            }
            else
            {
                ClearForm();
            }
        }

        private void setInputReadOnly(bool isReadOnly)
        {
            txtTen.ReadOnly = isReadOnly;
            txtLoai.ReadOnly = isReadOnly;
            richTxtMoTa.ReadOnly = isReadOnly;
        }

        private void ClearForm()
        {
            txtID.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtLoai.Text = string.Empty;
            richTxtMoTa.Text = string.Empty;
            dateNgayTao.Value = dateNgayTao.MinDate;
        }

        private void setButtonState(bool themVisible, bool chinhSuaVisible, bool luuVisible, bool huyVisible, bool xoaVisible = true)
        {
            btnThem.Visible = themVisible;
            btnChinhSua.Visible = chinhSuaVisible;
            btnLuu.Visible = luuVisible;
            btnHuy.Visible = huyVisible;
            btnXoa.Visible = xoaVisible;
        }

        private void switchToEditMode()
        {
            setInputReadOnly(false);
            setButtonState(false, false, true, true, false);
        }

        private void switchToAddMode()
        {
            setInputReadOnly(false);
            setButtonState(false, false, true, true, false);
            flpnNgayTao.Visible = false;
            txtTen.Focus();
        }

        private void switchToViewMode()
        {
            setInputReadOnly(true);
            setButtonState(true, true, false, false);
            flpnNgayTao.Visible = true;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                LoadFormFromSelectedRow();
                switchToViewMode();
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
                MessageBox.Show("Vui lòng chọn quy định cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switchToEditMode();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            LoadFormFromSelectedRow();
            switchToViewMode();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;

            if (isAdding)
            {
                HandleAddRegulation();
            }
            else
            {
                HandleUpdateRegulation();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn quy định cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HandleDeleteRegulation();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            loadData(RegulationBLL.Instance.GetAll());
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                loadData(RegulationBLL.Instance.GetAll());
            }
            else
            {
                loadData(RegulationBLL.Instance.GetByName(searchText));
            }
        }

        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoai.Text))
            {
                MessageBox.Show("Loại không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoai.Focus();
                return false;
            }

            return true;
        }

        private void HandleAddRegulation()
        {
            RegulationDTO newRegulation = new RegulationDTO(
                txtTen.Text.Trim(),
                txtLoai.Text.Trim(),
                richTxtMoTa.Text.Trim()
            );

            bool result = RegulationBLL.Instance.Create(newRegulation);

            if (result)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isAdding = false;
                loadData(RegulationBLL.Instance.GetAll());
                //ClearForm();
                switchToViewMode();
                int lastRowIndex = dataGridView.Rows.Count - 1;
                if (lastRowIndex >= 0)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[lastRowIndex].Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = lastRowIndex;
                }
                LoadFormFromSelectedRow();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleUpdateRegulation()
        {
            RegulationDTO regulation = new RegulationDTO(
                int.Parse(txtID.Text.Trim()),
                txtTen.Text.Trim(),
                txtLoai.Text.Trim(),
                richTxtMoTa.Text.Trim(),
                dateNgayTao.Value
            );

            bool result = RegulationBLL.Instance.Update(regulation);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView.SelectedRows[0].Cells["Name"].Value = regulation.Name;
                dataGridView.SelectedRows[0].Cells["Type"].Value = regulation.Type;
                dataGridView.SelectedRows[0].Cells["Description"].Value = regulation.Description;
                dataGridView.SelectedRows[0].Cells["CreatedAt"].Value = regulation.CreatedAt;
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
            int regulationID = Convert.ToInt32(row.Cells["RegulationID"].Value);

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa quy định này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            string errorMessage;
            bool result = RegulationBLL.Instance.Delete(regulationID, out errorMessage);

            if (result)
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(RegulationBLL.Instance.GetAll());
                ClearForm();
                LoadFormFromSelectedRow();
            }
            else
            {
                MessageBox.Show("Xóa thất bại! " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
