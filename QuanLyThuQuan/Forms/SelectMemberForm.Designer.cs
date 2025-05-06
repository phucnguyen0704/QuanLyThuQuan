namespace QuanLyThuQuan.Forms
{
    partial class SelectMemberForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDSTV = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.flpnTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTKMaTV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.flpnTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDSTV
            // 
            this.lblDSTV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lblDSTV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDSTV.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDSTV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDSTV.Location = new System.Drawing.Point(0, 0);
            this.lblDSTV.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDSTV.Name = "lblDSTV";
            this.lblDSTV.Size = new System.Drawing.Size(1384, 68);
            this.lblDSTV.TabIndex = 0;
            this.lblDSTV.Text = "Danh sách thành viên";
            this.lblDSTV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHuongDan.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHuongDan.Location = new System.Drawing.Point(0, 68);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(1384, 31);
            this.lblHuongDan.TabIndex = 1;
            this.lblHuongDan.Text = "Nhấp chuột 2 lần để chọn";
            this.lblHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flpnTimKiem
            // 
            this.flpnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpnTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpnTimKiem.Controls.Add(this.btnLamMoi);
            this.flpnTimKiem.Controls.Add(this.txtTKMaTV);
            this.flpnTimKiem.Controls.Add(this.label2);
            this.flpnTimKiem.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpnTimKiem.Location = new System.Drawing.Point(0, 102);
            this.flpnTimKiem.Name = "flpnTimKiem";
            this.flpnTimKiem.Size = new System.Drawing.Size(1384, 40);
            this.flpnTimKiem.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLamMoi.Location = new System.Drawing.Point(1270, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 35);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTKMaTV
            // 
            this.txtTKMaTV.Location = new System.Drawing.Point(1088, 6);
            this.txtTKMaTV.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtTKMaTV.Name = "txtTKMaTV";
            this.txtTKMaTV.Size = new System.Drawing.Size(176, 29);
            this.txtTKMaTV.TabIndex = 5;
            this.txtTKMaTV.TextChanged += new System.EventHandler(this.txtTKMaTV_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(815, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm kiếm theo mã thành viên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 144);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(1384, 519);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // SelectMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.flpnTimKiem);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.lblDSTV);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1400, 700);
            this.Name = "SelectMemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thành viên";
            this.flpnTimKiem.ResumeLayout(false);
            this.flpnTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDSTV;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.FlowLayoutPanel flpnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTKMaTV;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}