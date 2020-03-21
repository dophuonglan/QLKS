
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

        private void fSoDo_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.Sizable;
            //WindowState = FormWindowState.Maximized;
            //TopMost = true;
            
        }

        private void viewAllPhg_Click(object sender, EventArgs e)
        {
            fPhong phong = new fPhong();
            this.Hide();
            phong.ShowDialog();
            this.Show();
        }

        private void btnLichLamViec_Click(object sender, EventArgs e)
        {
            fLichLamViec lichlam = new fLichLamViec();
            this.Hide();
            lichlam.ShowDialog();
            this.Show();
        }

        private void btnThongTinNhanVien_Click(object sender, EventArgs e)
        {
            fThongTinNhanVien thongTinNhanVien = new fThongTinNhanVien();
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
            var lstDatPhong = datPhongDAO.GetDatPhong();
            if (lstDatPhong.Count == 0)
            {
                fThanhToan thanhToan = new fThanhToan();
                IsClick = true;
                Hide();
                thanhToan.ShowDialog();
                Show();
            }
            else MessageBox.Show("Hiện không có phòng cần thanh toán");
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKe fThongKe = new fThongKe();
            Hide();
            fThongKe.ShowDialog();
            Show();
        }
    }
}
