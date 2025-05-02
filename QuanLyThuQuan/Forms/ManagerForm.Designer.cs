using System;
using System.Linq;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace QuanLyThuQuan
{
    partial class ManagerForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSeats = new System.Windows.Forms.Button();
            this.btnDevices = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnRegulations = new System.Windows.Forms.Button();
            this.btnViolations = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblQLTV = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Controls.Add(this.lblClock);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1184, 80);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);

            // lblDate
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1080, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 17);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "01/01/2023";

            // lblClock
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.White;
            this.lblClock.Location = new System.Drawing.Point(1080, 25);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(56, 17);
            this.lblClock.TabIndex = 2;
            this.lblClock.Text = "00:00:00";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(12, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(72, 21);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Xin chào:";

            // lblTitle
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(450, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ THƯ QUÁN";

            // panelMenu
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnLogs);
            this.panelMenu.Controls.Add(this.btnViolations);
            this.panelMenu.Controls.Add(this.btnRegulations);
            this.panelMenu.Controls.Add(this.btnMembers);
            this.panelMenu.Controls.Add(this.btnReservations);
            this.panelMenu.Controls.Add(this.btnDevices);
            this.panelMenu.Controls.Add(this.btnSeats);
            this.panelMenu.Controls.Add(this.btnProfile);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 80);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 581);
            this.panelMenu.TabIndex = 1;

            // btnSeats
            this.btnSeats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeats.FlatAppearance.BorderSize = 0;
            this.btnSeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeats.ForeColor = System.Drawing.Color.White;
            this.btnSeats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeats.Location = new System.Drawing.Point(0, 0);
            this.btnSeats.Name = "btnSeats";
            this.btnSeats.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSeats.Size = new System.Drawing.Size(220, 40);
            this.btnSeats.TabIndex = 11;
            this.btnSeats.Text = "  Chỗ ngồi";
            this.btnSeats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeats.UseVisualStyleBackColor = true;
            this.btnSeats.Click += new System.EventHandler(this.btnSeats_Click);

            // btnDevices
            this.btnDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevices.FlatAppearance.BorderSize = 0;
            this.btnDevices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevices.ForeColor = System.Drawing.Color.White;
            this.btnDevices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevices.Location = new System.Drawing.Point(0, 40);
            this.btnDevices.Name = "btnDevices";
            this.btnDevices.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDevices.Size = new System.Drawing.Size(220, 40);
            this.btnDevices.TabIndex = 12;
            this.btnDevices.Text = "  Thiết bị";
            this.btnDevices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDevices.UseVisualStyleBackColor = true;
            this.btnDevices.Click += new System.EventHandler(this.btnDevices_Click);

            // btnReservations
            this.btnReservations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservations.ForeColor = System.Drawing.Color.White;
            this.btnReservations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.Location = new System.Drawing.Point(0, 80);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReservations.Size = new System.Drawing.Size(220, 40);
            this.btnReservations.TabIndex = 13;
            this.btnReservations.Text = "  Mượn trả";
            this.btnReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservations.UseVisualStyleBackColor = true;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);

            // btnMembers
            this.btnMembers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.FlatAppearance.BorderSize = 0;
            this.btnMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.ForeColor = System.Drawing.Color.White;
            this.btnMembers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.Location = new System.Drawing.Point(0, 120);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMembers.Size = new System.Drawing.Size(220, 40);
            this.btnMembers.TabIndex = 14;
            this.btnMembers.Text = "  Thành viên";
            this.btnMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMembers.UseVisualStyleBackColor = true;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);

            // btnRegulations
            this.btnRegulations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegulations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegulations.FlatAppearance.BorderSize = 0;
            this.btnRegulations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegulations.ForeColor = System.Drawing.Color.White;
            this.btnRegulations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegulations.Location = new System.Drawing.Point(0, 160);
            this.btnRegulations.Name = "btnRegulations";
            this.btnRegulations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRegulations.Size = new System.Drawing.Size(220, 40);
            this.btnRegulations.TabIndex = 15;
            this.btnRegulations.Text = "  Quy định";
            this.btnRegulations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegulations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegulations.UseVisualStyleBackColor = true;
            this.btnRegulations.Click += new System.EventHandler(this.btnRegulations_Click);

            // btnViolations
            this.btnViolations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViolations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViolations.FlatAppearance.BorderSize = 0;
            this.btnViolations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViolations.ForeColor = System.Drawing.Color.White;
            this.btnViolations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViolations.Location = new System.Drawing.Point(0, 200);
            this.btnViolations.Name = "btnViolations";
            this.btnViolations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnViolations.Size = new System.Drawing.Size(220, 40);
            this.btnViolations.TabIndex = 16;
            this.btnViolations.Text = "  Vi phạm";
            this.btnViolations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViolations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViolations.UseVisualStyleBackColor = true;
            this.btnViolations.Click += new System.EventHandler(this.btnViolations_Click);

            // btnLogs
            this.btnLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogs.FlatAppearance.BorderSize = 0;
            this.btnLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.ForeColor = System.Drawing.Color.White;
            this.btnLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.Location = new System.Drawing.Point(0, 240);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogs.Size = new System.Drawing.Size(220, 40);
            this.btnLogs.TabIndex = 17;
            this.btnLogs.Text = "  Nhật ký vào thư quán";
            this.btnLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);

            // btnProfile
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 501);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(220, 40);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "  Thông tin tài khoản";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 541);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(220, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "  Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.pictureBox1);
            this.panelContent.Controls.Add(this.lblQLTV);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(964, 581);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);

            // pictureBox1
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(382, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;

            // lblQLTV
            this.lblQLTV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQLTV.AutoSize = true;
            this.lblQLTV.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLTV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblQLTV.Location = new System.Drawing.Point(300, 370);
            this.lblQLTV.Name = "lblQLTV";
            this.lblQLTV.Size = new System.Drawing.Size(339, 45);
            this.lblQLTV.TabIndex = 0;
            this.lblQLTV.Text = "QUẢN LÝ THƯ QUÁN";

            // timerClock
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // fTableManager
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý thư quán";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnSeats;
        private System.Windows.Forms.Button btnDevices;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnRegulations;
        private System.Windows.Forms.Button btnViolations;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Label lblQLTV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timerClock;
    }
}