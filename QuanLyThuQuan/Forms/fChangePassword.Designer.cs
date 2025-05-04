using System;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    partial class fChangePassword
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblXacNhanMatKhau = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.btnDoiMatKhau);
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.txtOldPassword);
            this.panel1.Controls.Add(this.txtXacNhanMatKhau);
            this.panel1.Controls.Add(this.lblNewPassword);
            this.panel1.Controls.Add(this.lblXacNhanMatKhau);
            this.panel1.Controls.Add(this.lblOldPassword);
            this.panel1.Location = new System.Drawing.Point(186, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 388);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.labelTitle.Location = new System.Drawing.Point(71, 14);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(250, 37);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Text = "Quản Lý Thư Quán";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(208, 321);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(147, 43);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Thoát";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click_1);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(36, 321);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(147, 43);
            this.btnDoiMatKhau.TabIndex = 7;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click_1);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(36, 184);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(319, 30);
            this.txtNewPassword.TabIndex = 7;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged_1);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.Location = new System.Drawing.Point(36, 114);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(319, 30);
            this.txtOldPassword.TabIndex = 6;
            this.txtOldPassword.UseSystemPasswordChar = true;
            this.txtOldPassword.TextChanged += new System.EventHandler(this.txtOldPassword_TextChanged_1);
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(36, 245);
            this.txtXacNhanMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(319, 30);
            this.txtXacNhanMatKhau.TabIndex = 5;
            this.txtXacNhanMatKhau.UseSystemPasswordChar = true;
            this.txtXacNhanMatKhau.TextChanged += new System.EventHandler(this.txtXacNhanMatKhau_TextChanged_1);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(32, 157);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(120, 23);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "Mật khẩu mới:";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXacNhanMatKhau
            // 
            this.lblXacNhanMatKhau.AutoSize = true;
            this.lblXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(32, 218);
            this.lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            this.lblXacNhanMatKhau.Size = new System.Drawing.Size(170, 23);
            this.lblXacNhanMatKhau.TabIndex = 1;
            this.lblXacNhanMatKhau.Text = "Xác Nhận mật khẩu: ";
            this.lblXacNhanMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.Location = new System.Drawing.Point(32, 85);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(109, 23);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Mật khẩu cũ:";
            this.lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOldPassword.Click += new System.EventHandler(this.lblOldPassword_Click);
            // 
            // fChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 451);
            this.Controls.Add(this.panel1);
            this.Name = "fChangePassword";
            this.Text = "fChangePassword";
            this.Load += new System.EventHandler(this.fChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void fChangePassword_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label labelTitle;
    }
}