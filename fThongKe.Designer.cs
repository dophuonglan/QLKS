﻿namespace KS
{
    partial class fThongKe
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtpkNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpkNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.txbNumberPage = new System.Windows.Forms.TextBox();
            this.btnNextBillPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnLastBillPage = new System.Windows.Forms.Button();
            this.btnFirstBillPage = new System.Windows.Forms.Button();
            this.dtgvThongke = new System.Windows.Forms.DataGridView();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.maHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongke)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1334, 725);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtpkNgayKetThuc);
            this.tabPage1.Controls.Add(this.dtpkNgayBatDau);
            this.tabPage1.Controls.Add(this.txbNumberPage);
            this.tabPage1.Controls.Add(this.btnNextBillPage);
            this.tabPage1.Controls.Add(this.btnPreviousPage);
            this.tabPage1.Controls.Add(this.btnLastBillPage);
            this.tabPage1.Controls.Add(this.btnFirstBillPage);
            this.tabPage1.Controls.Add(this.dtgvThongke);
            this.tabPage1.Controls.Add(this.btnThongKe);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1326, 699);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống kê hóa đơn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtpkNgayKetThuc
            // 
            this.dtpkNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayKetThuc.Location = new System.Drawing.Point(908, 18);
            this.dtpkNgayKetThuc.Name = "dtpkNgayKetThuc";
            this.dtpkNgayKetThuc.Size = new System.Drawing.Size(176, 22);
            this.dtpkNgayKetThuc.TabIndex = 10;
            this.dtpkNgayKetThuc.ValueChanged += new System.EventHandler(this.dtpkNgayKetThuc_ValueChanged);
            // 
            // dtpkNgayBatDau
            // 
            this.dtpkNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayBatDau.Location = new System.Drawing.Point(294, 14);
            this.dtpkNgayBatDau.Name = "dtpkNgayBatDau";
            this.dtpkNgayBatDau.Size = new System.Drawing.Size(165, 22);
            this.dtpkNgayBatDau.TabIndex = 9;
            this.dtpkNgayBatDau.ValueChanged += new System.EventHandler(this.dtpkNgayBatDau_ValueChanged);
            // 
            // txbNumberPage
            // 
            this.txbNumberPage.Location = new System.Drawing.Point(594, 570);
            this.txbNumberPage.Name = "txbNumberPage";
            this.txbNumberPage.Size = new System.Drawing.Size(46, 22);
            this.txbNumberPage.TabIndex = 8;
            this.txbNumberPage.Text = "1";
            this.txbNumberPage.TextChanged += new System.EventHandler(this.txbNumberPage_TextChanged);
            // 
            // btnNextBillPage
            // 
            this.btnNextBillPage.Location = new System.Drawing.Point(658, 567);
            this.btnNextBillPage.Name = "btnNextBillPage";
            this.btnNextBillPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextBillPage.TabIndex = 7;
            this.btnNextBillPage.Text = "Next";
            this.btnNextBillPage.UseVisualStyleBackColor = true;
            this.btnNextBillPage.Click += new System.EventHandler(this.btnNextBillPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(492, 568);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousPage.TabIndex = 6;
            this.btnPreviousPage.Text = "Previous";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnLastBillPage
            // 
            this.btnLastBillPage.Location = new System.Drawing.Point(883, 570);
            this.btnLastBillPage.Name = "btnLastBillPage";
            this.btnLastBillPage.Size = new System.Drawing.Size(75, 23);
            this.btnLastBillPage.TabIndex = 5;
            this.btnLastBillPage.Text = "Last";
            this.btnLastBillPage.UseVisualStyleBackColor = true;
            this.btnLastBillPage.Click += new System.EventHandler(this.btnLastBillPage_Click);
            // 
            // btnFirstBillPage
            // 
            this.btnFirstBillPage.Location = new System.Drawing.Point(308, 568);
            this.btnFirstBillPage.Name = "btnFirstBillPage";
            this.btnFirstBillPage.Size = new System.Drawing.Size(75, 23);
            this.btnFirstBillPage.TabIndex = 4;
            this.btnFirstBillPage.Text = "First";
            this.btnFirstBillPage.UseVisualStyleBackColor = true;
            this.btnFirstBillPage.Click += new System.EventHandler(this.btnFirstBillPage_Click);
            // 
            // dtgvThongke
            // 
            this.dtgvThongke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHD,
            this.ngayThanhToan,
            this.tenKH,
            this.soDienThoai,
            this.ngayO,
            this.ngayDi,
            this.tienPhong,
            this.tienDV,
            this.tongTien});
            this.dtgvThongke.Location = new System.Drawing.Point(6, 53);
            this.dtgvThongke.Name = "dtgvThongke";
            this.dtgvThongke.Size = new System.Drawing.Size(1314, 477);
            this.dtgvThongke.TabIndex = 3;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(629, 15);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1326, 699);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // maHD
            // 
            this.maHD.DataPropertyName = "MAHD";
            this.maHD.FillWeight = 91.57135F;
            this.maHD.HeaderText = "Mã HĐ";
            this.maHD.Name = "maHD";
            // 
            // ngayThanhToan
            // 
            this.ngayThanhToan.DataPropertyName = "NGAYTHANHTOAN";
            this.ngayThanhToan.FillWeight = 98.20092F;
            this.ngayThanhToan.HeaderText = "Ngày Thanh Toán";
            this.ngayThanhToan.Name = "ngayThanhToan";
            // 
            // tenKH
            // 
            this.tenKH.DataPropertyName = "tenKH";
            this.tenKH.HeaderText = "Tên KH";
            this.tenKH.Name = "tenKH";
            // 
            // soDienThoai
            // 
            this.soDienThoai.DataPropertyName = "soDienThoai";
            this.soDienThoai.HeaderText = "SĐT";
            this.soDienThoai.Name = "soDienThoai";
            // 
            // ngayO
            // 
            this.ngayO.DataPropertyName = "ngayO";
            this.ngayO.HeaderText = "Ngày Ở";
            this.ngayO.Name = "ngayO";
            // 
            // ngayDi
            // 
            this.ngayDi.DataPropertyName = "ngayDi";
            this.ngayDi.HeaderText = "Ngày Đi";
            this.ngayDi.Name = "ngayDi";
            // 
            // tienPhong
            // 
            this.tienPhong.DataPropertyName = "TIENPHONG";
            this.tienPhong.FillWeight = 103.7217F;
            this.tienPhong.HeaderText = "Tiền Phòng";
            this.tienPhong.Name = "tienPhong";
            // 
            // tienDV
            // 
            this.tienDV.DataPropertyName = "TIENDV";
            this.tienDV.FillWeight = 100.0787F;
            this.tienDV.HeaderText = "Tiền Dịch Vụ";
            this.tienDV.Name = "tienDV";
            // 
            // tongTien
            // 
            this.tongTien.DataPropertyName = "tongTien";
            this.tongTien.HeaderText = "Tổng Tiền";
            this.tongTien.Name = "tongTien";
            // 
            // fThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tabControl1);
            this.Name = "fThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThongKe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fThongKe_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txbNumberPage;
        private System.Windows.Forms.Button btnNextBillPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnLastBillPage;
        private System.Windows.Forms.Button btnFirstBillPage;
        private System.Windows.Forms.DataGridView dtgvThongke;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DateTimePicker dtpkNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpkNgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn soDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTien;
    }
}