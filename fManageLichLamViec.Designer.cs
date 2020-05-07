namespace KS
{
    partial class fManageLichLamViec
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
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.lbThongBaoBuoi = new System.Windows.Forms.Label();
            this.lbThongBaoMA = new System.Windows.Forms.Label();
            this.txbTenNhanVienLich = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpkLichLamLich = new System.Windows.Forms.DateTimePicker();
            this.cbbBuoiLich = new System.Windows.Forms.ComboBox();
            this.cbbMaNhanVienLich = new System.Windows.Forms.ComboBox();
            this.dtgvLichLamViec = new System.Windows.Forms.DataGridView();
            this.maLichLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbTimKiem = new System.Windows.Forms.TextBox();
            this.dtpkNgaybatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpkNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichLamViec)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBoxAdmin.Controls.Add(this.btnSua);
            this.groupBoxAdmin.Controls.Add(this.label15);
            this.groupBoxAdmin.Controls.Add(this.btnThem);
            this.groupBoxAdmin.Controls.Add(this.lbThongBaoBuoi);
            this.groupBoxAdmin.Controls.Add(this.lbThongBaoMA);
            this.groupBoxAdmin.Controls.Add(this.txbTenNhanVienLich);
            this.groupBoxAdmin.Controls.Add(this.label14);
            this.groupBoxAdmin.Controls.Add(this.label13);
            this.groupBoxAdmin.Controls.Add(this.label12);
            this.groupBoxAdmin.Controls.Add(this.label11);
            this.groupBoxAdmin.Controls.Add(this.dtpkLichLamLich);
            this.groupBoxAdmin.Controls.Add(this.cbbBuoiLich);
            this.groupBoxAdmin.Controls.Add(this.cbbMaNhanVienLich);
            this.groupBoxAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAdmin.Location = new System.Drawing.Point(804, 13);
            this.groupBoxAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAdmin.Size = new System.Drawing.Size(566, 650);
            this.groupBoxAdmin.TabIndex = 3;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Thêm lịch làm việc";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(310, 436);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 40);
            this.btnSua.TabIndex = 52;
            this.btnSua.Text = "Sửa lịch";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(106, 35);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(328, 18);
            this.label15.TabIndex = 51;
            this.label15.Text = "Lưu ý:Sau khi nhập MSNV nhấn enter để xem tên";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(139, 436);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(134, 40);
            this.btnThem.TabIndex = 50;
            this.btnThem.Text = "Thêm lịch";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lbThongBaoBuoi
            // 
            this.lbThongBaoBuoi.AutoSize = true;
            this.lbThongBaoBuoi.ForeColor = System.Drawing.Color.Red;
            this.lbThongBaoBuoi.Location = new System.Drawing.Point(409, 386);
            this.lbThongBaoBuoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThongBaoBuoi.Name = "lbThongBaoBuoi";
            this.lbThongBaoBuoi.Size = new System.Drawing.Size(107, 18);
            this.lbThongBaoBuoi.TabIndex = 49;
            this.lbThongBaoBuoi.Text = "không để trống";
            this.lbThongBaoBuoi.Visible = false;
            // 
            // lbThongBaoMA
            // 
            this.lbThongBaoMA.AutoSize = true;
            this.lbThongBaoMA.ForeColor = System.Drawing.Color.Red;
            this.lbThongBaoMA.Location = new System.Drawing.Point(409, 99);
            this.lbThongBaoMA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThongBaoMA.Name = "lbThongBaoMA";
            this.lbThongBaoMA.Size = new System.Drawing.Size(107, 18);
            this.lbThongBaoMA.TabIndex = 47;
            this.lbThongBaoMA.Text = "không để trống";
            this.lbThongBaoMA.Visible = false;
            // 
            // txbTenNhanVienLich
            // 
            this.txbTenNhanVienLich.Enabled = false;
            this.txbTenNhanVienLich.Location = new System.Drawing.Point(182, 184);
            this.txbTenNhanVienLich.Margin = new System.Windows.Forms.Padding(4);
            this.txbTenNhanVienLich.Name = "txbTenNhanVienLich";
            this.txbTenNhanVienLich.Size = new System.Drawing.Size(189, 24);
            this.txbTenNhanVienLich.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(106, 104);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 18);
            this.label14.TabIndex = 45;
            this.label14.Text = "MSNV";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(136, 381);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 18);
            this.label13.TabIndex = 44;
            this.label13.Text = "Buổi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(106, 284);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 18);
            this.label12.TabIndex = 43;
            this.label12.Text = "Lịch Làm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 190);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 18);
            this.label11.TabIndex = 42;
            this.label11.Text = "Tên";
            // 
            // dtpkLichLamLich
            // 
            this.dtpkLichLamLich.CustomFormat = "dd/MM/yyyy";
            this.dtpkLichLamLich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkLichLamLich.Location = new System.Drawing.Point(182, 284);
            this.dtpkLichLamLich.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkLichLamLich.Name = "dtpkLichLamLich";
            this.dtpkLichLamLich.Size = new System.Drawing.Size(189, 24);
            this.dtpkLichLamLich.TabIndex = 41;
            // 
            // cbbBuoiLich
            // 
            this.cbbBuoiLich.FormattingEnabled = true;
            this.cbbBuoiLich.Items.AddRange(new object[] {
            "Sáng",
            "Chiều",
            "Tối"});
            this.cbbBuoiLich.Location = new System.Drawing.Point(185, 378);
            this.cbbBuoiLich.Margin = new System.Windows.Forms.Padding(4);
            this.cbbBuoiLich.Name = "cbbBuoiLich";
            this.cbbBuoiLich.Size = new System.Drawing.Size(186, 26);
            this.cbbBuoiLich.TabIndex = 2;
            // 
            // cbbMaNhanVienLich
            // 
            this.cbbMaNhanVienLich.FormattingEnabled = true;
            this.cbbMaNhanVienLich.Location = new System.Drawing.Point(182, 96);
            this.cbbMaNhanVienLich.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMaNhanVienLich.Name = "cbbMaNhanVienLich";
            this.cbbMaNhanVienLich.Size = new System.Drawing.Size(189, 26);
            this.cbbMaNhanVienLich.TabIndex = 0;
            this.cbbMaNhanVienLich.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbMaNhanVienLich_KeyPress);
            this.cbbMaNhanVienLich.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbMaNhanVienLich_KeyUp);
            // 
            // dtgvLichLamViec
            // 
            this.dtgvLichLamViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLichLamViec.BackgroundColor = System.Drawing.Color.White;
            this.dtgvLichLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichLamViec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLichLamViec,
            this.maNhanVien,
            this.tenNhanVien,
            this.ngayLamViec,
            this.buoi});
            this.dtgvLichLamViec.Location = new System.Drawing.Point(3, 154);
            this.dtgvLichLamViec.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvLichLamViec.Name = "dtgvLichLamViec";
            this.dtgvLichLamViec.ReadOnly = true;
            this.dtgvLichLamViec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLichLamViec.Size = new System.Drawing.Size(793, 509);
            this.dtgvLichLamViec.TabIndex = 4;
            this.dtgvLichLamViec.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvLichLamViec_CellClick);
            this.dtgvLichLamViec.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvLichLamViec_CellContentClick);
            this.dtgvLichLamViec.SelectionChanged += new System.EventHandler(this.dtgvLichLamViec_SelectionChanged);
            // 
            // maLichLamViec
            // 
            this.maLichLamViec.DataPropertyName = "MALICHLAMVIEC";
            this.maLichLamViec.HeaderText = "Mã LLV";
            this.maLichLamViec.Name = "maLichLamViec";
            this.maLichLamViec.ReadOnly = true;
            // 
            // maNhanVien
            // 
            this.maNhanVien.DataPropertyName = "MANHANVIEN";
            this.maNhanVien.HeaderText = "Mã NV";
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.ReadOnly = true;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.DataPropertyName = "TENNHANVIEN";
            this.tenNhanVien.HeaderText = "Tên Nhân Viên";
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.ReadOnly = true;
            // 
            // ngayLamViec
            // 
            this.ngayLamViec.DataPropertyName = "NGAYLAMVIEC";
            this.ngayLamViec.HeaderText = "Ngày Làm Việc";
            this.ngayLamViec.Name = "ngayLamViec";
            this.ngayLamViec.ReadOnly = true;
            // 
            // buoi
            // 
            this.buoi.DataPropertyName = "BUOI";
            this.buoi.HeaderText = "Buổi";
            this.buoi.Name = "buoi";
            this.buoi.ReadOnly = true;
            // 
            // txbTimKiem
            // 
            this.txbTimKiem.Location = new System.Drawing.Point(255, 98);
            this.txbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.Size = new System.Drawing.Size(210, 24);
            this.txbTimKiem.TabIndex = 5;
            this.txbTimKiem.TextChanged += new System.EventHandler(this.txbTimKiem_TextChanged);
            // 
            // dtpkNgaybatDau
            // 
            this.dtpkNgaybatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgaybatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgaybatDau.Location = new System.Drawing.Point(105, 98);
            this.dtpkNgaybatDau.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkNgaybatDau.Name = "dtpkNgaybatDau";
            this.dtpkNgaybatDau.Size = new System.Drawing.Size(116, 24);
            this.dtpkNgaybatDau.TabIndex = 39;
            this.dtpkNgaybatDau.Value = new System.DateTime(2020, 3, 17, 0, 0, 0, 0);
            this.dtpkNgaybatDau.ValueChanged += new System.EventHandler(this.dtpkNgaybatDau_ValueChanged);
            // 
            // dtpkNgayKetThuc
            // 
            this.dtpkNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayKetThuc.Location = new System.Drawing.Point(585, 98);
            this.dtpkNgayKetThuc.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkNgayKetThuc.Name = "dtpkNgayKetThuc";
            this.dtpkNgayKetThuc.Size = new System.Drawing.Size(111, 24);
            this.dtpkNgayKetThuc.TabIndex = 40;
            this.dtpkNgayKetThuc.ValueChanged += new System.EventHandler(this.dtpkNgayKetThuc_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "Tìm kiếm nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 43;
            this.label3.Text = "đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 24);
            this.label4.TabIndex = 44;
            this.label4.Text = "LỊCH LÀM VIỆC";
            // 
            // fManageLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpkNgayKetThuc);
            this.Controls.Add(this.dtpkNgaybatDau);
            this.Controls.Add(this.txbTimKiem);
            this.Controls.Add(this.dtgvLichLamViec);
            this.Controls.Add(this.groupBoxAdmin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fManageLichLamViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fManageLichLamViec";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fManageLichLamViec_Load);
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBoxAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichLamViec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lbThongBaoBuoi;
        private System.Windows.Forms.Label lbThongBaoMA;
        private System.Windows.Forms.TextBox txbTenNhanVienLich;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpkLichLamLich;
        private System.Windows.Forms.ComboBox cbbBuoiLich;
        private System.Windows.Forms.ComboBox cbbMaNhanVienLich;
        private System.Windows.Forms.DataGridView dtgvLichLamViec;
        private System.Windows.Forms.TextBox txbTimKiem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DateTimePicker dtpkNgaybatDau;
        private System.Windows.Forms.DateTimePicker dtpkNgayKetThuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLichLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn buoi;
        private System.Windows.Forms.Label label4;
    }
}