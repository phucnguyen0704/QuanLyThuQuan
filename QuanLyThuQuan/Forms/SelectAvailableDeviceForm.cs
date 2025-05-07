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

namespace QuanLyThuQuan.Forms
{
    public partial class SelectAvailableDeviceForm : Form
    {
        private List<int> _preSelectedDeviceIDs;
        public List<int> SelectedDeviceIDs { get; private set; } = new List<int>();

        private const int TEN_THIET_BI = 0;
        private const int MA_THIET_BI = 1;

        private DeviceBLL deviceBLL;

        public SelectAvailableDeviceForm(List<int> selectedIDs = null)
        {
            InitializeComponent();
            deviceBLL = new DeviceBLL();
            _preSelectedDeviceIDs = selectedIDs ?? new List<int>();

            cbTieuChiTim.SelectedIndex = TEN_THIET_BI;
            InitDataGridView();
            LoadData();
        }

        private void InitDataGridView()
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.MultiSelect = true;
            dataGridView.AllowUserToAddRows = false;

            dataGridView.Columns.Add("DeviceID", "Mã thiết bị");
            dataGridView.Columns.Add("Name", "Tên thiết bị");

            dataGridView.Columns["DeviceID"].FillWeight = 30;
            dataGridView.Columns["Name"].FillWeight = 70;
        }

        private void LoadData()
        {
            var devices = deviceBLL.getAll().Where(d => d.Status == 1).ToList();
            dataGridView.Rows.Clear();

            foreach (var device in devices)
            {
                int rowIndex = dataGridView.Rows.Add(device.DeviceID, device.Name);

                if (_preSelectedDeviceIDs.Contains(device.DeviceID))
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                }
            }
        }

        private void loadData(List<DeviceDTO> devices)
        {
            dataGridView.Rows.Clear();

            foreach (var device in devices)
            {
                int rowIndex = dataGridView.Rows.Add(device.DeviceID, device.Name);

                if (_preSelectedDeviceIDs.Contains(device.DeviceID))
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            var keyword = txtTimKiem.Text.Trim().ToLower();
            var devices = deviceBLL.getAll().Where(d => d.Status == 1);

            switch (cbTieuChiTim.SelectedIndex)
            {
                case TEN_THIET_BI:
                    devices = devices.Where(d => d.Name.ToLower().Contains(keyword));
                    break;
                case MA_THIET_BI:
                    devices = devices.Where(d => d.DeviceID.ToString().Contains(keyword));
                    break;
            }

            loadData(devices.ToList());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            cbTieuChiTim.SelectedIndex = TEN_THIET_BI;
            LoadData();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                SelectedDeviceIDs = dataGridView.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(row => Convert.ToInt32(row.Cells["DeviceID"].Value))
                    .ToList();

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thiết bị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
