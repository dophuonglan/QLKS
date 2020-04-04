namespace KS
{
    partial class fPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnXoaPhg = new System.Windows.Forms.Button();
            this.btnSuaTTPhg = new System.Windows.Forms.Button();
            this.btnExitDSP = new System.Windows.Forms.Button();
            this.labThongTinPhg = new System.Windows.Forms.Label();
            this.btnShowTataCaTT = new System.Windows.Forms.Button();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.flowRoom = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDSP = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTongSoPhg = new System.Windows.Forms.Label();
            this.dtgrChiTietPhong = new System.Windows.Forms.DataGridView();
            this.maPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelAdmin.SuspendLayout();
            this.pnDSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrChiTietPhong)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "DANH SÁCH PHÒNG";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(237, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "Thêm Mới Phòng";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnXoaPhg
            // 
            this.btnXoaPhg.BackColor = System.Drawing.Color.PowderBlue;
            this.btnXoaPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPhg.Location = new System.Drawing.Point(131, 19);
            this.btnXoaPhg.Name = "btnXoaPhg";
            this.btnXoaPhg.Size = new System.Drawing.Size(89, 69);
            this.btnXoaPhg.TabIndex = 2;
            this.btnXoaPhg.Text = "Xóa Phòng";
            this.btnXoaPhg.UseVisualStyleBackColor = false;
            this.btnXoaPhg.Click += new System.EventHandler(this.btnXoaPhg_Click);
            // 
            // btnSuaTTPhg
            // 
            this.btnSuaTTPhg.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSuaTTPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaTTPhg.Location = new System.Drawing.Point(14, 19);
            this.btnSuaTTPhg.Name = "btnSuaTTPhg";
            this.btnSuaTTPhg.Size = new System.Drawing.Size(88, 69);
            this.btnSuaTTPhg.TabIndex = 3;
            this.btnSuaTTPhg.Text = "Sửa thông tin";
            this.btnSuaTTPhg.UseVisualStyleBackColor = false;
            this.btnSuaTTPhg.Click += new System.EventHandler(this.btnSuaTTPhg_Click_1);
            // 
            // btnExitDSP
            // 
            this.btnExitDSP.BackColor = System.Drawing.Color.PowderBlue;
            this.btnExitDSP.Location = new System.Drawing.Point(173, 19);
            this.btnExitDSP.Name = "btnExitDSP";
            this.btnExitDSP.Size = new System.Drawing.Size(89, 69);
            this.btnExitDSP.TabIndex = 1;
            this.btnExitDSP.Text = "Quay Lại";
            this.btnExitDSP.UseVisualStyleBackColor = false;
            this.btnExitDSP.Click += new System.EventHandler(this.btnExitDSP_Click);
            // 
            // labThongTinPhg
            // 
            this.labThongTinPhg.AutoSize = true;
            this.labThongTinPhg.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labThongTinPhg.Location = new System.Drawing.Point(973, 42);
            this.labThongTinPhg.Name = "labThongTinPhg";
            this.labThongTinPhg.Size = new System.Drawing.Size(123, 26);
            this.labThongTinPhg.TabIndex = 6;
            this.labThongTinPhg.Text = "THÔNG TIN";
            // 
            // btnShowTataCaTT
            // 
            this.btnShowTataCaTT.BackColor = System.Drawing.Color.PowderBlue;
            this.btnShowTataCaTT.Location = new System.Drawing.Point(8, 19);
            this.btnShowTataCaTT.Name = "btnShowTataCaTT";
            this.btnShowTataCaTT.Size = new System.Drawing.Size(129, 69);
            this.btnShowTataCaTT.TabIndex = 8;
            this.btnShowTataCaTT.Text = "Xem Thông Tin Tất Cả";
            this.btnShowTataCaTT.UseVisualStyleBackColor = false;
            this.btnShowTataCaTT.Click += new System.EventHandler(this.button5_Click);
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.Color.SteelBlue;
            this.panelAdmin.Controls.Add(this.btnXoaPhg);
            this.panelAdmin.Controls.Add(this.btnSuaTTPhg);
            this.panelAdmin.Controls.Add(this.button1);
            this.panelAdmin.Location = new System.Drawing.Point(695, 518);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(371, 115);
            this.panelAdmin.TabIndex = 9;
            // 
            // flowRoom
            // 
            this.flowRoom.AutoScroll = true;
            this.flowRoom.BackColor = System.Drawing.Color.MintCream;
            this.flowRoom.Location = new System.Drawing.Point(0, 3);
            this.flowRoom.Name = "flowRoom";
            this.flowRoom.Size = new System.Drawing.Size(688, 548);
            this.flowRoom.TabIndex = 0;
            // 
            // pnDSP
            // 
            this.pnDSP.BackColor = System.Drawing.Color.DarkGray;
            this.pnDSP.Controls.Add(this.flowRoom);
            this.pnDSP.Location = new System.Drawing.Point(0, 81);
            this.pnDSP.Name = "pnDSP";
            this.pnDSP.Size = new System.Drawing.Size(689, 552);
            this.pnDSP.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 656);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tổng Số Phòng:";
            // 
            // lbTongSoPhg
            // 
            this.lbTongSoPhg.AutoSize = true;
            this.lbTongSoPhg.Location = new System.Drawing.Point(137, 659);
            this.lbTongSoPhg.Name = "lbTongSoPhg";
            this.lbTongSoPhg.Size = new System.Drawing.Size(35, 13);
            this.lbTongSoPhg.TabIndex = 11;
            this.lbTongSoPhg.Text = "label3";
            // 
            // dtgrChiTietPhong
            // 
            this.dtgrChiTietPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrChiTietPhong.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrChiTietPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrChiTietPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrChiTietPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maPhong,
            this.tenPhong,
            this.trangThai,
            this.tenLoaiPhong,
            this.giaPhong,
            this.donVi});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrChiTietPhong.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgrChiTietPhong.Location = new System.Drawing.Point(695, 81);
            this.dtgrChiTietPhong.Name = "dtgrChiTietPhong";
            this.dtgrChiTietPhong.RowHeadersVisible = false;
            this.dtgrChiTietPhong.Size = new System.Drawing.Size(663, 431);
            this.dtgrChiTietPhong.TabIndex = 12;
            // 
            // maPhong
            // 
            this.maPhong.DataPropertyName = "MAPHONG";
            this.maPhong.HeaderText = "Mã Phòng";
            this.maPhong.Name = "maPhong";
            // 
            // tenPhong
            // 
            this.tenPhong.DataPropertyName = "TENPHONG";
            this.tenPhong.HeaderText = "Tên Phòng";
            this.tenPhong.Name = "tenPhong";
            // 
            // trangThai
            // 
            this.trangThai.DataPropertyName = "TINHTRANGPHONG";
            this.trangThai.HeaderText = "Trạng Thái";
            this.trangThai.Name = "trangThai";
            // 
            // tenLoaiPhong
            // 
            this.tenLoaiPhong.DataPropertyName = "TENLOAIPHONG";
            this.tenLoaiPhong.HeaderText = "Loại Phòng";
            this.tenLoaiPhong.Name = "tenLoaiPhong";
            // 
            // giaPhong
            // 
            this.giaPhong.DataPropertyName = "GIAPHONG";
            this.giaPhong.HeaderText = "Giá Hiện Tại";
            this.giaPhong.Name = "giaPhong";
            // 
            // donVi
            // 
            this.donVi.DataPropertyName = "DONVITIENTE";
            this.donVi.HeaderText = "Đơn Vị TT";
            this.donVi.Name = "donVi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btnExitDSP);
            this.panel2.Controls.Add(this.btnShowTataCaTT);
            this.panel2.Location = new System.Drawing.Point(1064, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 114);
            this.panel2.TabIndex = 13;
            // 
            // fPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtgrChiTietPhong);
            this.Controls.Add(this.lbTongSoPhg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.pnDSP);
            this.Controls.Add(this.labThongTinPhg);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "fPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fPhong_Load);
            this.panelAdmin.ResumeLayout(false);
            this.pnDSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrChiTietPhong)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnXoaPhg;
        private System.Windows.Forms.Button btnSuaTTPhg;
        private System.Windows.Forms.Button btnExitDSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labThongTinPhg;
        private System.Windows.Forms.Button btnShowTataCaTT;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.FlowLayoutPanel flowRoom;
        private System.Windows.Forms.Panel pnDSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTongSoPhg;
        private System.Windows.Forms.DataGridView dtgrChiTietPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn donVi;
        private System.Windows.Forms.Panel panel2;
    }
}