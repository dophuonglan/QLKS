namespace KS
{
    partial class fThongTinKH
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
            this.dtgvDanhSachKH = new System.Windows.Forms.DataGridView();
            this.clMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDatPhg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTimKiem = new System.Windows.Forms.TextBox();
            this.addNewKH = new System.Windows.Forms.Button();
            this.txbTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachKH)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDanhSachKH
            // 
            this.dtgvDanhSachKH.AllowUserToDeleteRows = false;
            this.dtgvDanhSachKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDanhSachKH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvDanhSachKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSachKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaKH,
            this.clTenKH,
            this.clGioiTinh,
            this.clNgaySinh,
            this.clDiaChi,
            this.clSDT,
            this.clCMT,
            this.clDatPhg,
            this.clHoaDon});
            this.dtgvDanhSachKH.Location = new System.Drawing.Point(1, 82);
            this.dtgvDanhSachKH.Name = "dtgvDanhSachKH";
            this.dtgvDanhSachKH.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgvDanhSachKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDanhSachKH.Size = new System.Drawing.Size(799, 175);
            this.dtgvDanhSachKH.TabIndex = 0;
            this.dtgvDanhSachKH.VirtualMode = true;
            // 
            // clMaKH
            // 
            this.clMaKH.DataPropertyName = "MAKH";
            this.clMaKH.HeaderText = "Mã KH";
            this.clMaKH.Name = "clMaKH";
            this.clMaKH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clTenKH
            // 
            this.clTenKH.DataPropertyName = "TENKH";
            this.clTenKH.HeaderText = "Tên KH";
            this.clTenKH.Name = "clTenKH";
            // 
            // clGioiTinh
            // 
            this.clGioiTinh.DataPropertyName = "GIOITINH";
            this.clGioiTinh.HeaderText = "Giới Tính";
            this.clGioiTinh.Name = "clGioiTinh";
            // 
            // clNgaySinh
            // 
            this.clNgaySinh.DataPropertyName = "NGAYSINH";
            this.clNgaySinh.HeaderText = "NgaySinh";
            this.clNgaySinh.Name = "clNgaySinh";
            // 
            // clDiaChi
            // 
            this.clDiaChi.DataPropertyName = "DIACHI";
            this.clDiaChi.HeaderText = "Địa Chỉ";
            this.clDiaChi.Name = "clDiaChi";
            // 
            // clSDT
            // 
            this.clSDT.DataPropertyName = "SODIENTHOAI";
            this.clSDT.HeaderText = "SĐT";
            this.clSDT.Name = "clSDT";
            // 
            // clCMT
            // 
            this.clCMT.DataPropertyName = "CHUNGMINHTHU";
            this.clCMT.HeaderText = "CMT";
            this.clCMT.Name = "clCMT";
            // 
            // clDatPhg
            // 
            this.clDatPhg.DataPropertyName = "DatPhongs";
            this.clDatPhg.HeaderText = "Đặt Phòng";
            this.clDatPhg.Name = "clDatPhg";
            this.clDatPhg.Visible = false;
            // 
            // clHoaDon
            // 
            this.clHoaDon.DataPropertyName = "HoaDons";
            this.clHoaDon.HeaderText = "Hóa Đơn";
            this.clHoaDon.Name = "clHoaDon";
            this.clHoaDon.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm SDT";
            // 
            // txbTimKiem
            // 
            this.txbTimKiem.Location = new System.Drawing.Point(356, 37);
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.Size = new System.Drawing.Size(100, 20);
            this.txbTimKiem.TabIndex = 2;
            this.txbTimKiem.TextChanged += new System.EventHandler(this.txbTimKiem_TextChanged);
            // 
            // addNewKH
            // 
            this.addNewKH.Location = new System.Drawing.Point(455, 273);
            this.addNewKH.Name = "addNewKH";
            this.addNewKH.Size = new System.Drawing.Size(95, 31);
            this.addNewKH.TabIndex = 3;
            this.addNewKH.Text = "Khách hàng mới";
            this.addNewKH.UseVisualStyleBackColor = true;
            this.addNewKH.Click += new System.EventHandler(this.addNewKH_Click);
            // 
            // txbTenKH
            // 
            this.txbTenKH.Location = new System.Drawing.Point(249, 279);
            this.txbTenKH.Name = "txbTenKH";
            this.txbTenKH.Size = new System.Drawing.Size(114, 20);
            this.txbTenKH.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên";
            // 
            // txbMaKH
            // 
            this.txbMaKH.Location = new System.Drawing.Point(75, 279);
            this.txbMaKH.Name = "txbMaKH";
            this.txbMaKH.Size = new System.Drawing.Size(114, 20);
            this.txbMaKH.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã";
            // 
            // fThongTinKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbMaKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTenKH);
            this.Controls.Add(this.addNewKH);
            this.Controls.Add(this.txbTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvDanhSachKH);
            this.MaximizeBox = false;
            this.Name = "fThongTinKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThongTinKH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fThongTinKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvDanhSachKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTimKiem;
        private System.Windows.Forms.Button addNewKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDatPhg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHoaDon;
        private System.Windows.Forms.TextBox txbTenKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMaKH;
        private System.Windows.Forms.Label label3;
    }
}