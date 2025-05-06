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
    public partial class SelectMemberForm : Form
    {

        private int? _currentMemberID;
        public int? SelectedMemberID { get; private set; }

        private MemberBLL memberBLL;

        public SelectMemberForm(int? currentMemberID)
        {
            InitializeComponent();
            memberBLL = new MemberBLL();
            _currentMemberID = currentMemberID;
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

            dataGridView.Columns.Add("MemberId", "Mã TV");
            dataGridView.Columns.Add("FullName", "Họ tên");
            dataGridView.Columns.Add("Birthday", "Ngày sinh");
            dataGridView.Columns.Add("PhoneNumber", "SĐT");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("Department", "Khoa");
            dataGridView.Columns.Add("Major", "Chuyên ngành");
            dataGridView.Columns.Add("Class", "Lớp");

            dataGridView.Columns["MemberId"].FillWeight = 6;
            dataGridView.Columns["FullName"].FillWeight = 18;
            dataGridView.Columns["Birthday"].FillWeight = 12;
            dataGridView.Columns["PhoneNumber"].FillWeight = 14;
            dataGridView.Columns["Email"].FillWeight = 16;
            dataGridView.Columns["Department"].FillWeight = 12;
            dataGridView.Columns["Major"].FillWeight = 12;
            dataGridView.Columns["Class"].FillWeight = 10;
        }

        private void LoadData()
        {
            dataGridView.Rows.Clear();
            List<MemberDTO> members = memberBLL.getAll();

            foreach (var member in members)
            {
                int rowIndex = dataGridView.Rows.Add(
                    member.MemberId,
                    member.FullName,
                    member.Birthday.ToString("dd/MM/yyyy"),
                    member.PhoneNumber,
                    member.Email,
                    member.Department,
                    member.Major,
                    member.Class
                );

                if (_currentMemberID.HasValue && member.MemberId == _currentMemberID.Value)
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void loadData(List<MemberDTO> members) 
        {
            dataGridView.Rows.Clear();

            foreach (var member in members)
            {
                int rowIndex = dataGridView.Rows.Add(
                    member.MemberId,
                    member.FullName,
                    member.Birthday.ToString("dd/MM/yyyy"),
                    member.PhoneNumber,
                    member.Email,
                    member.Department,
                    member.Major,
                    member.Class
                );

                if (_currentMemberID.HasValue && member.MemberId == _currentMemberID.Value)
                {
                    dataGridView.Rows[rowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void txtTKMaTV_TextChanged(object sender, EventArgs e)
        {
            loadData(memberBLL.getAll().Where(m => m.MemberId.ToString().Contains(txtTKMaTV.Text)).ToList());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTKMaTV.Text = string.Empty;
            LoadData();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedMemberID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["MemberId"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
