// HistoryForm.Designer.cs
namespace QuanLyThuQuan.Forms
{
    partial class HistoryForm
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReservations = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSelectedReservation = new System.Windows.Forms.Label();
            this.tabViolations = new System.Windows.Forms.TabPage();
            this.dgvViolations = new System.Windows.Forms.DataGridView();
            this.tabCheckIns = new System.Windows.Forms.TabPage();
            this.dgvCheckIns = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabViolations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViolations)).BeginInit();
            this.tabCheckIns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckIns)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1028, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(862, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 35);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "LỊCH SỬ THÀNH VIÊN";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.lblClass);
            this.panel2.Controls.Add(this.lblMemberId);
            this.panel2.Controls.Add(this.lblMemberName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 80);
            this.panel2.TabIndex = 1;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(862, 45);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(52, 16);
            this.lblDepartment.TabIndex = 7;
            this.lblDepartment.Text = "[Khoa]";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(862, 15);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(43, 16);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "[Lớp]";
            // 
            // lblMemberId
            // 
            this.lblMemberId.AutoSize = true;
            this.lblMemberId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberId.Location = new System.Drawing.Point(400, 45);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(112, 16);
            this.lblMemberId.TabIndex = 5;
            this.lblMemberId.Text = "[Mã thành viên]";
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberName.Location = new System.Drawing.Point(400, 15);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(83, 16);
            this.lblMemberName.TabIndex = 4;
            this.lblMemberName.Text = "[Họ và tên]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(800, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Khoa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(800, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lớp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã thành viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ và tên:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReservations);
            this.tabControl1.Controls.Add(this.tabViolations);
            this.tabControl1.Controls.Add(this.tabCheckIns);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 140);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 510);
            this.tabControl1.TabIndex = 2;
            // 
            // tabReservations
            // 
            this.tabReservations.Controls.Add(this.splitContainer1);
            this.tabReservations.Location = new System.Drawing.Point(4, 25);
            this.tabReservations.Name = "tabReservations";
            this.tabReservations.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservations.Size = new System.Drawing.Size(1192, 481);
            this.tabReservations.TabIndex = 0;
            this.tabReservations.Text = "Lịch sử mượn";
            this.tabReservations.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvReservations);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDevices);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 475);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvReservations
            // 
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservations.Location = new System.Drawing.Point(0, 0);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(1186, 235);
            this.dgvReservations.TabIndex = 0;
            this.dgvReservations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservations_CellClick);
            this.dgvReservations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservations_CellContentClick);
            // 
            // dgvDevices
            // 
            this.dgvDevices.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevices.Location = new System.Drawing.Point(0, 40);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(1186, 196);
            this.dgvDevices.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.lblSelectedReservation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1186, 40);
            this.panel3.TabIndex = 0;
            // 
            // lblSelectedReservation
            // 
            this.lblSelectedReservation.AutoSize = true;
            this.lblSelectedReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedReservation.Location = new System.Drawing.Point(12, 12);
            this.lblSelectedReservation.Name = "lblSelectedReservation";
            this.lblSelectedReservation.Size = new System.Drawing.Size(217, 16);
            this.lblSelectedReservation.TabIndex = 0;
            this.lblSelectedReservation.Text = "Chi tiết phiếu mượn: Chưa chọn";
            // 
            // tabViolations
            // 
            this.tabViolations.Controls.Add(this.dgvViolations);
            this.tabViolations.Location = new System.Drawing.Point(4, 25);
            this.tabViolations.Name = "tabViolations";
            this.tabViolations.Padding = new System.Windows.Forms.Padding(3);
            this.tabViolations.Size = new System.Drawing.Size(1192, 481);
            this.tabViolations.TabIndex = 1;
            this.tabViolations.Text = "Lịch sử vi phạm";
            this.tabViolations.UseVisualStyleBackColor = true;
            // 
            // dgvViolations
            // 
            this.dgvViolations.BackgroundColor = System.Drawing.Color.White;
            this.dgvViolations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViolations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViolations.Location = new System.Drawing.Point(3, 3);
            this.dgvViolations.Name = "dgvViolations";
            this.dgvViolations.Size = new System.Drawing.Size(1186, 475);
            this.dgvViolations.TabIndex = 0;
            // 
            // tabCheckIns
            // 
            this.tabCheckIns.Controls.Add(this.dgvCheckIns);
            this.tabCheckIns.Location = new System.Drawing.Point(4, 25);
            this.tabCheckIns.Name = "tabCheckIns";
            this.tabCheckIns.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckIns.Size = new System.Drawing.Size(1192, 481);
            this.tabCheckIns.TabIndex = 2;
            this.tabCheckIns.Text = "Lịch sử check-in";
            this.tabCheckIns.UseVisualStyleBackColor = true;
            // 
            // dgvCheckIns
            // 
            this.dgvCheckIns.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckIns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckIns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckIns.Location = new System.Drawing.Point(3, 3);
            this.dgvCheckIns.Name = "dgvCheckIns";
            this.dgvCheckIns.Size = new System.Drawing.Size(1186, 475);
            this.dgvCheckIns.TabIndex = 0;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử thành viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabReservations.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabViolations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViolations)).EndInit();
            this.tabCheckIns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckIns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReservations;
        private System.Windows.Forms.TabPage tabViolations;
        private System.Windows.Forms.TabPage tabCheckIns;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSelectedReservation;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.DataGridView dgvViolations;
        private System.Windows.Forms.DataGridView dgvCheckIns;
    }
}