namespace QuanLyThuQuan.Forms
{
    partial class SelectAvailableDeviceForm
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
            this.lbDSThietBi = new System.Windows.Forms.Label();
            this.lbHuongDan = new System.Windows.Forms.Label();
            this.flpnTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbTieuChiTim = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnChon = new System.Windows.Forms.Button();
            this.flpnTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDSThietBi
            // 
            this.lbDSThietBi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lbDSThietBi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDSThietBi.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDSThietBi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbDSThietBi.Location = new System.Drawing.Point(0, 0);
            this.lbDSThietBi.Name = "lbDSThietBi";
            this.lbDSThietBi.Size = new System.Drawing.Size(1384, 68);
            this.lbDSThietBi.TabIndex = 0;
            this.lbDSThietBi.Text = "Danh sách thiết bị";
            this.lbDSThietBi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHuongDan
            // 
            this.lbHuongDan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbHuongDan.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbHuongDan.Location = new System.Drawing.Point(0, 68);
            this.lbHuongDan.Name = "lbHuongDan";
            this.lbHuongDan.Size = new System.Drawing.Size(1384, 31);
            this.lbHuongDan.TabIndex = 1;
            this.lbHuongDan.Text = "Giữ ctrl để chọn nhiều thiết bị";
            this.lbHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flpnTimKiem
            // 
            this.flpnTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpnTimKiem.Controls.Add(this.btnChon);
            this.flpnTimKiem.Controls.Add(this.btnLamMoi);
            this.flpnTimKiem.Controls.Add(this.txtTimKiem);
            this.flpnTimKiem.Controls.Add(this.cbTieuChiTim);
            this.flpnTimKiem.Controls.Add(this.lblTimKiem);
            this.flpnTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnTimKiem.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpnTimKiem.Location = new System.Drawing.Point(0, 99);
            this.flpnTimKiem.Name = "flpnTimKiem";
            this.flpnTimKiem.Size = new System.Drawing.Size(1384, 40);
            this.flpnTimKiem.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLamMoi.Location = new System.Drawing.Point(1155, 0);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 35);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(973, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(176, 29);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cbTieuChiTim
            // 
            this.cbTieuChiTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTieuChiTim.FormattingEnabled = true;
            this.cbTieuChiTim.Items.AddRange(new object[] {
            "Tên thiết bị",
            "Mã thiết bị"});
            this.cbTieuChiTim.Location = new System.Drawing.Point(846, 3);
            this.cbTieuChiTim.Name = "cbTieuChiTim";
            this.cbTieuChiTim.Size = new System.Drawing.Size(121, 30);
            this.cbTieuChiTim.TabIndex = 4;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Location = new System.Drawing.Point(702, 6);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(138, 35);
            this.lblTimKiem.TabIndex = 5;
            this.lblTimKiem.Text = "Tìm kiếm theo:";
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
            // 
            // btnChon
            // 
            this.btnChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChon.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChon.Location = new System.Drawing.Point(1270, 0);
            this.btnChon.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(109, 35);
            this.btnChon.TabIndex = 4;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = false;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // SelectAvailableDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.flpnTimKiem);
            this.Controls.Add(this.lbHuongDan);
            this.Controls.Add(this.lbDSThietBi);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1400, 700);
            this.Name = "SelectAvailableDeviceForm";
            this.Text = "Chọn thiết bị cần mượn";
            this.flpnTimKiem.ResumeLayout(false);
            this.flpnTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDSThietBi;
        private System.Windows.Forms.Label lbHuongDan;
        private System.Windows.Forms.FlowLayoutPanel flpnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox cbTieuChiTim;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnChon;
    }
}