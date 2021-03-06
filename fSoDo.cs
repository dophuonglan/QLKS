﻿
using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS
{
    public partial class fSoDo : Form
    {
        private static bool isClick;

        public static bool IsClick { get => isClick; set => isClick = value; }
        DatPhongDAO datPhongDAO = null;
        public fSoDo()
        {
            datPhongDAO = new DatPhongDAO();
            InitializeComponent();
        }

        void PhanQuyen()
        {
            if ((fLogin.maChucVu == 4) || fLogin.maChucVu == 5)
            {
                adminToolStripMenuItem.Enabled = true;
            }
            else adminToolStripMenuItem.Enabled = false;
        }
        private void fSoDo_Load(object sender, EventArgs e)
        {
            PhanQuyen();
        }

        private void viewAllPhg_Click(object sender, EventArgs e)
        {
            fPhong phong = new fPhong();
            this.Hide();
            phong.ShowDialog();
            this.Show();
        }

        private void btnThongTinNhanVien_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoanVaViecLam thongTinNhanVien = new fThongTinTaiKhoanVaViecLam();
            this.Hide();
            thongTinNhanVien.ShowDialog();
            this.Show();
        }

        private void btnDatPhg_Click(object sender, EventArgs e)
        {
            fDatPhong datPhong = new fDatPhong();
            this.Hide();
            datPhong.ShowDialog();
            this.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            fDichVu dichVu = new fDichVu();
            this.Hide();
            dichVu.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            var lstThuePhong = thuePhongDAO.GetThuePhong();
            if (lstThuePhong.Count > 0)
            {
                fThanhToan thanhToan = new fThanhToan();
                IsClick = true;
                Hide();
                thanhToan.ShowDialog();
                Show();
            }
            else MessageBox.Show("Hiện không có phòng cần thanh toán");
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoanVaViecLam fThongTinNhanVien = new fThongTinTaiKhoanVaViecLam();
            Hide();
            fThongTinNhanVien.ShowDialog();
            Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKe fThongKe = new fThongKe();
            Hide();
            fThongKe.ShowDialog();
            Show();
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinNhanVien fThongTinNhanVien = new fThongTinNhanVien();
            Hide();
            fThongTinNhanVien.ShowDialog();
            Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhanQuyen();
            this.Close();
        }

        private void quảnLýLịchLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fManageLichLamViec fManageLichLamViec = new fManageLichLamViec();
            Hide();
            fManageLichLamViec.ShowDialog();
            Show();
        }

        private void quảnLýChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChucVu fChucVu = new fChucVu();
            Hide();
            fChucVu.ShowDialog();
            Show();
        }

        private void fSoDo_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhanQuyen();
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel)
                != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThuePhong_Click(object sender, EventArgs e)
        {
            fThuePhong fThuePhong = new fThuePhong();
            Hide();
            fThuePhong.ShowDialog();
            Show();
            
        }

        private void QLTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQLTaiKhoan f = new fQLTaiKhoan();
            Hide();
            f.ShowDialog();
            Show();
        }
    }
}
