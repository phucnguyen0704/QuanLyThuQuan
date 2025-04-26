namespace QuanLyThuQuan
{
    partial class fMember
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
            this.btnNhapExcel = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.txtHoVaTen = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNgayDangKy = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblHovaTen = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.lbDanhSachThanhVien = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblNganh = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNhapExcel
            // 
            this.btnNhapExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNhapExcel.Location = new System.Drawing.Point(454, 382);
            this.btnNhapExcel.Name = "btnNhapExcel";
            this.btnNhapExcel.Size = new System.Drawing.Size(76, 49);
            this.btnNhapExcel.TabIndex = 51;
            this.btnNhapExcel.Text = "Nhập Excel";
            this.btnNhapExcel.UseCompatibleTextRendering = true;
            this.btnNhapExcel.UseVisualStyleBackColor = true;
            this.btnNhapExcel.Click += new System.EventHandler(this.btnNhapExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(699, 382);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(76, 49);
            this.btnThoat.TabIndex = 50;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseCompatibleTextRendering = true;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.Location = new System.Drawing.Point(617, 382);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 49);
            this.btnLuu.TabIndex = 49;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseCompatibleTextRendering = true;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXuatExcel.Location = new System.Drawing.Point(536, 382);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(76, 49);
            this.btnXuatExcel.TabIndex = 48;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseCompatibleTextRendering = true;
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(551, 177);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(224, 24);
            this.cboTrangThai.TabIndex = 47;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(168, 402);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(224, 24);
            this.cboVaiTro.TabIndex = 46;
            this.cboVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboVaiTro_SelectedIndexChanged);
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.Location = new System.Drawing.Point(168, 371);
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Size = new System.Drawing.Size(224, 22);
            this.dtpNgayDangKy.TabIndex = 45;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(168, 210);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(224, 22);
            this.dtpBirthday.TabIndex = 44;
            // 
            // txtDangNhap
            // 
            this.txtDangNhap.Location = new System.Drawing.Point(168, 243);
            this.txtDangNhap.Name = "txtDangNhap";
            this.txtDangNhap.Size = new System.Drawing.Size(224, 22);
            this.txtDangNhap.TabIndex = 43;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(168, 272);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(224, 22);
            this.txtMatKhau.TabIndex = 42;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(168, 341);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 22);
            this.txtEmail.TabIndex = 41;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(168, 305);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(224, 22);
            this.txtMemberId.TabIndex = 40;
            // 
            // txtHoVaTen
            // 
            this.txtHoVaTen.Location = new System.Drawing.Point(168, 177);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.Size = new System.Drawing.Size(224, 22);
            this.txtHoVaTen.TabIndex = 39;
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(18, 339);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(126, 22);
            this.lblEmail.TabIndex = 38;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNgayDangKy
            // 
            this.lblNgayDangKy.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNgayDangKy.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDangKy.Location = new System.Drawing.Point(18, 370);
            this.lblNgayDangKy.Name = "lblNgayDangKy";
            this.lblNgayDangKy.Size = new System.Drawing.Size(126, 22);
            this.lblNgayDangKy.TabIndex = 37;
            this.lblNgayDangKy.Text = "Ngày đăng kí:";
            this.lblNgayDangKy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblVaiTro.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaiTro.Location = new System.Drawing.Point(18, 402);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(126, 22);
            this.lblVaiTro.TabIndex = 36;
            this.lblVaiTro.Text = "Vai trò:";
            this.lblVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(404, 178);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(126, 22);
            this.lblTrangThai.TabIndex = 35;
            this.lblTrangThai.Text = "Trạng Thái:";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(18, 209);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(126, 22);
            this.lblNgaySinh.TabIndex = 34;
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblNgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblDangNhap.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.Location = new System.Drawing.Point(18, 241);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(126, 22);
            this.lblDangNhap.TabIndex = 33;
            this.lblDangNhap.Text = " Đăng nhập:";
            this.lblDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Location = new System.Drawing.Point(18, 272);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(126, 22);
            this.lblMatKhau.TabIndex = 32;
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblID.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(18, 305);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(126, 22);
            this.lblID.TabIndex = 31;
            this.lblID.Text = "ID:";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHovaTen
            // 
            this.lblHovaTen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblHovaTen.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHovaTen.Location = new System.Drawing.Point(18, 178);
            this.lblHovaTen.Name = "lblHovaTen";
            this.lblHovaTen.Size = new System.Drawing.Size(126, 22);
            this.lblHovaTen.TabIndex = 30;
            this.lblHovaTen.Text = "Họ và tên:";
            this.lblHovaTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(13, 70);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.RowTemplate.Height = 24;
            this.dgvMembers.Size = new System.Drawing.Size(775, 105);
            this.dgvMembers.TabIndex = 29;
            this.dgvMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellContentClick);
            // 
            // lbDanhSachThanhVien
            // 
            this.lbDanhSachThanhVien.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbDanhSachThanhVien.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDanhSachThanhVien.Location = new System.Drawing.Point(27, 19);
            this.lbDanhSachThanhVien.Name = "lbDanhSachThanhVien";
            this.lbDanhSachThanhVien.Size = new System.Drawing.Size(748, 48);
            this.lbDanhSachThanhVien.TabIndex = 28;
            this.lbDanhSachThanhVien.Text = "DANH SÁCH THÀNH VIÊN";
            this.lbDanhSachThanhVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKhoa
            // 
            this.lblKhoa.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoa.Location = new System.Drawing.Point(404, 241);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(126, 22);
            this.lblKhoa.TabIndex = 53;
            this.lblKhoa.Text = "Khoa:";
            this.lblKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLop
            // 
            this.lblLop.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblLop.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(404, 209);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(126, 22);
            this.lblLop.TabIndex = 54;
            this.lblLop.Text = "Lớp:";
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNganh
            // 
            this.lblNganh.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNganh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNganh.Location = new System.Drawing.Point(404, 272);
            this.lblNganh.Name = "lblNganh";
            this.lblNganh.Size = new System.Drawing.Size(126, 22);
            this.lblNganh.TabIndex = 55;
            this.lblNganh.Text = "Ngành:";
            this.lblNganh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(551, 209);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(224, 24);
            this.cboLop.TabIndex = 57;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // cboNganh
            // 
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(551, 268);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(224, 24);
            this.cboNganh.TabIndex = 58;
            this.cboNganh.SelectedIndexChanged += new System.EventHandler(this.cboNganh_SelectedIndexChanged);
            // 
            // cbKhoa
            // 
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(551, 238);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(224, 24);
            this.cbKhoa.TabIndex = 59;
            this.cbKhoa.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // fMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.cboNganh);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblNganh);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.btnNhapExcel);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.dtpNgayDangKy);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.txtDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.txtHoVaTen);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNgayDangKy);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblDangNhap);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblHovaTen);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.lbDanhSachThanhVien);
            this.Name = "fMember";
            this.Text = "fMember";
            this.Load += new System.EventHandler(this.fMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNhapExcel;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.TextBox txtDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNgayDangKy;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblHovaTen;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Label lbDanhSachThanhVien;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblNganh;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.ComboBox cbKhoa;
    }
}