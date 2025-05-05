using MySql.Data.MySqlClient;
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
using System.Xml.Linq;

namespace QuanLyThuQuan
{
    public partial class fSeatManage : Form
    {
        SeatDAL seatDAL = new SeatDAL();
        SeatBLL seatBLL = new SeatBLL();

        public fSeatManage()
        {
            InitializeComponent();
            LoadSeat();
            SetupComboBox(); // Khởi tạo ComboBox với các giá trị
        }

        // Khởi tạo ComboBox với giá trị "Còn trống" và "Đã đặt"
        private void SetupComboBox()
        {
            cbStatus.Items.Clear(); // Xóa các giá trị cũ nếu có
            cbStatus.Items.Add("Còn trống");
            cbStatus.Items.Add("Đã đặt");
            cbStatus.SelectedIndex = 0; // Chọn "Còn trống" làm mặc định
            cbStatus.Enabled = false; // Ban đầu tắt chỉnh sửa
        }

        // Load dữ liệu lên dataGridView
        void LoadSeat()
        {
            List<SeatDTO> seat = seatDAL.getAll();

            dataGridViewSeat.Columns.Clear();

            dataGridViewSeat.DataSource = seat;

            dataGridViewSeat.Columns["seatId"].HeaderText = "ID";
            dataGridViewSeat.Columns["seatName"].HeaderText = "Tên chỗ";
            dataGridViewSeat.Columns["status"].HeaderText = "Trạng thái";

            // Đăng ký sự kiện CellFormatting để hiển thị trạng thái dưới dạng chuỗi
            dataGridViewSeat.CellFormatting += dataGridViewSeat_CellFormatting;

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            btnDetail.HeaderText = "Chi tiết";
            btnDetail.Name = "btnDetail";
            btnDetail.Text = "Chi tiết";
            btnDetail.UseColumnTextForButtonValue = true;
            dataGridViewSeat.Columns.Add(btnDetail);

            // Không chọn dòng mặc định
            dataGridViewSeat.DataBindingComplete -= dataGridViewSeat_DataBindingComplete;
            dataGridViewSeat.DataBindingComplete += dataGridViewSeat_DataBindingComplete;

            // Cài đặt UI
            dataGridViewSeat.EnableHeadersVisualStyles = false;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSeat.ReadOnly = true;
            dataGridViewSeat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSeat.MultiSelect = false;
            dataGridViewSeat.AllowUserToAddRows = false;
            dataGridViewSeat.AllowUserToDeleteRows = false;
            dataGridViewSeat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đăng ký sự kiện click nút chi tiết
            dataGridViewSeat.CellContentClick += dataGridViewSeat_CellContentClickbtnDetail;
        }

        // Tùy chỉnh hiển thị cột "Trạng thái"
        private void dataGridViewSeat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewSeat.Columns["status"].Index && e.RowIndex >= 0)
            {
                int status;
                if (int.TryParse(e.Value?.ToString(), out status))
                {
                    switch (status)
                    {
                        case 1:
                            e.Value = "Còn trống";
                            break;
                        case 3:
                            e.Value = "Đã đặt";
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
            }
        }

        private void dataGridViewSeat_CellContentClickbtnDetail(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewSeat.Columns[e.ColumnIndex].Name == "btnDetail")
            {
                DataGridViewRow row = dataGridViewSeat.Rows[e.RowIndex];
                txtSeatID.Text = row.Cells["seatId"].Value.ToString();
                txtSeatName.Text = row.Cells["seatName"].Value.ToString();
                // Chọn trạng thái trong ComboBox dựa trên giá trị status đã hiển thị
                string statusText = row.Cells["status"].Value.ToString();
                cbStatus.Text = statusText == "1" ? "Còn trống" : statusText == "3" ? "Đã đặt" : "";
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                cbStatus.Enabled = true;
                cbStatus.TabStop = false;
                cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        // Xoá chọn sau khi bind xong
        private void dataGridViewSeat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewSeat.ClearSelection();
            dataGridViewSeat.CurrentCell = null;
        }

        // Hàm này có chức năng khi click vào một dòng bất kỳ sẽ cho ra từng giá trị ở từng textBox
        private void dataGridViewSeat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbStatus.Text = dataGridViewSeat.Rows[e.RowIndex].Cells["status"].Value.ToString();
                dataGridViewSeat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewSeat.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridViewSeat.ColumnHeadersDefaultCellStyle.BackColor;
                dataGridViewSeat.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridViewSeat.ColumnHeadersDefaultCellStyle.ForeColor;
            }
        }

        // Xử lý trong Button Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtSeatName.Text;
            int status = cbStatus.SelectedIndex == 0 ? 1 : 3; // Còn trống = 1, Đã đặt = 3
            string error = seatBLL.create(name); // Hiện tại chỉ truyền name, cần sửa BLL nếu muốn truyền status
            var result = MessageBox.Show(
                "Bạn có chắc muốn thêm chỗ " + name + " vào danh sách chứ?",
                "Xác nhận thêm chỗ",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            switch (result)
            {
                case DialogResult.OK:
                    if (error != null)
                    {
                        MessageBox.Show(error);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công!");
                        LoadSeat();
                    }
                    break;
                default:
                    break;
            }

            txtSeatName.ResetText();
            cbStatus.Enabled = false;
        }

        // Xử lý trong Button Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string newName = txtSeatName.Text;
            string seatId = txtSeatID.Text;
            int status = cbStatus.SelectedIndex == 0 ? 1 : 3; // Còn trống = 1, Đã đặt = 3
            string error = seatBLL.update(int.Parse(seatId), newName, status); // Hiện tại chỉ truyền seatId và newName
            var result = MessageBox.Show(
                "Bạn có chắc muốn cập nhật tên chỗ mới vào danh sách chứ?",
                "Xác nhận cập nhật",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            switch (result)
            {
                case DialogResult.OK:
                    if (error != null)
                    {
                        MessageBox.Show(error);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadSeat();
                    }
                    break;
                default:
                    break;
            }

            dataGridViewSeat.ClearSelection();
            dataGridViewSeat.CurrentCell = null;

            txtSeatID.Text = "";
            txtSeatName.Text = "";
            cbStatus.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            cbStatus.TabStop = false;
        }

        // Xử lý trong Button Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtSeatName.Text;
            string seatId = txtSeatID.Text;
            string error = seatBLL.delete(int.Parse(seatId));
            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa chỗ " + name + " khỏi danh sách chứ?",
                "Xác nhận xóa",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            switch (result)
            {
                case DialogResult.OK:
                    if (error != null)
                    {
                        MessageBox.Show(error);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadSeat();
                    }
                    break;
                default:
                    break;
            }
            dataGridViewSeat.ClearSelection();
            dataGridViewSeat.CurrentCell = null;

            txtSeatID.Text = "";
            txtSeatName.Text = "";
            cbStatus.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            cbStatus.TabStop = false;
        }

        private void lblSeatID_Click(object sender, EventArgs e)
        {
        }

        private void txtSeatID_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSeatName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtStatusID_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridViewSeat.ClearSelection();
            dataGridViewSeat.CurrentCell = null;

            txtSeatID.Text = "";
            txtSeatName.Text = "";
            cbStatus.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            cbStatus.TabStop = false;
        }

        private void fSeatManage_Load(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}