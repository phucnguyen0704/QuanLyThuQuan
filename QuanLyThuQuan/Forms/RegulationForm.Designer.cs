namespace QuanLyThuQuan.Forms
{
    partial class RegulationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpnID = new System.Windows.Forms.FlowLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.flpnTen = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.flpnTheLoai = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.flpnMoTa = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.richTxtMoTa = new System.Windows.Forms.RichTextBox();
            this.flpnNgayTao = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.dateNgayTao = new System.Windows.Forms.DateTimePicker();
            this.flpnButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblThongtin = new System.Windows.Forms.Label();
            this.pnRight = new System.Windows.Forms.Panel();
            this.flpnTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flpnID.SuspendLayout();
            this.flpnTen.SuspendLayout();
            this.flpnTheLoai.SuspendLayout();
            this.flpnMoTa.SuspendLayout();
            this.flpnNgayTao.SuspendLayout();
            this.flpnButtonGroup.SuspendLayout();
            this.pnRight.SuspendLayout();
            this.flpnTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1370, 85);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Quản lý quy định";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(4, 90);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnRight);
            this.splitContainer.Size = new System.Drawing.Size(1471, 663);
            this.splitContainer.SplitterDistance = 490;
            this.splitContainer.SplitterWidth = 7;
            this.splitContainer.TabIndex = 3;
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.flowLayoutPanel1);
            this.pnLeft.Controls.Add(this.lblThongtin);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(490, 663);
            this.pnLeft.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.flpnID);
            this.flowLayoutPanel1.Controls.Add(this.flpnTen);
            this.flowLayoutPanel1.Controls.Add(this.flpnTheLoai);
            this.flowLayoutPanel1.Controls.Add(this.flpnMoTa);
            this.flowLayoutPanel1.Controls.Add(this.flpnNgayTao);
            this.flowLayoutPanel1.Controls.Add(this.flpnButtonGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(490, 612);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // flpnID
            // 
            this.flpnID.Controls.Add(this.lblID);
            this.flpnID.Controls.Add(this.txtID);
            this.flpnID.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnID.Location = new System.Drawing.Point(3, 3);
            this.flpnID.Name = "flpnID";
            this.flpnID.Size = new System.Drawing.Size(483, 50);
            this.flpnID.TabIndex = 25;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.BackColor = System.Drawing.SystemColors.Control;
            this.lblID.Location = new System.Drawing.Point(5, 10);
            this.lblID.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(65, 30);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(80, 10);
            this.txtID.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(391, 29);
            this.txtID.TabIndex = 3;
            this.txtID.TabStop = false;
            // 
            // flpnTen
            // 
            this.flpnTen.Controls.Add(this.lblTen);
            this.flpnTen.Controls.Add(this.txtTen);
            this.flpnTen.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnTen.Location = new System.Drawing.Point(3, 59);
            this.flpnTen.Name = "flpnTen";
            this.flpnTen.Size = new System.Drawing.Size(483, 50);
            this.flpnTen.TabIndex = 26;
            // 
            // lblTen
            // 
            this.lblTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen.BackColor = System.Drawing.SystemColors.Control;
            this.lblTen.Location = new System.Drawing.Point(5, 10);
            this.lblTen.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(65, 30);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên:";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.Location = new System.Drawing.Point(80, 10);
            this.txtTen.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(393, 29);
            this.txtTen.TabIndex = 2;
            this.txtTen.TabStop = false;
            // 
            // flpnTheLoai
            // 
            this.flpnTheLoai.Controls.Add(this.lblLoai);
            this.flpnTheLoai.Controls.Add(this.txtLoai);
            this.flpnTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnTheLoai.Location = new System.Drawing.Point(3, 115);
            this.flpnTheLoai.Name = "flpnTheLoai";
            this.flpnTheLoai.Size = new System.Drawing.Size(483, 50);
            this.flpnTheLoai.TabIndex = 27;
            // 
            // lblLoai
            // 
            this.lblLoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLoai.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoai.Location = new System.Drawing.Point(5, 10);
            this.lblLoai.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(65, 30);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại:";
            this.lblLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoai
            // 
            this.txtLoai.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtLoai.BackColor = System.Drawing.Color.White;
            this.txtLoai.Location = new System.Drawing.Point(80, 10);
            this.txtLoai.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.ReadOnly = true;
            this.txtLoai.Size = new System.Drawing.Size(393, 29);
            this.txtLoai.TabIndex = 3;
            this.txtLoai.TabStop = false;
            // 
            // flpnMoTa
            // 
            this.flpnMoTa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnMoTa.Controls.Add(this.lblMoTa);
            this.flpnMoTa.Controls.Add(this.richTxtMoTa);
            this.flpnMoTa.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpnMoTa.Location = new System.Drawing.Point(3, 171);
            this.flpnMoTa.Name = "flpnMoTa";
            this.flpnMoTa.Size = new System.Drawing.Size(483, 140);
            this.flpnMoTa.TabIndex = 28;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMoTa.Location = new System.Drawing.Point(5, 10);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(466, 30);
            this.lblMoTa.TabIndex = 0;
            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // richTxtMoTa
            // 
            this.richTxtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtMoTa.BackColor = System.Drawing.Color.White;
            this.richTxtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTxtMoTa.Location = new System.Drawing.Point(5, 43);
            this.richTxtMoTa.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.richTxtMoTa.Name = "richTxtMoTa";
            this.richTxtMoTa.Size = new System.Drawing.Size(468, 84);
            this.richTxtMoTa.TabIndex = 2;
            this.richTxtMoTa.TabStop = false;
            this.richTxtMoTa.Text = "";
            // 
            // flpnNgayTao
            // 
            this.flpnNgayTao.Controls.Add(this.lblNgayTao);
            this.flpnNgayTao.Controls.Add(this.dateNgayTao);
            this.flpnNgayTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnNgayTao.Location = new System.Drawing.Point(3, 317);
            this.flpnNgayTao.Name = "flpnNgayTao";
            this.flpnNgayTao.Size = new System.Drawing.Size(483, 50);
            this.flpnNgayTao.TabIndex = 29;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgayTao.Location = new System.Drawing.Point(5, 10);
            this.lblNgayTao.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(90, 30);
            this.lblNgayTao.TabIndex = 0;
            this.lblNgayTao.Text = "Ngày tạo:";
            this.lblNgayTao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateNgayTao
            // 
            this.dateNgayTao.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateNgayTao.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dateNgayTao.Enabled = false;
            this.dateNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayTao.Location = new System.Drawing.Point(105, 10);
            this.dateNgayTao.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.dateNgayTao.Name = "dateNgayTao";
            this.dateNgayTao.Size = new System.Drawing.Size(366, 29);
            this.dateNgayTao.TabIndex = 4;
            this.dateNgayTao.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // flpnButtonGroup
            // 
            this.flpnButtonGroup.Controls.Add(this.btnXoa);
            this.flpnButtonGroup.Controls.Add(this.btnChinhSua);
            this.flpnButtonGroup.Controls.Add(this.btnThem);
            this.flpnButtonGroup.Controls.Add(this.btnHuy);
            this.flpnButtonGroup.Controls.Add(this.btnLuu);
            this.flpnButtonGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnButtonGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpnButtonGroup.Location = new System.Drawing.Point(3, 373);
            this.flpnButtonGroup.Name = "flpnButtonGroup";
            this.flpnButtonGroup.Size = new System.Drawing.Size(483, 133);
            this.flpnButtonGroup.TabIndex = 30;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(359, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(121, 40);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnChinhSua.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChinhSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnChinhSua.FlatAppearance.BorderSize = 0;
            this.btnChinhSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChinhSua.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChinhSua.ForeColor = System.Drawing.Color.Black;
            this.btnChinhSua.Location = new System.Drawing.Point(232, 3);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(121, 40);
            this.btnChinhSua.TabIndex = 4;
            this.btnChinhSua.Text = "Chỉnh sửa";
            this.btnChinhSua.UseVisualStyleBackColor = false;
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnThem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(105, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(121, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnHuy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(359, 49);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(121, 40);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(232, 49);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(121, 40);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblThongtin
            // 
            this.lblThongtin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lblThongtin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongtin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThongtin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblThongtin.Location = new System.Drawing.Point(0, 0);
            this.lblThongtin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.lblThongtin.Name = "lblThongtin";
            this.lblThongtin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblThongtin.Size = new System.Drawing.Size(490, 51);
            this.lblThongtin.TabIndex = 18;
            this.lblThongtin.Text = "Thông tin quy định";
            this.lblThongtin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnRight
            // 
            this.pnRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnRight.Controls.Add(this.flpnTimKiem);
            this.pnRight.Controls.Add(this.dataGridView);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(0, 0);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(974, 663);
            this.pnRight.TabIndex = 0;
            // 
            // flpnTimKiem
            // 
            this.flpnTimKiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnTimKiem.Controls.Add(this.btnLamMoi);
            this.flpnTimKiem.Controls.Add(this.txtTimKiem);
            this.flpnTimKiem.Controls.Add(this.lblTimKiem);
            this.flpnTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnTimKiem.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpnTimKiem.Location = new System.Drawing.Point(0, 0);
            this.flpnTimKiem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flpnTimKiem.Name = "flpnTimKiem";
            this.flpnTimKiem.Size = new System.Drawing.Size(972, 51);
            this.flpnTimKiem.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(848, 6);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(121, 34);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTimKiem.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.Location = new System.Drawing.Point(634, 11);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(206, 29);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTimKiem.Location = new System.Drawing.Point(18, 3);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(611, 43);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm theo tên:";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 55);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(972, 606);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // RegulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1364, 718);
            this.Name = "RegulationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quy định";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnLeft.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flpnID.ResumeLayout(false);
            this.flpnID.PerformLayout();
            this.flpnTen.ResumeLayout(false);
            this.flpnTen.PerformLayout();
            this.flpnTheLoai.ResumeLayout(false);
            this.flpnTheLoai.PerformLayout();
            this.flpnMoTa.ResumeLayout(false);
            this.flpnNgayTao.ResumeLayout(false);
            this.flpnButtonGroup.ResumeLayout(false);
            this.pnRight.ResumeLayout(false);
            this.flpnTimKiem.ResumeLayout(false);
            this.flpnTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpnID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.FlowLayoutPanel flpnTen;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.FlowLayoutPanel flpnButtonGroup;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.FlowLayoutPanel flpnTheLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.FlowLayoutPanel flpnMoTa;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.RichTextBox richTxtMoTa;
        private System.Windows.Forms.FlowLayoutPanel flpnNgayTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.DateTimePicker dateNgayTao;
        private System.Windows.Forms.Label lblThongtin;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.FlowLayoutPanel flpnTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}