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
    public partial class SelectViolatedReservationForm : Form
    {
        private int? _currentReservationID;
        public int? SelectedReservationID { get; private set; }
        private int memberID;

        private ReservationBLL reservationBLL;
        private ReservationDetailBLL reservationDetailBLL;
        private DeviceBLL deviceBLL;

        public SelectViolatedReservationForm(int? currentReservationID, int memberID)
        {
            InitializeComponent();
            reservationBLL = new ReservationBLL();
            reservationDetailBLL = new ReservationDetailBLL();
            deviceBLL = new DeviceBLL();

            _currentReservationID = currentReservationID;
            this.memberID = memberID;

            init();
        }

        private void init()
        {
            lblTieuDe.Text += memberID + " )";
            initDgvReservation();
            dgvReservationLoad();

            initDgvReservationDetail();
            if (_currentReservationID.HasValue)
            {   
                int reservationID = _currentReservationID.Value;
                dgvReservationDetailLoad(_currentReservationID.Value);
            }

        }

        private void initDgvReservation()
        {
            dgvReservation.EnableHeadersVisualStyles = false;
            dgvReservation.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvReservation.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservation.ReadOnly = true;
            dgvReservation.MultiSelect = false;
            dgvReservation.AllowUserToAddRows = false;
            dgvReservation.Rows.Clear();
            dgvReservation.Columns.Clear();

            dgvReservation.Columns.Add("ReservationID", "Mã phiếu mượn");
            dgvReservation.Columns.Add("SeatID", "Mã chỗ ngồi");
            dgvReservation.Columns.Add("ReservationType", "Loại mượn");
            dgvReservation.Columns.Add("ReservationTime", "Thời gian mượn");
            dgvReservation.Columns.Add("DueTime", "Hạn trả");
            dgvReservation.Columns.Add("ReturnTime", "Thời gian trả");

            dgvReservation.Columns["ReservationID"].FillWeight = 15; 
            dgvReservation.Columns["SeatID"].FillWeight = 15;
            dgvReservation.Columns["ReservationType"].FillWeight = 10;
            dgvReservation.Columns["ReservationTime"].FillWeight = 20;
            dgvReservation.Columns["DueTime"].FillWeight = 20;
            dgvReservation.Columns["ReturnTime"].FillWeight = 20;
            dgvReservation.Columns.Add("CreatedAt", "Ngày tạo");
            dgvReservation.Columns["CreatedAt"].FillWeight = 20;
        }

        private void initDgvReservationDetail()
        {
            dgvReservationDetail.EnableHeadersVisualStyles = false;
            dgvReservationDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvReservationDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservationDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservationDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservationDetail.ReadOnly = true;
            dgvReservationDetail.MultiSelect = false;
            dgvReservationDetail.AllowUserToAddRows = false;

            dgvReservationDetail.Columns.Add("ReservationDetailID", "Mã chi tiết");
            dgvReservationDetail.Columns.Add("DeviceID", "Mã thiết bị");
            dgvReservationDetail.Columns.Add("DeviceName", "Tên thiết bị");

            dgvReservationDetail.Columns["ReservationDetailID"].FillWeight = 10;
            dgvReservationDetail.Columns["DeviceID"].FillWeight = 10;
            dgvReservationDetail.Columns["DeviceName"].FillWeight = 25;
        }

        private void dgvReservationLoad()
        {
            List<ReservationDTO> reservations = reservationBLL.getCurrentViolatedReservationsByMemberID(memberID);
            dgvReservation.Rows.Clear();

            foreach (var r in reservations)
            {
                string reservationTypeText = r.ReservationType == 1 ? "Tại chỗ" :
                                             r.ReservationType == 2 ? "Mang về" : "Không rõ";

                string returnTimeText = r.ReturnTime.HasValue
                    ? r.ReturnTime.Value.ToString("dd/MM/yyyy HH:mm:ss")
                    : "Chưa trả";

                int rowIndex = dgvReservation.Rows.Add(
                    r.ReservationID,
                    r.SeatID.HasValue ? r.SeatID.ToString() : "",
                    reservationTypeText,
                    r.ReservationTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    r.DueTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    returnTimeText,
                    r.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")
                );

                if (_currentReservationID.HasValue && r.ReservationID == _currentReservationID.Value)
                {
                    dgvReservation.Rows[rowIndex].Selected = true;
                    dgvReservation.CurrentCell = dgvReservation.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void dgvReservationDetailLoad(int reservationID)
        {
            List<ReservationDetailDTO> reservationDetails = reservationDetailBLL.getByReservationID(reservationID);
            dgvReservationDetail.Rows.Clear();

            foreach (var detail in reservationDetails)
            {
                DeviceDTO device = deviceBLL.getByID(detail.DeviceID);

                dgvReservationDetail.Rows.Add(
                    detail.ReservationDetailID,
                    device.DeviceID,
                    device.Name
                );
            }
        }

        private void dgvReservation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedReservationID = Convert.ToInt32(dgvReservation.Rows[e.RowIndex].Cells["ReservationID"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dgvReservation_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservation.CurrentRow != null && dgvReservation.CurrentRow.Cells["ReservationID"].Value != null)
            {
                int reservationID = (int) dgvReservation.CurrentRow.Cells["ReservationID"].Value;
                dgvReservationDetailLoad(reservationID);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
