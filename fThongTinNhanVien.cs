using KS.DAO;
using KS.DTO;
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
    public partial class fThongTinNhanVien : Form
    {
        private NhanVienDAO nhanVienDAO = null;
        public fThongTinNhanVien()
        {
            InitializeComponent();
            nhanVienDAO = new NhanVienDAO();
        }

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            var ma = fLogin.MaNhanVien;
            var nhanVien = nhanVienDAO.GetNhanVien(ma);
            lbMaNhanVien.Text = ma.ToString();
            lbTenNhanVien.Text = nhanVien.TENNHANVIEN;
            lbNgaySinh.Text = nhanVien.NGAYSINH != null ? DateTime.Parse(nhanVien.NGAYSINH.ToString()).ToShortDateString():"";
            lbDiaChi.Text = nhanVien.DIACHI;
            lbSoDt.Text = nhanVien.SODIENTHOAI;
            lbGioiTinh.Text = nhanVien.GIOITINH;
            lbChucVu.Text = nhanVien.MACHUCVU.ToString();
        }
    }
}
