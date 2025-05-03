namespace QuanLyThuQuan
{
    partial class fSeatManage
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
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtSeatName = new System.Windows.Forms.TextBox();
            this.txtSeatID = new System.Windows.Forms.TextBox();
            this.lblSeatStatus = new System.Windows.Forms.Label();
            this.lblSeatName = new System.Windows.Forms.Label();
            this.lblSeatID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewSeat = new System.Windows.Forms.DataGridView();
            this.lblDisBookInLib = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtStatus);
            this.panel2.Controls.Add(this.txtSeatName);
            this.panel2.Controls.Add(this.txtSeatID);
            this.panel2.Controls.Add(this.lblSeatStatus);
            this.panel2.Controls.Add(this.lblSeatName);
            this.panel2.Controls.Add(this.lblSeatID);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 597);
            this.panel2.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(23, 418);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tùy chỉnh";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(23, 362);
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
            this.btnEdit.Location = new System.Drawing.Point(23, 306);
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
            this.btnAdd.Location = new System.Drawing.Point(23, 250);
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
            this.txtStatus.Location = new System.Drawing.Point(149, 167);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(180, 22);
            this.txtStatus.TabIndex = 12;
            this.txtStatus.TabStop = false;
            // 
            // txtSeatName
            // 
            this.txtSeatName.Location = new System.Drawing.Point(149, 125);
            this.txtSeatName.Name = "txtSeatName";
            this.txtSeatName.Size = new System.Drawing.Size(180, 22);
            this.txtSeatName.TabIndex = 11;
            this.txtSeatName.TextChanged += new System.EventHandler(this.txtSeatName_TextChanged);
            // 
            // txtSeatID
            // 
            this.txtSeatID.BackColor = System.Drawing.Color.White;
            this.txtSeatID.Enabled = false;
            this.txtSeatID.Location = new System.Drawing.Point(149, 79);
            this.txtSeatID.Name = "txtSeatID";
            this.txtSeatID.ReadOnly = true;
            this.txtSeatID.Size = new System.Drawing.Size(180, 22);
            this.txtSeatID.TabIndex = 10;
            this.txtSeatID.TabStop = false;
            this.txtSeatID.TextChanged += new System.EventHandler(this.txtSeatID_TextChanged);
            // 
            // lblSeatStatus
            // 
            this.lblSeatStatus.AutoSize = true;
            this.lblSeatStatus.Location = new System.Drawing.Point(20, 173);
            this.lblSeatStatus.Name = "lblSeatStatus";
            this.lblSeatStatus.Size = new System.Drawing.Size(67, 16);
            this.lblSeatStatus.TabIndex = 2;
            this.lblSeatStatus.Text = "Trạng thái";
            // 
            // lblSeatName
            // 
            this.lblSeatName.AutoSize = true;
            this.lblSeatName.Location = new System.Drawing.Point(20, 131);
            this.lblSeatName.Name = "lblSeatName";
            this.lblSeatName.Size = new System.Drawing.Size(56, 16);
            this.lblSeatName.TabIndex = 1;
            this.lblSeatName.Text = "Tên chỗ";
            // 
            // lblSeatID
            // 
            this.lblSeatID.AutoSize = true;
            this.lblSeatID.Location = new System.Drawing.Point(20, 85);
            this.lblSeatID.Name = "lblSeatID";
            this.lblSeatID.Size = new System.Drawing.Size(51, 16);
            this.lblSeatID.TabIndex = 0;
            this.lblSeatID.Text = "Mã chỗ";
            this.lblSeatID.Click += new System.EventHandler(this.lblSeatID_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewSeat);
            this.panel1.Controls.Add(this.lblDisBookInLib);
            this.panel1.Location = new System.Drawing.Point(377, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 597);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewSeat
            // 
            this.dataGridViewSeat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSeat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeat.Location = new System.Drawing.Point(12, 57);
            this.dataGridViewSeat.Name = "dataGridViewSeat";
            this.dataGridViewSeat.RowHeadersWidth = 51;
            this.dataGridViewSeat.RowTemplate.Height = 24;
            this.dataGridViewSeat.Size = new System.Drawing.Size(1123, 526);
            this.dataGridViewSeat.TabIndex = 1;
            this.dataGridViewSeat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeat_CellContentClickbtnDetail);
            // 
            // lblDisBookInLib
            // 
            this.lblDisBookInLib.AutoSize = true;
            this.lblDisBookInLib.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblDisBookInLib.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisBookInLib.Location = new System.Drawing.Point(500, 18);
            this.lblDisBookInLib.Name = "lblDisBookInLib";
            this.lblDisBookInLib.Size = new System.Drawing.Size(97, 25);
            this.lblDisBookInLib.TabIndex = 0;
            this.lblDisBookInLib.Text = "Vị trí chỗ";
            // 
            // fSeatManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 669);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "fSeatManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sách";
            this.Load += new System.EventHandler(this.fSeatManage_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSeatName;
        private System.Windows.Forms.Label lblSeatID;
        private System.Windows.Forms.Label lblSeatStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtSeatName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewSeat;
        private System.Windows.Forms.Label lblDisBookInLib;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeatID;
        private System.Windows.Forms.Button btnReset;
    }
}