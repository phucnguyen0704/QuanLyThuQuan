namespace QuanLyThanhVienMoi
{
    partial class FormSuaThanhVien
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
            this.dtpNgayDangKiSua = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuuSua = new System.Windows.Forms.Button();
            this.btnThoatSua = new System.Windows.Forms.Button();
            this.lblHovaTen = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtIdSua = new System.Windows.Forms.TextBox();
            this.txtEmailSua = new System.Windows.Forms.TextBox();
            this.txtHoVaTenSua = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpNgayDangKiSua
            // 
            this.dtpNgayDangKiSua.Location = new System.Drawing.Point(445, 41);
            this.dtpNgayDangKiSua.Name = "dtpNgayDangKiSua";
            this.dtpNgayDangKiSua.Size = new System.Drawing.Size(185, 22);
            this.dtpNgayDangKiSua.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(442, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "Ngày đăng kí";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLuuSua
            // 
            this.btnLuuSua.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLuuSua.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuSua.Location = new System.Drawing.Point(723, 397);
            this.btnLuuSua.Name = "btnLuuSua";
            this.btnLuuSua.Size = new System.Drawing.Size(75, 35);
            this.btnLuuSua.TabIndex = 27;
            this.btnLuuSua.Text = "Lưu";
            this.btnLuuSua.UseVisualStyleBackColor = false;
            this.btnLuuSua.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoatSua
            // 
            this.btnThoatSua.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnThoatSua.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatSua.Location = new System.Drawing.Point(642, 397);
            this.btnThoatSua.Name = "btnThoatSua";
            this.btnThoatSua.Size = new System.Drawing.Size(75, 35);
            this.btnThoatSua.TabIndex = 26;
            this.btnThoatSua.Text = "Thoát";
            this.btnThoatSua.UseVisualStyleBackColor = false;
            this.btnThoatSua.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblHovaTen
            // 
            this.lblHovaTen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblHovaTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHovaTen.ForeColor = System.Drawing.Color.Red;
            this.lblHovaTen.Location = new System.Drawing.Point(111, 19);
            this.lblHovaTen.Name = "lblHovaTen";
            this.lblHovaTen.Size = new System.Drawing.Size(176, 22);
            this.lblHovaTen.TabIndex = 25;
            this.lblHovaTen.Text = "Họ và tên";
            this.lblHovaTen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblEmail.ForeColor = System.Drawing.Color.Red;
            this.lblEmail.Location = new System.Drawing.Point(284, 19);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(163, 22);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblID.ForeColor = System.Drawing.Color.Red;
            this.lblID.Location = new System.Drawing.Point(3, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(110, 22);
            this.lblID.TabIndex = 23;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtIdSua
            // 
            this.txtIdSua.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtIdSua.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSua.ForeColor = System.Drawing.Color.Red;
            this.txtIdSua.Location = new System.Drawing.Point(3, 41);
            this.txtIdSua.Multiline = true;
            this.txtIdSua.Name = "txtIdSua";
            this.txtIdSua.Size = new System.Drawing.Size(110, 22);
            this.txtIdSua.TabIndex = 22;
            // 
            // txtEmailSua
            // 
            this.txtEmailSua.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEmailSua.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailSua.ForeColor = System.Drawing.Color.Red;
            this.txtEmailSua.Location = new System.Drawing.Point(287, 41);
            this.txtEmailSua.Multiline = true;
            this.txtEmailSua.Name = "txtEmailSua";
            this.txtEmailSua.Size = new System.Drawing.Size(162, 22);
            this.txtEmailSua.TabIndex = 21;
            // 
            // txtHoVaTenSua
            // 
            this.txtHoVaTenSua.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtHoVaTenSua.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoVaTenSua.ForeColor = System.Drawing.Color.Red;
            this.txtHoVaTenSua.Location = new System.Drawing.Point(111, 41);
            this.txtHoVaTenSua.Multiline = true;
            this.txtHoVaTenSua.Name = "txtHoVaTenSua";
            this.txtHoVaTenSua.Size = new System.Drawing.Size(176, 22);
            this.txtHoVaTenSua.TabIndex = 20;
            // 
            // FormSuaThanhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpNgayDangKiSua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuuSua);
            this.Controls.Add(this.btnThoatSua);
            this.Controls.Add(this.lblHovaTen);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtIdSua);
            this.Controls.Add(this.txtEmailSua);
            this.Controls.Add(this.txtHoVaTenSua);
            this.Name = "FormSuaThanhVien";
            this.Text = "Sửa Thành Viên";
            this.Load += new System.EventHandler(this.FormSuaThanhVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayDangKiSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuuSua;
        private System.Windows.Forms.Button btnThoatSua;
        private System.Windows.Forms.Label lblHovaTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtIdSua;
        private System.Windows.Forms.TextBox txtEmailSua;
        private System.Windows.Forms.TextBox txtHoVaTenSua;
    }
}