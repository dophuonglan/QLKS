using KS.DAO;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KS
{
    public partial class fQLTaiKhoan : Form
    {
        QLKSEntities2 db = null;
        public fQLTaiKhoan()
        {
            db = new QLKSEntities2();
            InitializeComponent();
        }
        void loadTaiKhoan()
        {
            var result = (from a in db.TaiKhoans
                          select new RowTenDangNhap
                          {
                              TenDangNhap = a.TENTAIKHOAN,
                              TrangThai = a.isBan == true ? "Đang chặn" : "Không bị chặn",
                          }).ToList();
            dtgvThongTinTaiKhoan.DataSource = result;
        }

        private void fThemTaiKhoan_Load(object sender, EventArgs e)
        {
            loadTaiKhoan();
        }


        public static string GetRandomString()
        {
            var allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var length = 6;

            var chars = new char[length];
            var rd = new Random();

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void btnLayChonMK_Click(object sender, EventArgs e)
        {
            txbMatKhau.Text = GetRandomString();
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

        bool checkHopLe()
        {
            if (txbMNV.Text == "") lbThongBaoMaNV.Visible = true;
            else lbThongBaoMaNV.Visible = false;
            if (txbTenDangNhap.Text == "") lbThongBaoTenDN.Visible = true;
            else lbThongBaoTenDN.Visible = false;
            if (txbMatKhau.Text == "") lbThongBaoMatKhau.Visible = true;
            else lbThongBaoMatKhau.Visible = false;
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            if (txbMNV.Text == "" || txbTenDangNhap.Text == "" || txbMatKhau.Text == "")
            {
                return false;
            }
            if (nhanVienDAO.GetNhanVien(Convert.ToInt32(txbMNV.Text)) == null)
            {
                MessageBox.Show("Không tồn tại nhân viên");
                return false;
            }
            if (taiKhoanDAO.GetTaiKhoan(txbTenDangNhap.Text) != null)
            {
                MessageBox.Show("Tài khoản tồn tại");
            }
            return true;
        }
        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (checkHopLe() == true)
            {
                NhanVienDAO nhanVienDAO = new NhanVienDAO();
                var nhanVien = nhanVienDAO.GetNhanVien(Convert.ToInt32(txbMNV.Text));
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TENTAIKHOAN = txbTenDangNhap.Text;
                taiKhoan.PASS = maHoaPass(txbMatKhau.Text);
                taiKhoan.MANHANVIEN = nhanVien.MANHANVIEN;
                taiKhoan.MACHUCVU = nhanVien.MACHUCVU;
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
            }
        }

        private void btnChanTaiKhoan_Click(object sender, EventArgs e)
        {
            var selectedTaiKhoan = db.TaiKhoans.Find(((RowTenDangNhap)dtgvThongTinTaiKhoan.CurrentRow.DataBoundItem).TenDangNhap);
            if(selectedTaiKhoan.isBan == true)
            {
                MessageBox.Show("Đối tượng này đã chặn rồi!");
                return;
            }
            if (fLogin.MaNhanVien == selectedTaiKhoan.MANHANVIEN)
            {
                MessageBox.Show("Không thể chặn bản thân");
                return;
            }
            if (selectedTaiKhoan.MACHUCVU == 5)
            {
                MessageBox.Show("Không thể chặn đối tượng này");
                return;
            }
            if (MessageBox.Show($"Bạn có thật sự muốn chặn tài khoản {selectedTaiKhoan.TENTAIKHOAN} này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                selectedTaiKhoan.isBan = true;
                db.SaveChanges();
                MessageBox.Show("Chặn thành công!");
                loadTaiKhoan();
            }
        }

        private void btnGoChan_Click(object sender, EventArgs e)
        {
            var selectedTaiKhoan = db.TaiKhoans.Find(((RowTenDangNhap)dtgvThongTinTaiKhoan.CurrentRow.DataBoundItem).TenDangNhap);
            if (selectedTaiKhoan.isBan == false)
            {
                MessageBox.Show("Đối tượng này không bị chặn!");
                return;
            }
            if (MessageBox.Show($"Gỡ chặn tài khoản {selectedTaiKhoan.TENTAIKHOAN} này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                selectedTaiKhoan.isBan = false;
                db.SaveChanges();
                MessageBox.Show("Thành công!");
                loadTaiKhoan();
            }
        }

        bool checkValueResetHopLe()
        {
            if (txbTenDangNhapCanReset.Text == "") lbThongBaoTDNReset.Visible = true;
            else lbThongBaoTDNReset.Visible = false;
            if (txbresetPass.Text == "") lbThongBaoPassReset.Visible = true;
            else lbThongBaoPassReset.Visible = false;
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            if (txbTenDangNhapCanReset.Text == "" || txbresetPass.Text == "")
            {
                return false;
            }
            if (taiKhoanDAO.GetTaiKhoan(txbTenDangNhapCanReset.Text) == null)
            {
                MessageBox.Show($"Không tồn tại mã nhân viên {txbTenDangNhapCanReset.Text}");
                return false;
            }
            
            return true;
        }

        private void btnResetMK_Click_1(object sender, EventArgs e)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            var tk = taiKhoanDAO.GetTaiKhoan(txbTenDangNhapCanReset.Text);
            if (checkValueResetHopLe() == true)
            {
                var a= db.TaiKhoans.Find(txbTenDangNhapCanReset.Text);
                a.PASS = maHoaPass(txbresetPass.Text);
                db.SaveChanges();
                MessageBox.Show($"Reset thành công, mật khẩu là {txbresetPass.Text}");
            }
        }

        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            txbresetPass.Text= GetRandomString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var result = (from a in db.TaiKhoans
                          where a.TENTAIKHOAN.Contains(textBox4.Text)
                          select new RowTenDangNhap
                          {
                              TenDangNhap = a.TENTAIKHOAN,
                              TrangThai = a.isBan == true ? "Đang chặn" : "Không bị chặn",
                          }).ToList();
            dtgvThongTinTaiKhoan.DataSource = result;
        }
    }
}
