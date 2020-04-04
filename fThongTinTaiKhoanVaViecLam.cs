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
    public partial class fThongTinTaiKhoanVaViecLam : Form
    {
        private QLKSEntities2 db = null;
        private NhanVienDAO nhanVienDAO = null;
        public fThongTinTaiKhoanVaViecLam()
        {
            InitializeComponent();
            nhanVienDAO = new NhanVienDAO();
            db = new QLKSEntities2();
        }

        void loadLichLamViec()
        {
            var result = (from c in db.LichLamViecs
                          from a in db.NhanViens
                          where c.NGAYLAMVIEC >= dtpkNgayBatDau.Value.Date && c.NGAYLAMVIEC <= dtpkNgayKetThuc.Value.Date
                          && a.MANHANVIEN == c.MANHANVIEN
                          select new
                          {
                              c.MANHANVIEN,
                              a.TENNHANVIEN,
                              c.NGAYLAMVIEC,
                              c.BUOI
                          }).ToList();
            dtgvLichLamViec.DataSource = result;
        }

        void loadCbbChucVu()
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var listChucVu = chucVuDAO.GetChucVu();
            cbbChucVu.DataSource = listChucVu;
            cbbChucVu.DisplayMember = "TENCHUCVU";
            cbbGioiTinh.Text = "Nam";
        }

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            loadCbbChucVu();
            var ma = fLogin.MaNhanVien;
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var nhanVien = nhanVienDAO.GetNhanVien(ma);
            lbMaNhanVien.Text = ma.ToString();
            txbTen.Text = nhanVien.TENNHANVIEN;
            dtpkNgaySinh.Value = nhanVien.NGAYSINH.Value.Date;
            txbDiaChi.Text = nhanVien.DIACHI;
            txbSoDienThoai.Text = nhanVien.SODIENTHOAI;
            cbbGioiTinh.Text = nhanVien.GIOITINH;
            var chucVu = chucVuDAO.GetChucVuTheoMa(nhanVien.MACHUCVU);
            cbbChucVu.Text = chucVu.TENCHUCVU.ToString();
            loadLichLamViec();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            var nhanVien = db.NhanViens.Find(int.Parse(lbMaNhanVien.Text));
            if (btnSuaThongTin.Text == "Sửa Thông Tin")
            {
                btnSuaThongTin.Text = "Cập Nhật";
                txbTen.Enabled = true;
                dtpkNgaySinh.Enabled = true;
                txbDiaChi.Enabled = true;
                txbSoDienThoai.Enabled = true;
                cbbGioiTinh.Enabled = true;
                txbCheckPass.Visible = true;
                return;
            }
            if (btnSuaThongTin.Text == "Cập Nhật")
            {
                nhanVien.TENNHANVIEN = txbTen.Text;
                nhanVien.NGAYSINH = dtpkNgaySinh.Value.Date;
                nhanVien.DIACHI = txbDiaChi.Text;
                nhanVien.SODIENTHOAI = txbSoDienThoai.Text;
                nhanVien.GIOITINH = cbbGioiTinh.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa thông tin thành công");
            }
        }

        private void txbSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            var result = (from c in db.LichLamViecs
                          from a in db.NhanViens
                          where c.NGAYLAMVIEC >= dtpkNgayBatDau.Value.Date && c.NGAYLAMVIEC <= dtpkNgayKetThuc.Value.Date
                          && a.MANHANVIEN == c.MANHANVIEN &&
                            (a.TENNHANVIEN.Contains(txbTimKiem.Text) || a.MANHANVIEN.ToString().Contains(txbTimKiem.Text))
                          select new
                          {
                              c.MANHANVIEN,
                              a.TENNHANVIEN,
                              c.NGAYLAMVIEC,
                              c.BUOI
                          }).ToList();
            dtgvLichLamViec.DataSource = result;
        }

        private void dtpkNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            loadLichLamViec();
            txbTimKiem_TextChanged(sender, e);
        }

        private void dtpkNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            loadLichLamViec();
            txbTimKiem_TextChanged(sender, e);
        }
    }
}
