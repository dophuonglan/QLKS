using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
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
            lbChucVu.Text = chucVu.TENCHUCVU.ToString();
            loadLichLamViec();
        }

        string maHoaPass(string pass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (var item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }

        bool checkPass(TaiKhoan taiKhoan)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            var tk = taiKhoanDAO.GetTaiKhoan(fLogin.tenDN);
            if (tk.PASS == taiKhoan.PASS)
            {
                return true;
            }
            return false;
        }

        bool checkPass1(TaiKhoan taiKhoan)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            var tk = taiKhoanDAO.GetTaiKhoan(fLogin.tenDN);
            if (tk.PASS == taiKhoan.PASS)
            {//////
                return true;
            }
            return false;
        }
        bool checkHopLeSuaThongTin()
        {
            if (txbTen.Text == "") lbThongBaoHoTen.Visible = true;
            else lbThongBaoHoTen.Visible = false;
            if (txbSoDienThoai.Text == "") lbThongBaoSDT.Visible = true;
            else lbThongBaoSDT.Visible = false;
            if (txbDiaChi.Text == "") lbThongBaoDiaChi.Visible = true;
            else lbThongBaoDiaChi.Visible = false;
            if (txbTen.Text != "" && txbDiaChi.Text != "" && txbSoDienThoai.Text != "") return true;
            return false;
            
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
                lbxacnhanmk.Visible = true;
                return;
            }
            if (btnSuaThongTin.Text == "Cập Nhật")
            {
                if (checkHopLeSuaThongTin() == true)
                {
                    if (txbCheckPass.Text != "")
                    {
                        TaiKhoan taiKhoan = new TaiKhoan();
                        taiKhoan.PASS = maHoaPass(txbCheckPass.Text);
                        if (checkPass1(taiKhoan) == true)
                        {
                            lbthongbao.Visible = false;
                            nhanVien.TENNHANVIEN = txbTen.Text;
                            nhanVien.NGAYSINH = dtpkNgaySinh.Value.Date;
                            nhanVien.DIACHI = txbDiaChi.Text;
                            nhanVien.SODIENTHOAI = txbSoDienThoai.Text;
                            nhanVien.GIOITINH = cbbGioiTinh.Text;
                            db.SaveChanges();
                            MessageBox.Show("Sửa thông tin thành công");
                        }
                        else lbthongbao.Visible = true;
                    }
                    else lbthongbao.Visible = true;
                }
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

        bool checkHopLeDoiMatKhau()
        {
            if (txbMatKhauCu.Text == "") lbThongBao2.Visible = true;
            else lbthongbao.Visible = false;
            if (txbMatKhauMoi.Text == "") lbThongBaoMatKhauMoi.Visible = true;
            else lbThongBaoMatKhauMoi.Visible = false;
            if (txbMatKhauCu.Text != "" && txbMatKhauMoi.Text != "") return true;
            return false;
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.PASS = maHoaPass(txbMatKhauCu.Text);
            
            if (checkHopLeDoiMatKhau()==true)
            {
                if (checkPass(taiKhoan) == true)
                {
                    lbThongBao2.Visible = false;
                    var tk = db.TaiKhoans.Find(fLogin.tenDN);
                    tk.PASS = maHoaPass(txbMatKhauMoi.Text);
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật mật khẩu thành công");
                }
            }
        }
    }
}
