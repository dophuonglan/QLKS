namespace KS
{
    partial class fSoDo
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
            this.viewAllPhg = new System.Windows.Forms.Button();
            this.btnThongTinNhanVien = new System.Windows.Forms.Button();
            this.btnDatPhg = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLịchLàmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThuePhong = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewAllPhg
            // 
            this.viewAllPhg.BackColor = System.Drawing.Color.LightSkyBlue;
            this.viewAllPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAllPhg.Location = new System.Drawing.Point(365, 58);
            this.viewAllPhg.Name = "viewAllPhg";
            this.viewAllPhg.Size = new System.Drawing.Size(574, 70);
            this.viewAllPhg.TabIndex = 4;
            this.viewAllPhg.Text = "Xem Danh Sách Phòng";
            this.viewAllPhg.UseVisualStyleBackColor = false;
            this.viewAllPhg.Click += new System.EventHandler(this.viewAllPhg_Click);
            // 
            // btnThongTinNhanVien
            // 
            this.btnThongTinNhanVien.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnThongTinNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinNhanVien.Location = new System.Drawing.Point(365, 620);
            this.btnThongTinNhanVien.Name = "btnThongTinNhanVien";
            this.btnThongTinNhanVien.Size = new System.Drawing.Size(574, 71);
            this.btnThongTinNhanVien.TabIndex = 6;
            this.btnThongTinNhanVien.Text = "Thông Tin Tài Khoản Và Lịch Làm";
            this.btnThongTinNhanVien.UseVisualStyleBackColor = false;
            this.btnThongTinNhanVien.Click += new System.EventHandler(this.btnThongTinNhanVien_Click);
            // 
            // btnDatPhg
            // 
            this.btnDatPhg.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDatPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatPhg.Location = new System.Drawing.Point(365, 283);
            this.btnDatPhg.Name = "btnDatPhg";
            this.btnDatPhg.Size = new System.Drawing.Size(574, 73);
            this.btnDatPhg.TabIndex = 7;
            this.btnDatPhg.Text = "Đặt phòng";
            this.btnDatPhg.UseVisualStyleBackColor = false;
            this.btnDatPhg.Click += new System.EventHandler(this.btnDatPhg_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDichVu.Location = new System.Drawing.Point(365, 398);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(574, 64);
            this.btnDichVu.TabIndex = 8;
            this.btnDichVu.Text = "Dịch Vụ";
            this.btnDichVu.UseVisualStyleBackColor = false;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(365, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(574, 67);
            this.button1.TabIndex = 9;
            this.button1.Text = "Trả Phòng";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêHóaĐơnToolStripMenuItem,
            this.danhSáchNhânViênToolStripMenuItem,
            this.quảnLýLịchLàmToolStripMenuItem,
            this.quảnLýChứcVụToolStripMenuItem,
            this.thêmTàiKhoảnToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // thốngKêHóaĐơnToolStripMenuItem
            // 
            this.thốngKêHóaĐơnToolStripMenuItem.Name = "thốngKêHóaĐơnToolStripMenuItem";
            this.thốngKêHóaĐơnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.thốngKêHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.thốngKêHóaĐơnToolStripMenuItem.Text = "Thống kê";
            this.thốngKêHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // danhSáchNhânViênToolStripMenuItem
            // 
            this.danhSáchNhânViênToolStripMenuItem.Name = "danhSáchNhânViênToolStripMenuItem";
            this.danhSáchNhânViênToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.danhSáchNhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.danhSáchNhânViênToolStripMenuItem.Text = "Danh sách nhân viên";
            this.danhSáchNhânViênToolStripMenuItem.Click += new System.EventHandler(this.danhSáchNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýLịchLàmToolStripMenuItem
            // 
            this.quảnLýLịchLàmToolStripMenuItem.Name = "quảnLýLịchLàmToolStripMenuItem";
            this.quảnLýLịchLàmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.quảnLýLịchLàmToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.quảnLýLịchLàmToolStripMenuItem.Text = "Quản lý lịch làm";
            this.quảnLýLịchLàmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLịchLàmToolStripMenuItem_Click);
            // 
            // quảnLýChứcVụToolStripMenuItem
            // 
            this.quảnLýChứcVụToolStripMenuItem.Name = "quảnLýChứcVụToolStripMenuItem";
            this.quảnLýChứcVụToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.quảnLýChứcVụToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.quảnLýChứcVụToolStripMenuItem.Text = "Quản lý chức vụ";
            this.quảnLýChứcVụToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChứcVụToolStripMenuItem_Click);
            // 
            // thêmTàiKhoảnToolStripMenuItem
            // 
            this.thêmTàiKhoảnToolStripMenuItem.Name = "thêmTàiKhoảnToolStripMenuItem";
            this.thêmTàiKhoảnToolStripMenuItem.ShowShortcutKeys = false;
            this.thêmTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.thêmTàiKhoảnToolStripMenuItem.Text = "Quản lý  tài khoản";
            this.thêmTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.QLTaiKhoanToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // btnThuePhong
            // 
            this.btnThuePhong.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnThuePhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuePhong.Location = new System.Drawing.Point(365, 175);
            this.btnThuePhong.Name = "btnThuePhong";
            this.btnThuePhong.Size = new System.Drawing.Size(574, 70);
            this.btnThuePhong.TabIndex = 11;
            this.btnThuePhong.Text = "Thuê phòng";
            this.btnThuePhong.UseVisualStyleBackColor = false;
            this.btnThuePhong.Click += new System.EventHandler(this.btnThuePhong_Click);
            // 
            // fSoDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnThuePhong);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDichVu);
            this.Controls.Add(this.btnDatPhg);
            this.Controls.Add(this.btnThongTinNhanVien);
            this.Controls.Add(this.viewAllPhg);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "fSoDo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fSoDo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fSoDo_FormClosing);
            this.Load += new System.EventHandler(this.fSoDo_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button viewAllPhg;
        private System.Windows.Forms.Button btnThongTinNhanVien;
        private System.Windows.Forms.Button btnDatPhg;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLịchLàmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýChứcVụToolStripMenuItem;
        private System.Windows.Forms.Button btnThuePhong;
        private System.Windows.Forms.ToolStripMenuItem thêmTàiKhoảnToolStripMenuItem;
    }
}