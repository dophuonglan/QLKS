namespace KS
{
    partial class fThongTinTaiKhoanVaViecLam
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbTimKiem = new System.Windows.Forms.TextBox();
            this.dtpkNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpkNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtgvLichLamViec = new System.Windows.Forms.DataGridView();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lichLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbChucVu = new System.Windows.Forms.ComboBox();
            this.lbMaNhanVien = new System.Windows.Forms.Label();
            this.dtpkNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.txbSoDienThoai = new System.Windows.Forms.TextBox();
            this.cbbGioiTinh = new System.Windows.Forms.ComboBox();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbCheckPass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichLamViec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1371, 760);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1363, 734);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin tài khoản và lịch làm viêc";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txbTimKiem);
            this.groupBox2.Controls.Add(this.dtpkNgayKetThuc);
            this.groupBox2.Controls.Add(this.dtpkNgayBatDau);
            this.groupBox2.Controls.Add(this.dtgvLichLamViec);
            this.groupBox2.Location = new System.Drawing.Point(7, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1337, 408);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lịch làm việc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 18);
            this.label10.TabIndex = 44;
            this.label10.Text = "đến";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 18);
            this.label9.TabIndex = 43;
            this.label9.Text = "Từ ngày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(543, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Tìm kiếm";
            // 
            // txbTimKiem
            // 
            this.txbTimKiem.Location = new System.Drawing.Point(642, 74);
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.Size = new System.Drawing.Size(195, 24);
            this.txbTimKiem.TabIndex = 41;
            this.txbTimKiem.TextChanged += new System.EventHandler(this.txbTimKiem_TextChanged);
            // 
            // dtpkNgayKetThuc
            // 
            this.dtpkNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayKetThuc.Location = new System.Drawing.Point(301, 74);
            this.dtpkNgayKetThuc.Name = "dtpkNgayKetThuc";
            this.dtpkNgayKetThuc.Size = new System.Drawing.Size(137, 24);
            this.dtpkNgayKetThuc.TabIndex = 40;
            this.dtpkNgayKetThuc.ValueChanged += new System.EventHandler(this.dtpkNgayKetThuc_ValueChanged);
            // 
            // dtpkNgayBatDau
            // 
            this.dtpkNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayBatDau.Location = new System.Drawing.Point(88, 74);
            this.dtpkNgayBatDau.Name = "dtpkNgayBatDau";
            this.dtpkNgayBatDau.Size = new System.Drawing.Size(140, 24);
            this.dtpkNgayBatDau.TabIndex = 39;
            this.dtpkNgayBatDau.ValueChanged += new System.EventHandler(this.dtpkNgayBatDau_ValueChanged);
            // 
            // dtgvLichLamViec
            // 
            this.dtgvLichLamViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLichLamViec.BackgroundColor = System.Drawing.Color.White;
            this.dtgvLichLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichLamViec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNhanVien,
            this.tenNhanVien,
            this.lichLamViec,
            this.buoi});
            this.dtgvLichLamViec.Location = new System.Drawing.Point(1, 116);
            this.dtgvLichLamViec.Name = "dtgvLichLamViec";
            this.dtgvLichLamViec.ReadOnly = true;
            this.dtgvLichLamViec.Size = new System.Drawing.Size(1310, 267);
            this.dtgvLichLamViec.TabIndex = 0;
            // 
            // maNhanVien
            // 
            this.maNhanVien.DataPropertyName = "MANHANVIEN";
            this.maNhanVien.HeaderText = "MSNV";
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.ReadOnly = true;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.DataPropertyName = "TENNHANVIEN";
            this.tenNhanVien.HeaderText = "Họ tên";
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.ReadOnly = true;
            // 
            // lichLamViec
            // 
            this.lichLamViec.DataPropertyName = "NGAYLAMVIEC";
            this.lichLamViec.HeaderText = "Ngày làm việc";
            this.lichLamViec.Name = "lichLamViec";
            this.lichLamViec.ReadOnly = true;
            // 
            // buoi
            // 
            this.buoi.DataPropertyName = "BUOI";
            this.buoi.HeaderText = "Buổi";
            this.buoi.Name = "buoi";
            this.buoi.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txbCheckPass);
            this.groupBox1.Controls.Add(this.cbbChucVu);
            this.groupBox1.Controls.Add(this.lbMaNhanVien);
            this.groupBox1.Controls.Add(this.dtpkNgaySinh);
            this.groupBox1.Controls.Add(this.txbDiaChi);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.txbSoDienThoai);
            this.groupBox1.Controls.Add(this.cbbGioiTinh);
            this.groupBox1.Controls.Add(this.btnSuaThongTin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1336, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // cbbChucVu
            // 
            this.cbbChucVu.Enabled = false;
            this.cbbChucVu.FormattingEnabled = true;
            this.cbbChucVu.Location = new System.Drawing.Point(1156, 23);
            this.cbbChucVu.Name = "cbbChucVu";
            this.cbbChucVu.Size = new System.Drawing.Size(121, 26);
            this.cbbChucVu.TabIndex = 40;
            // 
            // lbMaNhanVien
            // 
            this.lbMaNhanVien.AutoSize = true;
            this.lbMaNhanVien.Location = new System.Drawing.Point(120, 30);
            this.lbMaNhanVien.Name = "lbMaNhanVien";
            this.lbMaNhanVien.Size = new System.Drawing.Size(46, 18);
            this.lbMaNhanVien.TabIndex = 39;
            this.lbMaNhanVien.Text = "label8";
            // 
            // dtpkNgaySinh
            // 
            this.dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgaySinh.Enabled = false;
            this.dtpkNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgaySinh.Location = new System.Drawing.Point(123, 75);
            this.dtpkNgaySinh.Name = "dtpkNgaySinh";
            this.dtpkNgaySinh.Size = new System.Drawing.Size(200, 24);
            this.dtpkNgaySinh.TabIndex = 38;
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Enabled = false;
            this.txbDiaChi.Location = new System.Drawing.Point(444, 76);
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.Size = new System.Drawing.Size(164, 24);
            this.txbDiaChi.TabIndex = 12;
            // 
            // txbTen
            // 
            this.txbTen.Enabled = false;
            this.txbTen.Location = new System.Drawing.Point(444, 30);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(164, 24);
            this.txbTen.TabIndex = 11;
            // 
            // txbSoDienThoai
            // 
            this.txbSoDienThoai.Enabled = false;
            this.txbSoDienThoai.Location = new System.Drawing.Point(832, 30);
            this.txbSoDienThoai.Name = "txbSoDienThoai";
            this.txbSoDienThoai.Size = new System.Drawing.Size(164, 24);
            this.txbSoDienThoai.TabIndex = 10;
            this.txbSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSoDienThoai_KeyPress);
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.Enabled = false;
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbbGioiTinh.Location = new System.Drawing.Point(832, 76);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(164, 26);
            this.cbbGioiTinh.TabIndex = 9;
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.Location = new System.Drawing.Point(562, 202);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(151, 35);
            this.btnSuaThongTin.TabIndex = 7;
            this.btnSuaThongTin.Text = "Sửa Thông Tin";
            this.btnSuaThongTin.UseVisualStyleBackColor = true;
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1076, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Chức Vụ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(745, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giới tính :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "SĐT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa chỉ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Sinh :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSNV :";
            // 
            // txbCheckPass
            // 
            this.txbCheckPass.Enabled = false;
            this.txbCheckPass.Location = new System.Drawing.Point(562, 153);
            this.txbCheckPass.Name = "txbCheckPass";
            this.txbCheckPass.Size = new System.Drawing.Size(164, 24);
            this.txbCheckPass.TabIndex = 41;
            this.txbCheckPass.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 42;
            this.label11.Text = "Xác nhận mật khẩu: ";
            this.label11.Visible = false;
            // 
            // fThongTinTaiKhoanVaViecLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tabControl1);
            this.Name = "fThongTinTaiKhoanVaViecLam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThongTinTaiKhoanVaViecLam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ThongTinNhanVien_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichLamViec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgvLichLamViec;
        private System.Windows.Forms.Button btnSuaThongTin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.TextBox txbSoDienThoai;
        private System.Windows.Forms.ComboBox cbbGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpkNgaySinh;
        private System.Windows.Forms.Label lbMaNhanVien;
        private System.Windows.Forms.DateTimePicker dtpkNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpkNgayBatDau;
        private System.Windows.Forms.TextBox txbTimKiem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn lichLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn buoi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbCheckPass;
    }
}