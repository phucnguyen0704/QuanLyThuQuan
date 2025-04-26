using System;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    partial class fLogManage
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkinDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtLogMemberID = new System.Windows.Forms.TextBox();
            this.txtLogID = new System.Windows.Forms.TextBox();
            this.lblLogStatus = new System.Windows.Forms.Label();
            this.lblLogMemberID = new System.Windows.Forms.Label();
            this.lbllogID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewLog = new System.Windows.Forms.DataGridView();
            this.lblLichSuVaoThuQuan = new System.Windows.Forms.Label();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTime);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.checkinDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtStatus);
            this.panel2.Controls.Add(this.txtLogMemberID);
            this.panel2.Controls.Add(this.txtLogID);
            this.panel2.Controls.Add(this.lblLogStatus);
            this.panel2.Controls.Add(this.lblLogMemberID);
            this.panel2.Controls.Add(this.lbllogID);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 597);
            this.panel2.TabIndex = 1;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(149, 218);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(180, 22);
            this.txtTime.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Giờ check-in";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // checkinDate
            // 
            this.checkinDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkinDate.CustomFormat = "dd/MM/yyyy";
            this.checkinDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.checkinDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.checkinDate.Location = new System.Drawing.Point(149, 173);
            this.checkinDate.Name = "checkinDate";
            this.checkinDate.Size = new System.Drawing.Size(180, 22);
            this.checkinDate.TabIndex = 26;
            this.checkinDate.Value = new System.DateTime(2025, 4, 25, 9, 59, 54, 0);
            this.checkinDate.ValueChanged += new System.EventHandler(this.checkinDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ngày check-in";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(23, 504);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(306, 50);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tùy chỉnh";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(23, 448);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(306, 50);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(23, 392);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(306, 50);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 336);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(306, 50);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(148, 265);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(180, 22);
            this.txtStatus.TabIndex = 12;
            this.txtStatus.TabStop = false;
            // 
            // txtLogMemberID
            // 
            this.txtLogMemberID.Location = new System.Drawing.Point(149, 125);
            this.txtLogMemberID.Name = "txtLogMemberID";
            this.txtLogMemberID.Size = new System.Drawing.Size(180, 22);
            this.txtLogMemberID.TabIndex = 11;
            // 
            // txtLogID
            // 
            this.txtLogID.BackColor = System.Drawing.Color.White;
            this.txtLogID.Enabled = false;
            this.txtLogID.Location = new System.Drawing.Point(149, 79);
            this.txtLogID.Name = "txtLogID";
            this.txtLogID.ReadOnly = true;
            this.txtLogID.Size = new System.Drawing.Size(180, 22);
            this.txtLogID.TabIndex = 10;
            this.txtLogID.TabStop = false;
            this.txtLogID.TextChanged += new System.EventHandler(this.txtLogID_TextChanged);
            // 
            // lblLogStatus
            // 
            this.lblLogStatus.AutoSize = true;
            this.lblLogStatus.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogStatus.Location = new System.Drawing.Point(3, 271);
            this.lblLogStatus.Name = "lblLogStatus";
            this.lblLogStatus.Size = new System.Drawing.Size(71, 16);
            this.lblLogStatus.TabIndex = 2;
            this.lblLogStatus.Text = "Trạng thái";
            // 
            // lblLogMemberID
            // 
            this.lblLogMemberID.AutoSize = true;
            this.lblLogMemberID.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogMemberID.Location = new System.Drawing.Point(3, 131);
            this.lblLogMemberID.Name = "lblLogMemberID";
            this.lblLogMemberID.Size = new System.Drawing.Size(90, 16);
            this.lblLogMemberID.TabIndex = 1;
            this.lblLogMemberID.Text = "Mã Sinh viên";
            // 
            // lbllogID
            // 
            this.lbllogID.AutoSize = true;
            this.lbllogID.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllogID.Location = new System.Drawing.Point(3, 85);
            this.lbllogID.Name = "lbllogID";
            this.lbllogID.Size = new System.Drawing.Size(85, 16);
            this.lbllogID.TabIndex = 0;
            this.lbllogID.Text = "Mã Check-in";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewLog);
            this.panel1.Controls.Add(this.lblLichSuVaoThuQuan);
            this.panel1.Location = new System.Drawing.Point(377, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 597);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridViewLog
            // 
            this.dataGridViewLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLog.Location = new System.Drawing.Point(12, 57);
            this.dataGridViewLog.Name = "dataGridViewLog";
            this.dataGridViewLog.RowHeadersWidth = 51;
            this.dataGridViewLog.RowTemplate.Height = 24;
            this.dataGridViewLog.Size = new System.Drawing.Size(1123, 526);
            this.dataGridViewLog.TabIndex = 1;
            // 
            // lblLichSuVaoThuQuan
            // 
            this.lblLichSuVaoThuQuan.AutoSize = true;
            this.lblLichSuVaoThuQuan.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblLichSuVaoThuQuan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLichSuVaoThuQuan.Location = new System.Drawing.Point(500, 18);
            this.lblLichSuVaoThuQuan.Name = "lblLichSuVaoThuQuan";
            this.lblLichSuVaoThuQuan.Size = new System.Drawing.Size(209, 24);
            this.lblLichSuVaoThuQuan.TabIndex = 0;
            this.lblLichSuVaoThuQuan.Text = "Nhật kí vào thư quán";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // fLogManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 669);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "fLogManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sách";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLogMemberID;
        private System.Windows.Forms.Label lbllogID;
        private System.Windows.Forms.Label lblLogStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtLogMemberID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewLog;
        private System.Windows.Forms.Label lblLichSuVaoThuQuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogID;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker checkinDate;
        private Label label3;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private TextBox txtTime;
    }
}