// ReservationForm.Designer.cs
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpReservationTime = new System.Windows.Forms.DateTimePicker();
            this.richTxtDeviceIDList = new System.Windows.Forms.RichTextBox();
            this.btnChonThietBi = new System.Windows.Forms.Button();
            this.btnChonMaGhe = new System.Windows.Forms.Button();
            this.flpnButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDSMaThietBi = new System.Windows.Forms.Label();
            this.lblThongTinPhieuMuon = new System.Windows.Forms.Label();
            this.txtSeatID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblReturnTimeValue = new System.Windows.Forms.Label();
            this.lblReservationTimeValue = new System.Windows.Forms.Label();
            this.lblReturnTime = new System.Windows.Forms.Label();
            this.lblReservationTime = new System.Windows.Forms.Label();
            this.dtpCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDueTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboReservationType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReservationID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboSearchCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flpnButtonGroup.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 85);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ MƯỢN THIẾT BỊ/ CHỖ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.dtpReservationTime);
            this.panel2.Controls.Add(this.richTxtDeviceIDList);
            this.panel2.Controls.Add(this.btnChonThietBi);
            this.panel2.Controls.Add(this.btnChonMaGhe);
            this.panel2.Controls.Add(this.flpnButtonGroup);
            this.panel2.Controls.Add(this.lblDSMaThietBi);
            this.panel2.Controls.Add(this.lblThongTinPhieuMuon);
            this.panel2.Controls.Add(this.txtSeatID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblReturnTimeValue);
            this.panel2.Controls.Add(this.lblReservationTimeValue);
            this.panel2.Controls.Add(this.lblReturnTime);
            this.panel2.Controls.Add(this.lblReservationTime);
            this.panel2.Controls.Add(this.dtpCreatedAt);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dtpDueTime);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboReservationType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtMemberID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtReservationID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 664);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dtpReservationTime
            // 
            this.dtpReservationTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpReservationTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpReservationTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReservationTime.Location = new System.Drawing.Point(242, 321);
            this.dtpReservationTime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpReservationTime.Name = "dtpReservationTime";
            this.dtpReservationTime.Size = new System.Drawing.Size(219, 29);
            this.dtpReservationTime.TabIndex = 34;
            // 
            // richTxtDeviceIDList
            // 
            this.richTxtDeviceIDList.Enabled = false;
            this.richTxtDeviceIDList.Location = new System.Drawing.Point(13, 233);
            this.richTxtDeviceIDList.Name = "richTxtDeviceIDList";
            this.richTxtDeviceIDList.Size = new System.Drawing.Size(453, 81);
            this.richTxtDeviceIDList.TabIndex = 33;
            this.richTxtDeviceIDList.Text = "";
            // 
            // btnChonThietBi
            // 
            this.btnChonThietBi.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChonThietBi.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChonThietBi.Location = new System.Drawing.Point(240, 198);
            this.btnChonThietBi.Name = "btnChonThietBi";
            this.btnChonThietBi.Size = new System.Drawing.Size(75, 29);
            this.btnChonThietBi.TabIndex = 32;
            this.btnChonThietBi.Text = "Chọn";
            this.btnChonThietBi.UseVisualStyleBackColor = false;
            this.btnChonThietBi.Click += new System.EventHandler(this.btnChonThietBi_Click);
            // 
            // btnChonMaGhe
            // 
            this.btnChonMaGhe.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChonMaGhe.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChonMaGhe.Location = new System.Drawing.Point(391, 162);
            this.btnChonMaGhe.Name = "btnChonMaGhe";
            this.btnChonMaGhe.Size = new System.Drawing.Size(75, 29);
            this.btnChonMaGhe.TabIndex = 30;
            this.btnChonMaGhe.Text = "Chọn";
            this.btnChonMaGhe.UseVisualStyleBackColor = false;
            this.btnChonMaGhe.Click += new System.EventHandler(this.btnChonMaGhe_Click);
            // 
            // flpnButtonGroup
            // 
            this.flpnButtonGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpnButtonGroup.Controls.Add(this.btnSave);
            this.flpnButtonGroup.Controls.Add(this.btnEdit);
            this.flpnButtonGroup.Controls.Add(this.btnAdd);
            this.flpnButtonGroup.Controls.Add(this.btnDelete);
            this.flpnButtonGroup.Controls.Add(this.btnClear);
            this.flpnButtonGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpnButtonGroup.Location = new System.Drawing.Point(15, 520);
            this.flpnButtonGroup.Name = "flpnButtonGroup";
            this.flpnButtonGroup.Size = new System.Drawing.Size(444, 103);
            this.flpnButtonGroup.TabIndex = 29;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(338, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(226, 5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(114, 5);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(338, 55);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(226, 55);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Hủy";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDSMaThietBi
            // 
            this.lblDSMaThietBi.AutoSize = true;
            this.lblDSMaThietBi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDSMaThietBi.Location = new System.Drawing.Point(9, 202);
            this.lblDSMaThietBi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDSMaThietBi.Name = "lblDSMaThietBi";
            this.lblDSMaThietBi.Size = new System.Drawing.Size(195, 22);
            this.lblDSMaThietBi.TabIndex = 28;
            this.lblDSMaThietBi.Text = "Danh sách mã thiết bị:";
            // 
            // lblThongTinPhieuMuon
            // 
            this.lblThongTinPhieuMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblThongTinPhieuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinPhieuMuon.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblThongTinPhieuMuon.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinPhieuMuon.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblThongTinPhieuMuon.Name = "lblThongTinPhieuMuon";
            this.lblThongTinPhieuMuon.Size = new System.Drawing.Size(488, 50);
            this.lblThongTinPhieuMuon.TabIndex = 27;
            this.lblThongTinPhieuMuon.Text = "Thông tin phiếu mượn";
            this.lblThongTinPhieuMuon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSeatID
            // 
            this.txtSeatID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSeatID.Enabled = false;
            this.txtSeatID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSeatID.Location = new System.Drawing.Point(240, 162);
            this.txtSeatID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtSeatID.Name = "txtSeatID";
            this.txtSeatID.Size = new System.Drawing.Size(142, 29);
            this.txtSeatID.TabIndex = 26;
            this.txtSeatID.TextChanged += new System.EventHandler(this.txtSeatID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(9, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 22);
            this.label4.TabIndex = 25;
            this.label4.Text = "Mã chỗ:";
            // 
            // lblReturnTimeValue
            // 
            this.lblReturnTimeValue.AutoSize = true;
            this.lblReturnTimeValue.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblReturnTimeValue.ForeColor = System.Drawing.Color.Red;
            this.lblReturnTimeValue.Location = new System.Drawing.Point(241, 402);
            this.lblReturnTimeValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReturnTimeValue.Name = "lblReturnTimeValue";
            this.lblReturnTimeValue.Size = new System.Drawing.Size(47, 22);
            this.lblReturnTimeValue.TabIndex = 24;
            this.lblReturnTimeValue.Text = "tgtra";
            // 
            // lblReservationTimeValue
            // 
            this.lblReservationTimeValue.AutoSize = true;
            this.lblReservationTimeValue.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblReservationTimeValue.Location = new System.Drawing.Point(137, 326);
            this.lblReservationTimeValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReservationTimeValue.Name = "lblReservationTimeValue";
            this.lblReservationTimeValue.Size = new System.Drawing.Size(0, 22);
            this.lblReservationTimeValue.TabIndex = 23;
            // 
            // lblReturnTime
            // 
            this.lblReturnTime.AutoSize = true;
            this.lblReturnTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblReturnTime.Location = new System.Drawing.Point(11, 402);
            this.lblReturnTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReturnTime.Name = "lblReturnTime";
            this.lblReturnTime.Size = new System.Drawing.Size(119, 22);
            this.lblReturnTime.TabIndex = 22;
            this.lblReturnTime.Text = "Thời gian trả:";
            // 
            // lblReservationTime
            // 
            this.lblReservationTime.AutoSize = true;
            this.lblReservationTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblReservationTime.Location = new System.Drawing.Point(11, 326);
            this.lblReservationTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReservationTime.Name = "lblReservationTime";
            this.lblReservationTime.Size = new System.Drawing.Size(124, 22);
            this.lblReservationTime.TabIndex = 21;
            this.lblReservationTime.Text = "Thời gian đặt:";
            // 
            // dtpCreatedAt
            // 
            this.dtpCreatedAt.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtpCreatedAt.Enabled = false;
            this.dtpCreatedAt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpCreatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedAt.Location = new System.Drawing.Point(240, 483);
            this.dtpCreatedAt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpCreatedAt.Name = "dtpCreatedAt";
            this.dtpCreatedAt.Size = new System.Drawing.Size(219, 29);
            this.dtpCreatedAt.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(11, 483);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ngày tạo:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(240, 440);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(219, 30);
            this.cboStatus.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(11, 440);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Trạng thái:";
            // 
            // dtpDueTime
            // 
            this.dtpDueTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDueTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpDueTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueTime.Location = new System.Drawing.Point(240, 363);
            this.dtpDueTime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpDueTime.Name = "dtpDueTime";
            this.dtpDueTime.Size = new System.Drawing.Size(219, 29);
            this.dtpDueTime.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(9, 363);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Thời hạn:";
            // 
            // cboReservationType
            // 
            this.cboReservationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReservationType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboReservationType.FormattingEnabled = true;
            this.cboReservationType.Location = new System.Drawing.Point(242, 124);
            this.cboReservationType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cboReservationType.Name = "cboReservationType";
            this.cboReservationType.Size = new System.Drawing.Size(219, 30);
            this.cboReservationType.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(7, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "Loại mượn:";
            // 
            // txtMemberID
            // 
            this.txtMemberID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMemberID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMemberID.Location = new System.Drawing.Point(240, 90);
            this.txtMemberID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(221, 29);
            this.txtMemberID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(7, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã thành viên:";
            // 
            // txtReservationID
            // 
            this.txtReservationID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReservationID.Enabled = false;
            this.txtReservationID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtReservationID.Location = new System.Drawing.Point(242, 58);
            this.txtReservationID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtReservationID.Name = "txtReservationID";
            this.txtReservationID.Size = new System.Drawing.Size(219, 29);
            this.txtReservationID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã mượn:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(488, 85);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 50);
            this.panel3.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.cboSearchCategory);
            this.flowLayoutPanel1.Controls.Add(this.txtSearch);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(882, 50);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(776, 5);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboSearchCategory
            // 
            this.cboSearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchCategory.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboSearchCategory.FormattingEnabled = true;
            this.cboSearchCategory.Location = new System.Drawing.Point(644, 10);
            this.cboSearchCategory.Margin = new System.Windows.Forms.Padding(6, 10, 6, 5);
            this.cboSearchCategory.Name = "cboSearchCategory";
            this.cboSearchCategory.Size = new System.Drawing.Size(120, 30);
            this.cboSearchCategory.TabIndex = 2;
            this.cboSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cboSearchCategory_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearch.Location = new System.Drawing.Point(107, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 10, 6, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(525, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(771, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 8, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 34);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tìm kiếm:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(488, 135);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(882, 614);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1364, 718);
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý mượn thiết bị/ chỗ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flpnButtonGroup.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtReservationID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboReservationType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDueTime;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCreatedAt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboSearchCategory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblReturnTime;
        private System.Windows.Forms.Label lblReservationTime;
        private System.Windows.Forms.Label lblReturnTimeValue;
        private System.Windows.Forms.Label lblReservationTimeValue;
        private System.Windows.Forms.TextBox txtSeatID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThongTinPhieuMuon;
        private System.Windows.Forms.Label lblDSMaThietBi;
        private System.Windows.Forms.FlowLayoutPanel flpnButtonGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnChonMaGhe;
        private System.Windows.Forms.RichTextBox richTxtDeviceIDList;
        private System.Windows.Forms.Button btnChonThietBi;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpReservationTime;
    }
}
