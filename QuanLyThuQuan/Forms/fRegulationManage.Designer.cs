namespace QuanLyThuQuan.Forms
{
    partial class fRegulationManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flPnContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.flpnLeftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblThongtin = new System.Windows.Forms.Label();
            this.flpnThongTin = new System.Windows.Forms.FlowLayoutPanel();
            this.flpnID = new System.Windows.Forms.FlowLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.flpnTen = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTen = new System.Windows.Forms.Label();
            this.flpnTheLoai = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLoai = new System.Windows.Forms.Label();
            this.flpnMoTa = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.richTxtMoTa = new System.Windows.Forms.RichTextBox();
            this.flpnNgayTao = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.dateNgayTao = new System.Windows.Forms.DateTimePicker();
            this.flpnButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.flpnRightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flpnTimKiem = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.flPnContent.SuspendLayout();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flpnLeftPanel.SuspendLayout();
            this.flpnThongTin.SuspendLayout();
            this.flpnID.SuspendLayout();
            this.flpnTen.SuspendLayout();
            this.flpnTheLoai.SuspendLayout();
            this.flpnMoTa.SuspendLayout();
            this.flpnNgayTao.SuspendLayout();
            this.flpnButtonGroup.SuspendLayout();
            this.flpnRightPanel.SuspendLayout();
            this.flpnTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // flPnContent
            // 
            this.flPnContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flPnContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flPnContent.Controls.Add(this.pnHeader);
            this.flPnContent.Controls.Add(this.splitContainer);
            this.flPnContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flPnContent.Location = new System.Drawing.Point(0, 0);
            this.flPnContent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flPnContent.Name = "flPnContent";
            this.flPnContent.Size = new System.Drawing.Size(1467, 764);
            this.flPnContent.TabIndex = 0;
            // 
            // pnHeader
            // 
            this.pnHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnHeader.BackColor = System.Drawing.Color.White;
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Location = new System.Drawing.Point(6, 5);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1461, 85);
            this.pnHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(28, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1461, 85);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý quy định";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(6, 100);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.flpnLeftPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.flpnRightPanel);
            this.splitContainer.Size = new System.Drawing.Size(1461, 621);
            this.splitContainer.SplitterDistance = 487;
            this.splitContainer.SplitterWidth = 7;
            this.splitContainer.TabIndex = 1;
            // 
            // flpnLeftPanel
            // 
            this.flpnLeftPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnLeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpnLeftPanel.Controls.Add(this.lblThongtin);
            this.flpnLeftPanel.Controls.Add(this.flpnThongTin);
            this.flpnLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnLeftPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpnLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.flpnLeftPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flpnLeftPanel.Name = "flpnLeftPanel";
            this.flpnLeftPanel.Size = new System.Drawing.Size(487, 621);
            this.flpnLeftPanel.TabIndex = 0;
            // 
            // lblThongtin
            // 
            this.lblThongtin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblThongtin.BackColor = System.Drawing.Color.White;
            this.lblThongtin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThongtin.Location = new System.Drawing.Point(5, 5);
            this.lblThongtin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.lblThongtin.Name = "lblThongtin";
            this.lblThongtin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblThongtin.Size = new System.Drawing.Size(475, 51);
            this.lblThongtin.TabIndex = 0;
            this.lblThongtin.Text = "Thông tin quy định";
            this.lblThongtin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpnThongTin
            // 
            this.flpnThongTin.Controls.Add(this.flpnID);
            this.flpnThongTin.Controls.Add(this.flpnTen);
            this.flpnThongTin.Controls.Add(this.flpnTheLoai);
            this.flpnThongTin.Controls.Add(this.flpnMoTa);
            this.flpnThongTin.Controls.Add(this.flpnNgayTao);
            this.flpnThongTin.Controls.Add(this.flpnButtonGroup);
            this.flpnThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpnThongTin.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpnThongTin.Location = new System.Drawing.Point(6, 61);
            this.flpnThongTin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flpnThongTin.Name = "flpnThongTin";
            this.flpnThongTin.Size = new System.Drawing.Size(473, 527);
            this.flpnThongTin.TabIndex = 1;
            // 
            // flpnID
            // 
            this.flpnID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpnID.Controls.Add(this.lblID);
            this.flpnID.Controls.Add(this.textBox1);
            this.flpnID.Location = new System.Drawing.Point(3, 3);
            this.flpnID.Name = "flpnID";
            this.flpnID.Size = new System.Drawing.Size(469, 50);
            this.flpnID.TabIndex = 0;
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
            // flpnTen
            // 
            this.flpnTen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpnTen.Controls.Add(this.lblTen);
            this.flpnTen.Controls.Add(this.txtTen);
            this.flpnTen.Location = new System.Drawing.Point(3, 59);
            this.flpnTen.Name = "flpnTen";
            this.flpnTen.Size = new System.Drawing.Size(469, 50);
            this.flpnTen.TabIndex = 2;
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
            // flpnTheLoai
            // 
            this.flpnTheLoai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpnTheLoai.Controls.Add(this.lblLoai);
            this.flpnTheLoai.Controls.Add(this.txtLoai);
            this.flpnTheLoai.Location = new System.Drawing.Point(3, 115);
            this.flpnTheLoai.Name = "flpnTheLoai";
            this.flpnTheLoai.Size = new System.Drawing.Size(469, 50);
            this.flpnTheLoai.TabIndex = 3;
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
            // flpnMoTa
            // 
            this.flpnMoTa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpnMoTa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnMoTa.Controls.Add(this.lblMoTa);
            this.flpnMoTa.Controls.Add(this.richTxtMoTa);
            this.flpnMoTa.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpnMoTa.Location = new System.Drawing.Point(3, 171);
            this.flpnMoTa.Name = "flpnMoTa";
            this.flpnMoTa.Size = new System.Drawing.Size(469, 160);
            this.flpnMoTa.TabIndex = 3;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMoTa.Location = new System.Drawing.Point(5, 10);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(65, 30);
            this.lblMoTa.TabIndex = 0;
            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // richTxtMoTa
            // 
            this.richTxtMoTa.BackColor = System.Drawing.Color.White;
            this.richTxtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTxtMoTa.Location = new System.Drawing.Point(3, 43);
            this.richTxtMoTa.Name = "richTxtMoTa";
            this.richTxtMoTa.Size = new System.Drawing.Size(456, 84);
            this.richTxtMoTa.TabIndex = 2;
            this.richTxtMoTa.Text = "";
            // 
            // flpnNgayTao
            // 
            this.flpnNgayTao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpnNgayTao.Controls.Add(this.lblNgayTao);
            this.flpnNgayTao.Controls.Add(this.dateNgayTao);
            this.flpnNgayTao.Location = new System.Drawing.Point(3, 337);
            this.flpnNgayTao.Name = "flpnNgayTao";
            this.flpnNgayTao.Size = new System.Drawing.Size(469, 50);
            this.flpnNgayTao.TabIndex = 3;
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
            this.dateNgayTao.Size = new System.Drawing.Size(354, 29);
            this.dateNgayTao.TabIndex = 4;
            this.dateNgayTao.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // flpnButtonGroup
            // 
            this.flpnButtonGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnButtonGroup.Controls.Add(this.btnLuu);
            this.flpnButtonGroup.Controls.Add(this.btnChinhSua);
            this.flpnButtonGroup.Controls.Add(this.btnThem);
            this.flpnButtonGroup.Controls.Add(this.btnHuy);
            this.flpnButtonGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpnButtonGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpnButtonGroup.Location = new System.Drawing.Point(3, 393);
            this.flpnButtonGroup.Name = "flpnButtonGroup";
            this.flpnButtonGroup.Size = new System.Drawing.Size(469, 119);
            this.flpnButtonGroup.TabIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(345, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(121, 40);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
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
            this.btnChinhSua.Location = new System.Drawing.Point(218, 3);
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
            this.btnThem.Location = new System.Drawing.Point(91, 3);
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
            this.btnHuy.Location = new System.Drawing.Point(345, 49);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(121, 40);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // flpnRightPanel
            // 
            this.flpnRightPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnRightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpnRightPanel.Controls.Add(this.flpnTimKiem);
            this.flpnRightPanel.Controls.Add(this.dataGridView);
            this.flpnRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnRightPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpnRightPanel.Location = new System.Drawing.Point(0, 0);
            this.flpnRightPanel.Name = "flpnRightPanel";
            this.flpnRightPanel.Size = new System.Drawing.Size(967, 621);
            this.flpnRightPanel.TabIndex = 0;
            // 
            // flpnTimKiem
            // 
            this.flpnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpnTimKiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnTimKiem.Controls.Add(this.lblTimKiem);
            this.flpnTimKiem.Controls.Add(this.txtTimKiem);
            this.flpnTimKiem.Location = new System.Drawing.Point(6, 5);
            this.flpnTimKiem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flpnTimKiem.Name = "flpnTimKiem";
            this.flpnTimKiem.Size = new System.Drawing.Size(954, 51);
            this.flpnTimKiem.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTimKiem.Location = new System.Drawing.Point(0, 3);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(729, 43);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm theo tên:";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTimKiem.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.Location = new System.Drawing.Point(734, 11);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(206, 29);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(3, 64);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.Size = new System.Drawing.Size(960, 536);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(80, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(379, 29);
            this.textBox1.TabIndex = 3;
            // 
            // txtLoai
            // 
            this.txtLoai.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtLoai.BackColor = System.Drawing.Color.White;
            this.txtLoai.Location = new System.Drawing.Point(80, 10);
            this.txtLoai.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.ReadOnly = true;
            this.txtLoai.Size = new System.Drawing.Size(379, 29);
            this.txtLoai.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.Location = new System.Drawing.Point(80, 10);
            this.txtTen.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(379, 29);
            this.txtTen.TabIndex = 2;
            // 
            // fRegulationManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 762);
            this.Controls.Add(this.flPnContent);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1480, 800);
            this.Name = "fRegulationManage";
            this.Text = "Quản lý quy định";
            this.flPnContent.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.flpnLeftPanel.ResumeLayout(false);
            this.flpnThongTin.ResumeLayout(false);
            this.flpnID.ResumeLayout(false);
            this.flpnID.PerformLayout();
            this.flpnTen.ResumeLayout(false);
            this.flpnTen.PerformLayout();
            this.flpnTheLoai.ResumeLayout(false);
            this.flpnTheLoai.PerformLayout();
            this.flpnMoTa.ResumeLayout(false);
            this.flpnNgayTao.ResumeLayout(false);
            this.flpnButtonGroup.ResumeLayout(false);
            this.flpnRightPanel.ResumeLayout(false);
            this.flpnTimKiem.ResumeLayout(false);
            this.flpnTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flPnContent;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.FlowLayoutPanel flpnLeftPanel;
        private System.Windows.Forms.Label lblThongtin;
        private System.Windows.Forms.FlowLayoutPanel flpnThongTin;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.FlowLayoutPanel flpnID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.FlowLayoutPanel flpnTen;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.FlowLayoutPanel flpnTheLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.FlowLayoutPanel flpnMoTa;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.FlowLayoutPanel flpnNgayTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.DateTimePicker dateNgayTao;
        private System.Windows.Forms.FlowLayoutPanel flpnButtonGroup;
        private System.Windows.Forms.RichTextBox richTxtMoTa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.FlowLayoutPanel flpnRightPanel;
        private System.Windows.Forms.FlowLayoutPanel flpnTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.TextBox txtTen;
    }
}