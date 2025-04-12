using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan
{
    public partial class fAccountProfile : Form
    {
        public fAccountProfile()
        {
            InitializeComponent();
        }

        void LoadAllAccount()
        {
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadAllAccount();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTypeUser.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTypeUserName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
               
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
