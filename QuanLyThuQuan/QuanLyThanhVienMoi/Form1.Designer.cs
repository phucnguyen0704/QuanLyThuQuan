namespace QuanLyThanhVienMoi
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colVaoKhuVuc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRaKhuVuc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnThemmoi = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnThem = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.customInstaller2 = new MySql.Data.MySqlClient.CustomInstaller();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtTimKiemThanhVien = new System.Windows.Forms.TextBox();
            this.btnTimKiemThanhVien = new System.Windows.Forms.Button();
            this.lblPhanTrang = new System.Windows.Forms.Label();
            this.btnTrangTruoc = new System.Windows.Forms.Button();
            this.btnTrangSau = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVaoKhuVuc,
            this.colRaKhuVuc});
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(841, 142);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colVaoKhuVuc
            // 
            this.colVaoKhuVuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVaoKhuVuc.HeaderText = "Vào khu vực";
            this.colVaoKhuVuc.MinimumWidth = 6;
            this.colVaoKhuVuc.Name = "colVaoKhuVuc";
            this.colVaoKhuVuc.Text = "Vào";
            this.colVaoKhuVuc.UseColumnTextForButtonValue = true;
            this.colVaoKhuVuc.Width = 86;
            // 
            // colRaKhuVuc
            // 
            this.colRaKhuVuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRaKhuVuc.HeaderText = "Ra khu vực";
            this.colRaKhuVuc.MinimumWidth = 6;
            this.colRaKhuVuc.Name = "colRaKhuVuc";
            this.colRaKhuVuc.Text = "Ra";
            this.colRaKhuVuc.UseColumnTextForButtonValue = true;
            this.colRaKhuVuc.Width = 79;
            // 
            // btnThemmoi
            // 
            this.btnThemmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemmoi.Location = new System.Drawing.Point(0, 176);
            this.btnThemmoi.Name = "btnThemmoi";
            this.btnThemmoi.Size = new System.Drawing.Size(105, 32);
            this.btnThemmoi.TabIndex = 1;
            this.btnThemmoi.Text = "Thêm mới";
            this.btnThemmoi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemmoi.UseVisualStyleBackColor = true;
            this.btnThemmoi.Click += new System.EventHandler(this.btnThemmoi_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnThem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(841, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnThem
            // 
            this.tsbtnThem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnThem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.tsbtnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnThem.Name = "tsbtnThem";
            this.tsbtnThem.Size = new System.Drawing.Size(19, 28);
            this.tsbtnThem.Text = "Thêm mới";
            this.tsbtnThem.ButtonClick += new System.EventHandler(this.tsbtnThem_ButtonClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem1.Text = "Nhập từ Excel";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(0, 225);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 32);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(0, 277);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 32);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtTimKiemThanhVien
            // 
            this.txtTimKiemThanhVien.BackColor = System.Drawing.Color.Yellow;
            this.txtTimKiemThanhVien.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemThanhVien.ForeColor = System.Drawing.Color.Red;
            this.txtTimKiemThanhVien.Location = new System.Drawing.Point(157, 225);
            this.txtTimKiemThanhVien.Name = "txtTimKiemThanhVien";
            this.txtTimKiemThanhVien.Size = new System.Drawing.Size(182, 27);
            this.txtTimKiemThanhVien.TabIndex = 6;
            this.txtTimKiemThanhVien.Text = " ";
            this.txtTimKiemThanhVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTimKiemThanhVien
            // 
            this.btnTimKiemThanhVien.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemThanhVien.Location = new System.Drawing.Point(196, 173);
            this.btnTimKiemThanhVien.Name = "btnTimKiemThanhVien";
            this.btnTimKiemThanhVien.Size = new System.Drawing.Size(105, 32);
            this.btnTimKiemThanhVien.TabIndex = 7;
            this.btnTimKiemThanhVien.Text = "Tìm kiếm";
            this.btnTimKiemThanhVien.UseVisualStyleBackColor = true;
            this.btnTimKiemThanhVien.Click += new System.EventHandler(this.btnTimKiemThanhVien_Click);
            // 
            // lblPhanTrang
            // 
            this.lblPhanTrang.Location = new System.Drawing.Point(628, 398);
            this.lblPhanTrang.Name = "lblPhanTrang";
            this.lblPhanTrang.Size = new System.Drawing.Size(124, 34);
            this.lblPhanTrang.TabIndex = 8;
            this.lblPhanTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangTruoc.Location = new System.Drawing.Point(546, 458);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(130, 32);
            this.btnTrangTruoc.TabIndex = 9;
            this.btnTrangTruoc.Text = "< Trang trước";
            this.btnTrangTruoc.UseVisualStyleBackColor = true;
            this.btnTrangTruoc.Click += new System.EventHandler(this.btnTrangTruoc_Click);
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangSau.Location = new System.Drawing.Point(706, 458);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(123, 32);
            this.btnTrangSau.TabIndex = 10;
            this.btnTrangSau.Text = "Trang sau >";
            this.btnTrangSau.UseVisualStyleBackColor = true;
            this.btnTrangSau.Click += new System.EventHandler(this.btnTrangSau_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(0, 326);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(105, 32);
            this.btnXuatExcel.TabIndex = 11;
            this.btnXuatExcel.Text = "Xuất";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 580);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnTrangSau);
            this.Controls.Add(this.btnTrangTruoc);
            this.Controls.Add(this.lblPhanTrang);
            this.Controls.Add(this.btnTimKiemThanhVien);
            this.Controls.Add(this.txtTimKiemThanhVien);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnThemmoi);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThemmoi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton tsbtnThem;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewButtonColumn colVaoKhuVuc;
        private System.Windows.Forms.DataGridViewButtonColumn colRaKhuVuc;
        private System.Windows.Forms.TextBox txtTimKiemThanhVien;
        private System.Windows.Forms.Button btnTimKiemThanhVien;
        private System.Windows.Forms.Label lblPhanTrang;
        private System.Windows.Forms.Button btnTrangTruoc;
        private System.Windows.Forms.Button btnTrangSau;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}

