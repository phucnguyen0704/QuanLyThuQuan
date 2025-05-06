using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class SelectRegulationForm : Form
    {
        private int? _currentRegulationID;
        public int? SelectedRegulationID { get; private set; }

        public SelectRegulationForm(int? currentRegulationID)
        {
            InitializeComponent();
            _currentRegulationID = currentRegulationID;
            InitDataGridView();
            LoadData(RegulationBLL.Instance.GetAll());
        }

        private void InitDataGridView()
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

        private void LoadData(List<RegulationDTO> regulations)
        {
            dataGridView.Rows.Clear();

            foreach (var regulation in regulations)
            {
                int rowIndex = dataGridView.Rows.Add(
                    regulation.RegulationID,
                    regulation.Name,
                    regulation.Type,
                    regulation.Description,
                    regulation.CreatedAt
                );

                if (_currentRegulationID.HasValue && regulation.RegulationID == _currentRegulationID.Value)
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedRegulationID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["RegulationID"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
