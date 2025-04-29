namespace QuanLyThuQuan.Forms
{
    partial class ReservationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDisReservationInLib = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtReturnTimeAttachment = new System.Windows.Forms.TextBox();
            this.lblReturnTime = new System.Windows.Forms.Label();
            this.dtpDueTime = new System.Windows.Forms.DateTimePicker();
            this.lblDueTime = new System.Windows.Forms.Label();
            this.dtpReservationTime = new System.Windows.Forms.DateTimePicker();
            this.lblReservationTime = new System.Windows.Forms.Label();
            this.cboReservationType = new System.Windows.Forms.ComboBox();
            this.lblReservationType = new System.Windows.Forms.Label();
            this.dtpCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtSeatID = new System.Windows.Forms.TextBox();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.txtReservationID = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSeatID = new System.Windows.Forms.Label();
            this.lblMemberID = new System.Windows.Forms.Label();
            this.lblReservationID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboSearchCategory = new System.Windows.Forms.ComboBox();
            this.lblSearchCategory = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.lblDisReservationInLib);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // lblDisReservationInLib
            // 
            this.lblDisReservationInLib.AutoSize = true;
            this.lblDisReservationInLib.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisReservationInLib.ForeColor = System.Drawing.Color.White;
            this.lblDisReservationInLib.Location = new System.Drawing.Point(12, 58);
            this.lblDisReservationInLib.Name = "lblDisReservationInLib";
            this.lblDisReservationInLib.Size = new System.Drawing.Size(380, 30);
            this.lblDisReservationInLib.TabIndex = 1;
            this.lblDisReservationInLib.Text = "DANH SÁCH ĐẶT MƯỢN THƯ QUÁN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐẶT MƯỢN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtReturnTimeAttachment);
            this.panel2.Controls.Add(this.lblReturnTime);
            this.panel2.Controls.Add(this.dtpDueTime);
            this.panel2.Controls.Add(this.lblDueTime);
            this.panel2.Controls.Add(this.dtpReservationTime);
            this.panel2.Controls.Add(this.lblReservationTime);
            this.panel2.Controls.Add(this.cboReservationType);
            this.panel2.Controls.Add(this.lblReservationType);
            this.panel2.Controls.Add(this.dtpCreatedAt);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.txtSeatID);
            this.panel2.Controls.Add(this.txtMemberID);
            this.panel2.Controls.Add(this.txtReservationID);
            this.panel2.Controls.Add(this.lblCreatedAt);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.lblSeatID);
            this.panel2.Controls.Add(this.lblMemberID);
            this.panel2.Controls.Add(this.lblReservationID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 200);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtReturnTimeAttachment
            // 
            this.txtReturnTimeAttachment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnTimeAttachment.Location = new System.Drawing.Point(600, 110);
            this.txtReturnTimeAttachment.Name = "txtReturnTimeAttachment";
            this.txtReturnTimeAttachment.Size = new System.Drawing.Size(200, 29);
            this.txtReturnTimeAttachment.TabIndex = 17;
            // 
            // lblReturnTime
            // 
            this.lblReturnTime.AutoSize = true;
            this.lblReturnTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnTime.Location = new System.Drawing.Point(500, 115);
            this.lblReturnTime.Name = "lblReturnTime";
            this.lblReturnTime.Size = new System.Drawing.Size(101, 21);
            this.lblReturnTime.TabIndex = 16;
            this.lblReturnTime.Text = "Thời gian trả:";
            // 
            // dtpDueTime
            // 
            this.dtpDueTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDueTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDueTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueTime.Location = new System.Drawing.Point(600, 70);
            this.dtpDueTime.Name = "dtpDueTime";
            this.dtpDueTime.Size = new System.Drawing.Size(200, 29);
            this.dtpDueTime.TabIndex = 15;
            // 
            // lblDueTime
            // 
            this.lblDueTime.AutoSize = true;
            this.lblDueTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueTime.Location = new System.Drawing.Point(500, 75);
            this.lblDueTime.Name = "lblDueTime";
            this.lblDueTime.Size = new System.Drawing.Size(74, 21);
            this.lblDueTime.TabIndex = 14;
            this.lblDueTime.Text = "Thời hạn:";
            // 
            // dtpReservationTime
            // 
            this.dtpReservationTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpReservationTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReservationTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReservationTime.Location = new System.Drawing.Point(600, 30);
            this.dtpReservationTime.Name = "dtpReservationTime";
            this.dtpReservationTime.Size = new System.Drawing.Size(200, 29);
            this.dtpReservationTime.TabIndex = 13;
            // 
            // lblReservationTime
            // 
            this.lblReservationTime.AutoSize = true;
            this.lblReservationTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationTime.Location = new System.Drawing.Point(500, 35);
            this.lblReservationTime.Name = "lblReservationTime";
            this.lblReservationTime.Size = new System.Drawing.Size(104, 21);
            this.lblReservationTime.TabIndex = 12;
            this.lblReservationTime.Text = "Thời gian đặt:";
            // 
            // cboReservationType
            // 
            this.cboReservationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReservationType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReservationType.FormattingEnabled = true;
            this.cboReservationType.Location = new System.Drawing.Point(200, 110);
            this.cboReservationType.Name = "cboReservationType";
            this.cboReservationType.Size = new System.Drawing.Size(200, 29);
            this.cboReservationType.TabIndex = 11;
            this.cboReservationType.SelectedIndexChanged += new System.EventHandler(this.cboReservationType_SelectedIndexChanged);
            // 
            // lblReservationType
            // 
            this.lblReservationType.AutoSize = true;
            this.lblReservationType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationType.Location = new System.Drawing.Point(50, 115);
            this.lblReservationType.Name = "lblReservationType";
            this.lblReservationType.Size = new System.Drawing.Size(97, 21);
            this.lblReservationType.TabIndex = 10;
            this.lblReservationType.Text = "Loại đặt chỗ:";
            // 
            // dtpCreatedAt
            // 
            this.dtpCreatedAt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedAt.Location = new System.Drawing.Point(600, 150);
            this.dtpCreatedAt.Name = "dtpCreatedAt";
            this.dtpCreatedAt.Size = new System.Drawing.Size(200, 29);
            this.dtpCreatedAt.TabIndex = 9;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(200, 150);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 29);
            this.cboStatus.TabIndex = 8;
            // 
            // txtSeatID
            // 
            this.txtSeatID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeatID.Location = new System.Drawing.Point(200, 70);
            this.txtSeatID.Name = "txtSeatID";
            this.txtSeatID.Size = new System.Drawing.Size(100, 29);
            this.txtSeatID.TabIndex = 7;
            // 
            // txtMemberID
            // 
            this.txtMemberID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberID.Location = new System.Drawing.Point(200, 30);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(100, 29);
            this.txtMemberID.TabIndex = 6;
            // 
            // txtReservationID
            // 
            this.txtReservationID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationID.Location = new System.Drawing.Point(50, 30);
            this.txtReservationID.Name = "txtReservationID";
            this.txtReservationID.ReadOnly = true;
            this.txtReservationID.Size = new System.Drawing.Size(0, 29);
            this.txtReservationID.TabIndex = 5;
            this.txtReservationID.Visible = false;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedAt.Location = new System.Drawing.Point(500, 155);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(76, 21);
            this.lblCreatedAt.TabIndex = 4;
            this.lblCreatedAt.Text = "Ngày tạo:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(50, 155);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 21);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblSeatID
            // 
            this.lblSeatID.AutoSize = true;
            this.lblSeatID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeatID.Location = new System.Drawing.Point(50, 75);
            this.lblSeatID.Name = "lblSeatID";
            this.lblSeatID.Size = new System.Drawing.Size(65, 21);
            this.lblSeatID.TabIndex = 2;
            this.lblSeatID.Text = "Mã ghế:";
            // 
            // lblMemberID
            // 
            this.lblMemberID.AutoSize = true;
            this.lblMemberID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberID.Location = new System.Drawing.Point(50, 35);
            this.lblMemberID.Name = "lblMemberID";
            this.lblMemberID.Size = new System.Drawing.Size(112, 21);
            this.lblMemberID.TabIndex = 1;
            this.lblMemberID.Text = "Mã thành viên:";
            // 
            // lblReservationID
            // 
            this.lblReservationID.AutoSize = true;
            this.lblReservationID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationID.Location = new System.Drawing.Point(50, 35);
            this.lblReservationID.Name = "lblReservationID";
            this.lblReservationID.Size = new System.Drawing.Size(0, 21);
            this.lblReservationID.TabIndex = 0;
            this.lblReservationID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.cboSearchCategory);
            this.panel3.Controls.Add(this.lblSearchCategory);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.lblSearch);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1184, 60);
            this.panel3.TabIndex = 2;
            // 
            // cboSearchCategory
            // 
            this.cboSearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchCategory.FormattingEnabled = true;
            this.cboSearchCategory.Location = new System.Drawing.Point(670, 17);
            this.cboSearchCategory.Name = "cboSearchCategory";
            this.cboSearchCategory.Size = new System.Drawing.Size(150, 29);
            this.cboSearchCategory.TabIndex = 8;
            this.cboSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cboSearchCategory_SelectedIndexChanged);
            // 
            // lblSearchCategory
            // 
            this.lblSearchCategory.AutoSize = true;
            this.lblSearchCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCategory.Location = new System.Drawing.Point(580, 20);
            this.lblSearchCategory.Name = "lblSearchCategory";
            this.lblSearchCategory.Size = new System.Drawing.Size(74, 21);
            this.lblSearchCategory.TabIndex = 7;
            this.lblSearchCategory.Text = "Tìm theo:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(460, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(850, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 29);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(830, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(13, 21);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = ":";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(350, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(240, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(130, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 360);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1184, 301);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đặt Chỗ - Thư Quán";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDisReservationInLib;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblReservationID;
        private System.Windows.Forms.Label lblMemberID;
        private System.Windows.Forms.Label lblSeatID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.TextBox txtReservationID;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.TextBox txtSeatID;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpCreatedAt;
        private System.Windows.Forms.Label lblReservationType;
        private System.Windows.Forms.ComboBox cboReservationType;
        private System.Windows.Forms.Label lblReservationTime;
        private System.Windows.Forms.DateTimePicker dtpReservationTime;
        private System.Windows.Forms.Label lblDueTime;
        private System.Windows.Forms.DateTimePicker dtpDueTime;
        private System.Windows.Forms.Label lblReturnTime;
        private System.Windows.Forms.TextBox txtReturnTimeAttachment;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSearchCategory;
        private System.Windows.Forms.ComboBox cboSearchCategory;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}