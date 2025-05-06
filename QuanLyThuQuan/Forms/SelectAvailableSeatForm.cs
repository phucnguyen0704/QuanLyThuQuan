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
    public partial class SelectAvailableSeatForm : Form
    {
        private int? _currentSeatID;
        public int? SelectedSeatID { get; private set; }

        private const int TEN_CHO = 0;
        private const int MA_CHO = 1;

        private SeatBLL seatBLL;

        public SelectAvailableSeatForm(int? currentSeatID = null)
        {
            InitializeComponent();
            seatBLL = new SeatBLL();
            _currentSeatID = currentSeatID;

            cbTieuChiTim.SelectedIndex = TEN_CHO;
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
            dataGridView.MultiSelect = false;
            dataGridView.AllowUserToAddRows = false;

            dataGridView.Columns.Add("SeatID", "Mã chỗ");
            dataGridView.Columns.Add("SeatName", "Tên chỗ");

            dataGridView.Columns["SeatID"].FillWeight = 30;
            dataGridView.Columns["SeatName"].FillWeight = 70;
        }

        private void LoadData()
        {
            var seats = seatBLL.getAllSeat().Where(s => s.status == 1).ToList();
            dataGridView.Rows.Clear();
            foreach (var seat in seats)
            {
                int rowIndex = dataGridView.Rows.Add(seat.seatId, seat.seatName);

                if (_currentSeatID.HasValue && seat.seatId == _currentSeatID.Value)
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void loadData(List<SeatDTO> seats)
        {
            dataGridView.Rows.Clear();
            foreach (var seat in seats)
            {
                int rowIndex = dataGridView.Rows.Add(seat.seatId, seat.seatName);

                if (_currentSeatID.HasValue && seat.seatId == _currentSeatID.Value)
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            var keyword = txtTimKiem.Text.Trim().ToLower();
            var seats = seatBLL.getAllSeat().Where(s => s.status == 1);

            switch (cbTieuChiTim.SelectedIndex)
            {
                case TEN_CHO:
                    seats = seats.Where(s => s.seatName.ToLower().Contains(keyword));
                    break;
                case MA_CHO:
                    seats = seats.Where(s => s.seatId.ToString().Contains(keyword));
                    break;
            }

            loadData(seats.ToList());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            cbTieuChiTim.SelectedIndex = TEN_CHO;
            LoadData();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedSeatID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["SeatID"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
