namespace QuanLyThuQuan.Forms
{
    partial class SelectAvailableSeatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDSChoNgoi = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbTieuChiTim = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDSChoNgoi
            // 
            this.lblDSChoNgoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lblDSChoNgoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDSChoNgoi.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDSChoNgoi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDSChoNgoi.Location = new System.Drawing.Point(0, 0);
            this.lblDSChoNgoi.Name = "lblDSChoNgoi";
            this.lblDSChoNgoi.Size = new System.Drawing.Size(1384, 68);
            this.lblDSChoNgoi.TabIndex = 0;
            this.lblDSChoNgoi.Text = "Danh sách chỗ ngồi còn trống";
            this.lblDSChoNgoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHuongDan.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHuongDan.Location = new System.Drawing.Point(0, 68);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(1384, 31);
            this.lblHuongDan.TabIndex = 1;
            this.lblHuongDan.Text = "Nhấp chuột 2 lần để chọn";
            this.lblHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnLamMoi);
            this.flowLayoutPanel1.Controls.Add(this.txtTimKiem);
            this.flowLayoutPanel1.Controls.Add(this.cbTieuChiTim);
            this.flowLayoutPanel1.Controls.Add(this.lblTimKiem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 99);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1384, 40);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLamMoi.Location = new System.Drawing.Point(1270, 0);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 35);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(1088, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(176, 29);
            this.txtTimKiem.TabIndex = 6;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cbTieuChiTim
            // 
            this.cbTieuChiTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTieuChiTim.FormattingEnabled = true;
            this.cbTieuChiTim.Items.AddRange(new object[] {
            "Tên chỗ",
            "Mã chỗ"});
            this.cbTieuChiTim.Location = new System.Drawing.Point(961, 3);
            this.cbTieuChiTim.Name = "cbTieuChiTim";
            this.cbTieuChiTim.Size = new System.Drawing.Size(121, 30);
            this.cbTieuChiTim.TabIndex = 4;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Location = new System.Drawing.Point(817, 6);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(138, 35);
            this.lblTimKiem.TabIndex = 3;
            this.lblTimKiem.Text = "Tìm kiếm theo:";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // dataGridView
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 139);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(1384, 522);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // SelectAvailableSeatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.lblDSChoNgoi);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1400, 700);
            this.Name = "SelectAvailableSeatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chỗ ngồi";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDSChoNgoi;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTimKiem;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox cbTieuChiTim;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}