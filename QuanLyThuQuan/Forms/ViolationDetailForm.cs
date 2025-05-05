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

namespace QuanLyThuQuan.Forms
{
    public partial class ViolationDetailForm : Form
    {
        private MemberBLL memberBLL;
        private ReservationBLL reservationBLL;
        private ReservationDetailBLL reservationDetailBLL;
        private DeviceBLL deviceBLL;

        private ViolationDTO violationDTO;
        public ViolationDetailForm(ViolationDTO violationDTO,string hinhthucXuly,  string thoigianKhoa, string tienBoithuong)
        {
            InitializeComponent();

            memberBLL = new MemberBLL();

            this.violationDTO = violationDTO;

            loadData(violationDTO,hinhthucXuly, thoigianKhoa, tienBoithuong);

            if (violationDTO.ReservationID != null)
            {
                reservationBLL = new ReservationBLL();
                reservationDetailBLL = new ReservationDetailBLL();
                deviceBLL = new DeviceBLL();

                splitContainerVPDatCho.Visible = true;
                loadContentVPDatCho();
            }
        }

        private void loadContentVPDatCho() 
        { 
            // splitcontent.panel1
            ReservationDTO reservationDTO = reservationBLL.getByID(violationDTO.ReservationID.Value);
            txtMaDatCho.Text = violationDTO.ReservationID.ToString();
            txtMaCho.Text = reservationDTO.SeatID == null ? "" : reservationDTO.SeatID.ToString();

            string reservationTypeText = reservationDTO.ReservationType == 1 ? "Tại chỗ" :
                                         reservationDTO.ReservationType == 2 ? "Mang về" : "Không rõ";
            txtLoaiMuon.Text = reservationTypeText;

            txtTGMuon.Text = reservationDTO.ReservationTime.ToString("dd/MM/yyyy HH:mm:ss");
            txtHanTra.Text = reservationDTO.DueTime.ToString("dd/MM/yyyy HH:mm:ss");
            txtTGTra.Text = reservationDTO.ReturnTime == null ? "Chưa trả" : reservationDTO.ReturnTime.Value.ToString("dd/MM/yyyy HH:mm:ss");

            // splitcontent.panel2
            initDgvReservationDetail();
            dgvReservationDetailLoad(violationDTO.ReservationID.Value);
        }

        private void loadData(ViolationDTO violationDTO, string hinhthucXuly, string thoigianKhoa, string tienBoithuong)
        {
            // Thông tin thành viên vi phạm
            MemberDTO memberDTO = memberBLL.getByID(violationDTO.MemberID);
            txtMaTV.Text = memberDTO.MemberId.ToString();
            txtHoten.Text = memberDTO.FullName;
            dtpNgaySinh.Value = memberDTO.Birthday;
            txtEmail.Text = memberDTO.Email;
            txtSDT.Text = memberDTO.PhoneNumber;
            txtKhoa.Text = memberDTO.Department;
            txtNganh.Text = memberDTO.Major;
            txtLop.Text = memberDTO.Class;
            txtHThucXuLy.Text = hinhthucXuly;

            // Thông tin vi phạm
            RegulationDTO regulationDTO = RegulationBLL.Instance.GetById(violationDTO.RegulationID);
            txtMaQD.Text = regulationDTO.RegulationID.ToString();
            txtTenQD.Text = regulationDTO.Name;
            dtpNgayTao.Value = Convert.ToDateTime(violationDTO.CreatedAt);

            switch (violationDTO.Status) 
            {
                case 1:
                    txtTrangThai.Text = "Đang xử lý";
                    break;
                case 2:
                    txtTrangThai.Text = "Đã xử lý";
                    break;
            }

            // Hình thức xử lý
            if (hinhthucXuly == "Khóa tài khoản & Bồi thường")
            {
                flpnKhoaTK.Visible = true;
                flpnBoiThuong.Visible = true;
                txtThoiGianKhoa.Text = thoigianKhoa;
                txtTienBoiThuong.Text = tienBoithuong;
            }
            else if (hinhthucXuly == "Khóa tài khoản")
            {
                flpnKhoaTK.Visible = true;
                txtThoiGianKhoa.Text = thoigianKhoa;
            }
            else if (hinhthucXuly == "Bồi thường")
            {
                flpnBoiThuong.Visible = true;
                txtTienBoiThuong.Text = tienBoithuong;
            }
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

        // Resize textbox to fit text
        private void AdjustTextBoxWidth(TextBox textBox)
        {
            using (Graphics g = textBox.CreateGraphics())
            {
                SizeF size = g.MeasureString(textBox.Text, textBox.Font);
                textBox.Width = (int)size.Width + 10;
            }
        }

        private void txtHThucXuLy_TextChanged(object sender, EventArgs e)
        {
            AdjustTextBoxWidth((TextBox)sender);
        }

        private void dgvReservation_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
