
using MySql.Data.MySqlClient;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
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


        private void dataGridViewSeat_CellContentClickbtnDetail(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewSeat.Columns[e.ColumnIndex].Name == "btnDetail")
            {
                DataGridViewRow row = dataGridViewSeat.Rows[e.RowIndex];
                txtSeatID.Text = row.Cells["seatId"].Value.ToString();
                txtSeatName.Text = row.Cells["seatName"].Value.ToString();
                txtStatus.Text = row.Cells["status"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtStatus.Enabled = true;
                txtStatus.ReadOnly = false;
                txtStatus.TabStop = true;
            }
        }

        // Xoá chọn sau khi bind xong
        private void dataGridViewSeat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewSeat.ClearSelection();
            dataGridViewSeat.CurrentCell = null;
        }
                
        // Hàm này có chức năng khi click nào một dòng bất kỳ sẽ cho ra từng giá trị ở từng textBox
        private void dataGridViewSeat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStatus.Text = dataGridViewSeat.CurrentRow.Cells[2].Value.ToString();
            dataGridViewSeat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridViewSeat.ColumnHeadersDefaultCellStyle.BackColor;
            dataGridViewSeat.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridViewSeat.ColumnHeadersDefaultCellStyle.ForeColor;
        }

        // Xử lý trong Button Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtSeatName.Text;
            string error = seatBLL.create(name);
            var result = MessageBox.Show(
            "Bạn có chắc muốn thêm chỗ " + name + " vào danh sách chứ?",  // Nội dung
            "Xác nhận thêm chỗ",                        // Tiêu đề
            MessageBoxButtons.OKCancel,            // Nút OK và Cancel
            MessageBoxIcon.Warning                 // Icon (Warning, Question, Information…)
            );
            switch (result)
            {
                case (DialogResult.OK):
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

        }

        // Xử lý trong Button Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            string newName = txtSeatName.Text;
            string seatId = txtSeatID.Text;
            string status = txtStatus.Text;

            string error = seatBLL.update(int.Parse(seatId), newName, status);
            var result = MessageBox.Show(
            "Bạn có chắc muốn cập nhật tên chỗ mới vào danh sách chứ?",  // Nội dung
            "Xác nhận cập nhật",                        // Tiêu đề
            MessageBoxButtons.OKCancel,            // Nút OK và Cancel
            MessageBoxIcon.Warning                 // Icon (Warning, Question, Information…)
            );
            switch (result)
            {
                case (DialogResult.OK):
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

            dataGridViewSeat.ClearSelection(); // Bỏ chọn dòng
            dataGridViewSeat.CurrentCell = null;

            txtSeatID.Text = "";
            txtSeatName.Text = "";
            txtStatus.Text = "";

            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }

        // Xử lý trong Button Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtSeatName.Text;
            string seatId = txtSeatID.Text;
            string error = seatBLL.delete(int.Parse(seatId));
            var result = MessageBox.Show(
            "Bạn có chắc muốn xóa chỗ "+name+" khỏi danh sách chứ?",  // Nội dung
            "Xác nhận xóa",                        // Tiêu đề
            MessageBoxButtons.OKCancel,            // Nút OK và Cancel
            MessageBoxIcon.Warning                 // Icon (Warning, Question, Information…)
            );
            switch (result)
            {
                case (DialogResult.OK):
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
            dataGridViewSeat.ClearSelection(); // Bỏ chọn dòng
            dataGridViewSeat.CurrentCell = null;

            txtSeatID.Text = "";
            txtSeatName.Text = "";
            txtStatus.Text = "";

            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
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
            dataGridViewSeat.ClearSelection(); // Bỏ chọn dòng
            dataGridViewSeat.CurrentCell = null;

            txtSeatID.Text = "";
            txtSeatName.Text = "";
            txtStatus.Text = "";

            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            txtStatus.Enabled = false;
            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
        }

        private void fSeatManage_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
