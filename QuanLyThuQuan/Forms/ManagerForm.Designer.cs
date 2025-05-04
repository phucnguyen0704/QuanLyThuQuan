// ManagerForm.Designer.cs
using System;
using System.Windows.Forms.DataVisualization.Charting;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnViolations = new System.Windows.Forms.Button();
            this.btnRegulations = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnDevices = new System.Windows.Forms.Button();
            this.btnSeats = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.memberChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.deviceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.reservationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.seatChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblQLTV = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Controls.Add(this.lblClock);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1579, 98);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1440, 62);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(96, 23);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "01/01/2023";
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.White;
            this.lblClock.Location = new System.Drawing.Point(1440, 31);
            this.lblClock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(72, 23);
            this.lblClock.TabIndex = 2;
            this.lblClock.Text = "00:00:00";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(16, 62);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(91, 28);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Xin chào:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(600, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ THƯ QUÁN";
            // 
            // panelMenu
            // 
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
            this.panelMenu.Location = new System.Drawing.Point(0, 98);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(293, 716);
            this.panelMenu.TabIndex = 1;
            // 
            // btnLogs
            // 
            this.btnLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogs.FlatAppearance.BorderSize = 0;
            this.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.ForeColor = System.Drawing.Color.White;
            this.btnLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.Location = new System.Drawing.Point(0, 294);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLogs.Size = new System.Drawing.Size(293, 49);
            this.btnLogs.TabIndex = 17;
            this.btnLogs.Text = "  Nhật ký vào thư quán";
            this.btnLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnViolations
            // 
            this.btnViolations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViolations.FlatAppearance.BorderSize = 0;
            this.btnViolations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViolations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViolations.ForeColor = System.Drawing.Color.White;
            this.btnViolations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViolations.Location = new System.Drawing.Point(0, 245);
            this.btnViolations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViolations.Name = "btnViolations";
            this.btnViolations.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnViolations.Size = new System.Drawing.Size(293, 49);
            this.btnViolations.TabIndex = 16;
            this.btnViolations.Text = "  Vi phạm";
            this.btnViolations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViolations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViolations.UseVisualStyleBackColor = true;
            this.btnViolations.Click += new System.EventHandler(this.btnViolations_Click);
            // 
            // btnRegulations
            // 
            this.btnRegulations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegulations.FlatAppearance.BorderSize = 0;
            this.btnRegulations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegulations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegulations.ForeColor = System.Drawing.Color.White;
            this.btnRegulations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegulations.Location = new System.Drawing.Point(0, 196);
            this.btnRegulations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegulations.Name = "btnRegulations";
            this.btnRegulations.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnRegulations.Size = new System.Drawing.Size(293, 49);
            this.btnRegulations.TabIndex = 15;
            this.btnRegulations.Text = "  Quy định";
            this.btnRegulations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegulations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegulations.UseVisualStyleBackColor = true;
            this.btnRegulations.Click += new System.EventHandler(this.btnRegulations_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMembers.FlatAppearance.BorderSize = 0;
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.ForeColor = System.Drawing.Color.White;
            this.btnMembers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.Location = new System.Drawing.Point(0, 147);
            this.btnMembers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnMembers.Size = new System.Drawing.Size(293, 49);
            this.btnMembers.TabIndex = 14;
            this.btnMembers.Text = "  Thành viên";
            this.btnMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMembers.UseVisualStyleBackColor = true;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnReservations
            // 
            this.btnReservations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservations.ForeColor = System.Drawing.Color.White;
            this.btnReservations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.Location = new System.Drawing.Point(0, 98);
            this.btnReservations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnReservations.Size = new System.Drawing.Size(293, 49);
            this.btnReservations.TabIndex = 13;
            this.btnReservations.Text = "  Mượn trả";
            this.btnReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservations.UseVisualStyleBackColor = true;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // btnDevices
            // 
            this.btnDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDevices.FlatAppearance.BorderSize = 0;
            this.btnDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevices.ForeColor = System.Drawing.Color.White;
            this.btnDevices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevices.Location = new System.Drawing.Point(0, 49);
            this.btnDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDevices.Name = "btnDevices";
            this.btnDevices.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDevices.Size = new System.Drawing.Size(293, 49);
            this.btnDevices.TabIndex = 12;
            this.btnDevices.Text = "  Thiết bị";
            this.btnDevices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDevices.UseVisualStyleBackColor = true;
            this.btnDevices.Click += new System.EventHandler(this.btnDevices_Click);
            // 
            // btnSeats
            // 
            this.btnSeats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeats.FlatAppearance.BorderSize = 0;
            this.btnSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeats.ForeColor = System.Drawing.Color.White;
            this.btnSeats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeats.Location = new System.Drawing.Point(0, 0);
            this.btnSeats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSeats.Name = "btnSeats";
            this.btnSeats.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnSeats.Size = new System.Drawing.Size(293, 49);
            this.btnSeats.TabIndex = 11;
            this.btnSeats.Text = "  Chỗ ngồi";
            this.btnSeats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeats.UseVisualStyleBackColor = true;
            this.btnSeats.Click += new System.EventHandler(this.btnSeats_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 618);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(293, 49);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "  Đổi mật khẩu";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 667);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(293, 49);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "  Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.memberChart);
            this.panelContent.Controls.Add(this.deviceChart);
            this.panelContent.Controls.Add(this.reservationChart);
            this.panelContent.Controls.Add(this.seatChart);
            this.panelContent.Controls.Add(this.pictureBox1);
            this.panelContent.Controls.Add(this.lblQLTV);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(293, 98);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1286, 716);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // memberChart
            // 
            chartArea5.Name = "ChartArea1";
            this.memberChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.memberChart.Legends.Add(legend5);
            this.memberChart.Location = new System.Drawing.Point(27, 25);
            this.memberChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.memberChart.Name = "memberChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.memberChart.Series.Add(series5);
            this.memberChart.Size = new System.Drawing.Size(600, 308);
            this.memberChart.TabIndex = 2;
            this.memberChart.Text = "Biểu đồ thành viên";
            this.memberChart.Click += new System.EventHandler(this.memberChart_Click);
            // 
            // deviceChart
            // 
            this.deviceChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea6.Name = "ChartArea1";
            this.deviceChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.deviceChart.Legends.Add(legend6);
            this.deviceChart.Location = new System.Drawing.Point(654, 25);
            this.deviceChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deviceChart.Name = "deviceChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.deviceChart.Series.Add(series6);
            this.deviceChart.Size = new System.Drawing.Size(600, 308);
            this.deviceChart.TabIndex = 3;
            this.deviceChart.Text = "Biểu đồ thiết bị";
            this.deviceChart.Click += new System.EventHandler(this.deviceChart_Click);
            // 
            // reservationChart
            // 
            this.reservationChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            chartArea7.Name = "ChartArea1";
            this.reservationChart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.reservationChart.Legends.Add(legend7);
            this.reservationChart.Location = new System.Drawing.Point(27, 358);
            this.reservationChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationChart.Name = "reservationChart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.reservationChart.Series.Add(series7);
            this.reservationChart.Size = new System.Drawing.Size(600, 308);
            this.reservationChart.TabIndex = 4;
            this.reservationChart.Text = "Biểu đồ phiếu mượn";
            this.reservationChart.Click += new System.EventHandler(this.reservationChart_Click);
            // 
            // seatChart
            // 
            this.seatChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea8.Name = "ChartArea1";
            this.seatChart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.seatChart.Legends.Add(legend8);
            this.seatChart.Location = new System.Drawing.Point(654, 358);
            this.seatChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seatChart.Name = "seatChart";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.seatChart.Series.Add(series8);
            this.seatChart.Size = new System.Drawing.Size(600, 308);
            this.seatChart.TabIndex = 5;
            this.seatChart.Text = "Biểu đồ chỗ ngồi";
            this.seatChart.Click += new System.EventHandler(this.seatChart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(510, 186);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lblQLTV
            // 
            this.lblQLTV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQLTV.AutoSize = true;
            this.lblQLTV.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLTV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblQLTV.Location = new System.Drawing.Point(401, 456);
            this.lblQLTV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQLTV.Name = "lblQLTV";
            this.lblQLTV.Size = new System.Drawing.Size(421, 54);
            this.lblQLTV.TabIndex = 0;
            this.lblQLTV.Text = "QUẢN LÝ THƯ QUÁN";
            this.lblQLTV.Visible = false;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 814);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1327, 728);
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý thư quán";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatChart)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart memberChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart deviceChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart reservationChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart seatChart;
         
    }
}
