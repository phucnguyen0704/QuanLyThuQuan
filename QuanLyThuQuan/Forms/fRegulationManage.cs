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
    public partial class fRegulationManage : Form
    {

        private bool isAdding = false;

        public fRegulationManage()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initDataGridView();
            loadData(RegulationBLL.Instance.GetAll());

            txtID.Enabled = false;
            setInputReadOnly(true);
            setButtonState(true, true, false, false);

            dateNgayTao.Value = dateNgayTao.MinDate;
            
        }

        private void initDataGridView()
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;

            dataGridView.Columns.Add("RegulationID", "ID");
            dataGridView.Columns.Add("Name", "Tên");
            dataGridView.Columns.Add("Type", "Loại");
            dataGridView.Columns.Add("Description", "Mô tả");
            dataGridView.Columns.Add("CreatedAt", "Ngày tạo");
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

        private void setButtonState(bool themVisible, bool chinhSuaVisible, bool luuVisible, bool huyVisible)
        {
            btnThem.Visible = themVisible;
            btnChinhSua.Visible = chinhSuaVisible;
            btnLuu.Visible = luuVisible;
            btnHuy.Visible = huyVisible;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                LoadFormFromSelectedRow();
                setInputReadOnly(true);
                setButtonState(true, true, false, false);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            flpnNgayTao.Visible = false;
            ClearForm();
            setInputReadOnly(false);
            setButtonState(false, false, true, true);
            txtTen.Focus();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            setInputReadOnly(false);
            setButtonState(false, false, true, true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            LoadFormFromSelectedRow();
            setInputReadOnly(true);
            flpnNgayTao.Visible = true;
            setButtonState(true, true, false, false);
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
                ClearForm();
                setInputReadOnly(true);
                setButtonState(true, true, false, false);
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
                loadData(RegulationBLL.Instance.GetAll());
                LoadFormFromSelectedRow();
                setInputReadOnly(true);
                setButtonState(true, true, false, false);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
