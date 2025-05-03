using ClosedXML;
using DocumentFormat.OpenXml.Packaging;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class fLogManage : Form
    {
        LogDAL logDAL = new LogDAL();
        LogBLL logBLL = new LogBLL();
        public fLogManage()
        {
            InitializeComponent();
            LoadLog();
            
        }

        public void LoadLog()
        {
            List<LogDTO> log = logDAL.getAll();

            dataGridViewLog.Columns.Clear();
            dataGridViewLog.DataSource = log;
            dataGridViewLog.Columns["logId"].HeaderText = "ID";
            dataGridViewLog.Columns["memberId"].HeaderText = "Mã sinh viên";
            dataGridViewLog.Columns["checkInTime"].HeaderText = "Thời gian vào";
            dataGridViewLog.Columns["status"].HeaderText = "Trạng thái";
            dataGridViewLog.Columns["createdAt"].HeaderText = "Ngày tạo";

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            btnDetail.HeaderText = "Chi tiết";
            btnDetail.Name = "btnDetail";
            btnDetail.Text = "Chi tiết";
            btnDetail.UseColumnTextForButtonValue = true;
            dataGridViewLog.Columns.Add(btnDetail);

            // Không chọn dòng mặc định
            dataGridViewLog.DataBindingComplete -= dataGridViewLog_DataBindingComplete;
            dataGridViewLog.DataBindingComplete += dataGridViewLog_DataBindingComplete;

            dataGridViewLog.EnableHeadersVisualStyles = false;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewLog.ReadOnly = true;
            dataGridViewLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLog.MultiSelect = false;
            dataGridViewLog.AllowUserToAddRows = false;
            dataGridViewLog.AllowUserToDeleteRows = false;
            dataGridViewLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đăng ký sự kiện click nút chi tiết
            dataGridViewLog.CellContentClick += dataGridViewLog_CellContentClickbtnDetail;
        }

        // Xoá chọn sau khi bind xong
        private void dataGridViewLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewLog.ClearSelection();
            dataGridViewLog.CurrentCell = null;
        }

        private void dataGridViewLog_CellContentClickbtnDetail(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewLog.Columns[e.ColumnIndex].Name == "btnDetail")
            {
                DataGridViewRow row = dataGridViewLog.Rows[e.RowIndex];
                txtLogID.Text = row.Cells["LogId"].Value.ToString();
                txtLogMemberID.Text = row.Cells["memberId"].Value.ToString();
                txtStatus.Text = row.Cells["status"].Value.ToString();
                
                string[] parts = row.Cells["checkInTime"].Value.ToString().Split(' ');
                string timeOnly = parts[1];
                string[] timeParts = timeOnly.Split(':');
                int hour = int.Parse(timeParts[0]);
                int minute = int.Parse(timeParts[1]);
                string checkInTime = hour.ToString("D2") + ":" + minute.ToString("D2");
                txtTime.Text = checkInTime;
                checkinDate.Value = DateTime.Parse(parts[0]);


                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        // Hàm này có chức năng khi click nào một dòng bất kỳ sẽ cho ra từng giá trị ở từng textBox
        private void dataGridViewLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStatus.Text = dataGridViewLog.CurrentRow.Cells[2].Value.ToString();
            dataGridViewLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridViewLog.ColumnHeadersDefaultCellStyle.BackColor;
            dataGridViewLog.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridViewLog.ColumnHeadersDefaultCellStyle.ForeColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkinTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string memberId = txtLogMemberID.Text;
            DateTime checkInDate = checkinDate.Value.Date;
            string checkInTime = txtTime.Text;

            //chuyen du lieu sang ngay gio cho dung
            if (!Regex.IsMatch(checkInTime.Trim(), @"^([01]\d|2[0-3]):([0-5]\d)$"))
            {
                MessageBox.Show("Giờ không đúng định dạng HH:mm. Vui lòng nhập lại (ví dụ: 11:00)");
                return;
            }
            TimeSpan.TryParse(checkInTime, out TimeSpan time);
            DateTime finalDateTime = checkInDate.Add(time);

            string error = logBLL.create(memberId, finalDateTime);
            var result = MessageBox.Show(
            "Bạn có chắc muốn ghi nhận sinh viên "+ memberId +" vào danh sách chứ?",  // Nội dung
            "Ghi nhận nhật kí",                        // Tiêu đề
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
                        MessageBox.Show("Ghi nhận thành công!");
                        LoadLog();
                    }
                    break;
                default:
                    break;
            }

            txtLogMemberID.ResetText();
            txtTime.ResetText();
            checkInDate = DateTime.MinValue;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CheckInHour_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLogID_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkinDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string newMemberId = txtLogMemberID.Text;
            DateTime newCheckInDate = checkinDate.Value.Date;
            string newCheckInTime = txtTime.Text;

            //chuyen du lieu sang ngay gio cho dung
            if (!Regex.IsMatch(newCheckInTime.Trim(), @"^([01]\d|2[0-3]):([0-5]\d)$"))
            {
                MessageBox.Show("Giờ không đúng định dạng HH:mm. Vui lòng nhập lại (ví dụ: 11:00)");
                return;
            }
            TimeSpan.TryParse(newCheckInTime, out TimeSpan time);
            DateTime finalDateTime = newCheckInDate.Add(time);

            string error = logBLL.update(int.Parse(txtLogID.Text), newMemberId, finalDateTime);
            var result = MessageBox.Show(
            "Bạn có chắc muốn cập nhật sinh viên " + newMemberId + " vào danh sách chứ?",  // Nội dung
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
                        LoadLog();
                    }
                    break;
                default:
                    break;
            }

            dataGridViewLog.ClearSelection(); // Bỏ chọn dòng
            dataGridViewLog.CurrentCell = null;

            txtLogID.Text = "";
            txtLogMemberID.Text = "";
            txtStatus.Text = "";
            txtTime.Text = "";
            checkinDate.Value = DateTime.Now.Date;
            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridViewLog.ClearSelection(); // Bỏ chọn dòng
            dataGridViewLog.CurrentCell = null;

            txtLogID.Text = "";
            txtLogMemberID.Text = "";
            txtStatus.Text = "";
            txtTime.Text = "";
            checkinDate.Value = DateTime.Now.Date;
            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string memberId = txtLogMemberID.Text;
            string LogId = txtLogID.Text;
            DateTime checkInDate = checkinDate.Value.Date;
            string checkInTime = txtTime.Text;
            string error = logBLL.delete(int.Parse(LogId));
            var result = MessageBox.Show(
            "Bạn có chắc muốn xóa thời gian sinh viên " + memberId + " vào thư quán lúc "+checkInTime+" ngày"+checkinDate+" khỏi danh sách chứ?",  // Nội dung
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
                        LoadLog();
                    }
                    break;
                default:
                    break;
            }

            dataGridViewLog.ClearSelection(); // Bỏ chọn dòng
            dataGridViewLog.CurrentCell = null;

            txtLogID.Text = "";
            txtLogMemberID.Text = "";
            txtStatus.Text = "";
            txtTime.Text = "";
            checkinDate.Value = DateTime.Now.Date;
            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }
    }
}
