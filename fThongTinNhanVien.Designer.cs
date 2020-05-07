namespace KS
{
    partial class fThongTinNhanVien
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
            this.label2 = new System.Windows.Forms.Label();
            this.txbTimKiemNhanVien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbThongBaoSDT = new System.Windows.Forms.Label();
            this.lbThongBaoDiaChi = new System.Windows.Forms.Label();
            this.lbThongBaoHoTen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpkNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.btnThemNhanVien = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbGioiTinh = new System.Windows.Forms.ComboBox();
            this.cbbChucVu = new System.Windows.Forms.ComboBox();
            this.txbTenNhanVien = new System.Windows.Forms.TextBox();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSuaNhanVien = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbSDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgvThongTInNhanVien = new System.Windows.Forms.DataGridView();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongTInNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1371, 734);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txbTimKiemNhanVien);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dtgvThongTInNhanVien);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1363, 708);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm kiếm nhân viên";
            // 
            // txbTimKiemNhanVien
            // 
            this.txbTimKiemNhanVien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txbTimKiemNhanVien.Location = new System.Drawing.Point(360, 79);
            this.txbTimKiemNhanVien.Name = "txbTimKiemNhanVien";
            this.txbTimKiemNhanVien.Size = new System.Drawing.Size(181, 24);
            this.txbTimKiemNhanVien.TabIndex = 3;
            this.txbTimKiemNhanVien.TextChanged += new System.EventHandler(this.txbTimKiemNhanVien_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách Nhân Viên";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(842, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 531);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng cập nhật danh sách nhân viên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbThongBaoSDT);
            this.panel1.Controls.Add(this.lbThongBaoDiaChi);
            this.panel1.Controls.Add(this.lbThongBaoHoTen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpkNgaySinh);
            this.panel1.Controls.Add(this.btnThemNhanVien);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbbGioiTinh);
            this.panel1.Controls.Add(this.cbbChucVu);
            this.panel1.Controls.Add(this.txbTenNhanVien);
            this.panel1.Controls.Add(this.txbDiaChi);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSuaNhanVien);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbSDT);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(32, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 428);
            this.panel1.TabIndex = 14;
            // 
            // lbThongBaoSDT
            // 
            this.lbThongBaoSDT.AutoSize = true;
            this.lbThongBaoSDT.ForeColor = System.Drawing.Color.Red;
            this.lbThongBaoSDT.Location = new System.Drawing.Point(303, 309);
            this.lbThongBaoSDT.Name = "lbThongBaoSDT";
            this.lbThongBaoSDT.Size = new System.Drawing.Size(107, 18);
            this.lbThongBaoSDT.TabIndex = 19;
            this.lbThongBaoSDT.Text = "không để trống";
            this.lbThongBaoSDT.Visible = false;
            // 
            // lbThongBaoDiaChi
            // 
            this.lbThongBaoDiaChi.AutoSize = true;
            this.lbThongBaoDiaChi.ForeColor = System.Drawing.Color.Red;
            this.lbThongBaoDiaChi.Location = new System.Drawing.Point(303, 184);
            this.lbThongBaoDiaChi.Name = "lbThongBaoDiaChi";
            this.lbThongBaoDiaChi.Size = new System.Drawing.Size(107, 18);
            this.lbThongBaoDiaChi.TabIndex = 18;
            this.lbThongBaoDiaChi.Text = "không để trống";
            this.lbThongBaoDiaChi.Visible = false;
            // 
            // lbThongBaoHoTen
            // 
            this.lbThongBaoHoTen.AutoSize = true;
            this.lbThongBaoHoTen.ForeColor = System.Drawing.Color.Red;
            this.lbThongBaoHoTen.Location = new System.Drawing.Point(303, 16);
            this.lbThongBaoHoTen.Name = "lbThongBaoHoTen";
            this.lbThongBaoHoTen.Size = new System.Drawing.Size(107, 18);
            this.lbThongBaoHoTen.TabIndex = 14;
            this.lbThongBaoHoTen.Text = "không để trống";
            this.lbThongBaoHoTen.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày sinh";
            // 
            // dtpkNgaySinh
            // 
            this.dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgaySinh.Location = new System.Drawing.Point(142, 124);
            this.dtpkNgaySinh.Name = "dtpkNgaySinh";
            this.dtpkNgaySinh.Size = new System.Drawing.Size(155, 24);
            this.dtpkNgaySinh.TabIndex = 13;
            this.dtpkNgaySinh.Value = new System.DateTime(2020, 3, 23, 0, 0, 0, 0);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.Location = new System.Drawing.Point(46, 361);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(148, 30);
            this.btnThemNhanVien.TabIndex = 0;
            this.btnThemNhanVien.Text = "Thêm Nhân Viên";
            this.btnThemNhanVien.UseVisualStyleBackColor = true;
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbbGioiTinh.Location = new System.Drawing.Point(142, 68);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(155, 26);
            this.cbbGioiTinh.TabIndex = 11;
            // 
            // cbbChucVu
            // 
            this.cbbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChucVu.FormattingEnabled = true;
            this.cbbChucVu.Location = new System.Drawing.Point(142, 242);
            this.cbbChucVu.Name = "cbbChucVu";
            this.cbbChucVu.Size = new System.Drawing.Size(155, 26);
            this.cbbChucVu.TabIndex = 12;
            // 
            // txbTenNhanVien
            // 
            this.txbTenNhanVien.Location = new System.Drawing.Point(142, 16);
            this.txbTenNhanVien.Name = "txbTenNhanVien";
            this.txbTenNhanVien.Size = new System.Drawing.Size(155, 24);
            this.txbTenNhanVien.TabIndex = 8;
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Location = new System.Drawing.Point(142, 184);
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.Size = new System.Drawing.Size(155, 24);
            this.txbDiaChi.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giới tính";
            // 
            // btnSuaNhanVien
            // 
            this.btnSuaNhanVien.Location = new System.Drawing.Point(245, 361);
            this.btnSuaNhanVien.Name = "btnSuaNhanVien";
            this.btnSuaNhanVien.Size = new System.Drawing.Size(136, 30);
            this.btnSuaNhanVien.TabIndex = 1;
            this.btnSuaNhanVien.Text = "Sửa Nhân viên";
            this.btnSuaNhanVien.UseVisualStyleBackColor = true;
            this.btnSuaNhanVien.Click += new System.EventHandler(this.btnSuaNhanVien_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ và tên";
            // 
            // txbSDT
            // 
            this.txbSDT.Location = new System.Drawing.Point(142, 303);
            this.txbSDT.Name = "txbSDT";
            this.txbSDT.Size = new System.Drawing.Size(155, 24);
            this.txbSDT.TabIndex = 10;
            this.txbSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSDT_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Chức vụ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "SĐT";
            // 
            // dtgvThongTInNhanVien
            // 
            this.dtgvThongTInNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongTInNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dtgvThongTInNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongTInNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNhanVien,
            this.tenNhanVien,
            this.gioiTinh,
            this.ngaySinh,
            this.diaChi,
            this.chucVu,
            this.sdt});
            this.dtgvThongTInNhanVien.Location = new System.Drawing.Point(8, 118);
            this.dtgvThongTInNhanVien.Name = "dtgvThongTInNhanVien";
            this.dtgvThongTInNhanVien.ReadOnly = true;
            this.dtgvThongTInNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvThongTInNhanVien.Size = new System.Drawing.Size(828, 531);
            this.dtgvThongTInNhanVien.TabIndex = 0;
            this.dtgvThongTInNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThongTInNhanVien_CellClick);
            this.dtgvThongTInNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThongTInNhanVien_CellContentClick);
            // 
            // maNhanVien
            // 
            this.maNhanVien.DataPropertyName = "MANHANVIEN";
            this.maNhanVien.HeaderText = "Mã Nhân Viên";
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
            // gioiTinh
            // 
            this.gioiTinh.DataPropertyName = "GIOITINH";
            this.gioiTinh.HeaderText = "Giới Tính";
            this.gioiTinh.Name = "gioiTinh";
            this.gioiTinh.ReadOnly = true;
            // 
            // ngaySinh
            // 
            this.ngaySinh.DataPropertyName = "NGAYSINH";
            this.ngaySinh.HeaderText = "Ngày Sinh";
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.ReadOnly = true;
            // 
            // diaChi
            // 
            this.diaChi.DataPropertyName = "DIACHI";
            this.diaChi.HeaderText = "Địa Chỉ";
            this.diaChi.Name = "diaChi";
            this.diaChi.ReadOnly = true;
            // 
            // chucVu
            // 
            this.chucVu.DataPropertyName = "TENCHUCVU";
            this.chucVu.HeaderText = "Chức Vụ";
            this.chucVu.Name = "chucVu";
            this.chucVu.ReadOnly = true;
            // 
            // sdt
            // 
            this.sdt.DataPropertyName = "SODIENTHOAI";
            this.sdt.HeaderText = "SĐT";
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            // 
            // fThongTinNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "fThongTinNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThongTinNhanVien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fThongTinKH_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongTInNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn chucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridView dtgvThongTInNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTimKiemNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbChucVu;
        private System.Windows.Forms.ComboBox cbbGioiTinh;
        private System.Windows.Forms.TextBox txbSDT;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.TextBox txbTenNhanVien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSuaNhanVien;
        private System.Windows.Forms.Button btnThemNhanVien;
        private System.Windows.Forms.DateTimePicker dtpkNgaySinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbThongBaoHoTen;
        private System.Windows.Forms.Label lbThongBaoSDT;
        private System.Windows.Forms.Label lbThongBaoDiaChi;
    }
}