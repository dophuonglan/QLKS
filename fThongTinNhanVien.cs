using KS.Common;
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
    public partial class fThongTinNhanVien : Form
    {
        QLKSEntities2 db = null;
        public fThongTinNhanVien()
        {
            InitializeComponent();
            db = new QLKSEntities2();
        }

        void refreshForm()
        {
            loadCbbChucVu();
            loadThongTinNhanVien();
        }

        void loadCbbChucVu()
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var listChucVu = chucVuDAO.GetChucVuTruQuanLy();
            cbbChucVu.DataSource = listChucVu;
            cbbChucVu.DisplayMember = "TENCHUCVU";
        }

        void loadCbbChucVuAll()
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var listChucVu = chucVuDAO.GetChucVu();
            cbbChucVu.DataSource = listChucVu;
            cbbChucVu.DisplayMember = "TENCHUCVU";
        }

        private void CreateButtonDelete()
        {
            DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
            buttonXoa.Name = "ButtonXoa";
            buttonXoa.HeaderText = "";
            buttonXoa.Text = "X";
            buttonXoa.DefaultCellStyle.Padding = new Padding(2);
            buttonXoa.UseColumnTextForButtonValue = true; //dont forget this line
            buttonXoa.FlatStyle = FlatStyle.Popup;
            buttonXoa.DefaultCellStyle.BackColor = Color.Red;
            dtgvThongTInNhanVien.Columns.Add(buttonXoa);
        }
        void loadThongTinNhanVien()
        {
            var result = (from c in db.NhanViens
                          from a in db.ChucVus
                          where c.MACHUCVU == a.MACHUCVU
                          && c.isDelete == false
                          select new RowNhanVien
                          {
                              MaNhanVien = c.MANHANVIEN,
                              TenNhanVien = c.TENNHANVIEN,
                              GioiTinh = c.GIOITINH,
                              NgaySinh = c.NGAYSINH.Value,
                              DiaChi = c.DIACHI,
                              TenChucVu = a.TENCHUCVU,
                              SoDienThoai = c.SODIENTHOAI
                          }).ToList();
            dtgvThongTInNhanVien.DataSource = result;
            dtgvThongTInNhanVien.Columns[0].ReadOnly = true;
        }
        private void fThongTinKH_Load(object sender, EventArgs e)
        {
            refreshForm();
            CreateButtonDelete();
        }

        private void txbTimKiemNhanVien_TextChanged(object sender, EventArgs e)
        {
            var result = (from c in db.NhanViens
                          from a in db.ChucVus
                          where (c.MACHUCVU == a.MACHUCVU
                          && c.TENNHANVIEN.Contains(txbTimKiemNhanVien.Text) && c.isDelete == false) || (c.MACHUCVU == a.MACHUCVU
                          && c.MANHANVIEN.ToString().Contains(txbTimKiemNhanVien.Text) && c.isDelete == false)
                          select new
                          {
                              c.MANHANVIEN,
                              c.TENNHANVIEN,
                              c.GIOITINH,
                              c.NGAYSINH,
                              c.DIACHI,
                              a.TENCHUCVU,
                              c.SODIENTHOAI
                          }).ToList();
            dtgvThongTInNhanVien.DataSource = result;
        }

        public bool CheckNullString()
        {
            if (txbTenNhanVien.Text == "") lbThongBaoHoTen.Visible = true;
            else lbThongBaoHoTen.Visible = false;
            if (txbSDT.Text == "") lbThongBaoSDT.Visible = true;
            else lbThongBaoHoTen.Visible = false;
            if (txbDiaChi.Text == "") lbThongBaoDiaChi.Visible = true;
            else lbThongBaoDiaChi.Visible = false;
            if (txbTenNhanVien.Text == "" || txbSDT.Text == "" || txbDiaChi.Text == "") return false;
            return true;
        }
        public bool CheckExistSDT(NhanVien nv, int kind)
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            var lnhanVien = nhanVienDAO.GetListNhanVien();
            if (kind == 1)
            {
                foreach (var nhanVien in lnhanVien)
                {
                    if (nv.SODIENTHOAI == nhanVien.SODIENTHOAI) return false;
                }
            }
            if (kind == 2)
            {
                foreach (var nhanVien in lnhanVien)
                {
                    if (nv.SODIENTHOAI == nhanVien.SODIENTHOAI && nv.MANHANVIEN == nhanVien.MANHANVIEN) continue;
                    if (nv.SODIENTHOAI == nhanVien.SODIENTHOAI) return false;
                }
            }
            return true;
        }
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            if (CheckNullString() == true)
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.TENNHANVIEN = txbTenNhanVien.Text;
                nhanVien.NGAYSINH = dtpkNgaySinh.Value.Date;
                nhanVien.SODIENTHOAI = txbSDT.Text;
                if (CheckExistSDT(nhanVien, 1) == false)
                {
                    MessageBox.Show("SDT tồn tại");
                    return;
                }
                nhanVien.DIACHI = txbDiaChi.Text;
                nhanVien.GIOITINH = cbbGioiTinh.Text;
                ChucVuDAO chucVuDAO = new ChucVuDAO();
                var chucVu = chucVuDAO.GetChucVuTheoTen(cbbChucVu.Text);
                nhanVien.MACHUCVU = chucVu.MACHUCVU;
                nhanVien.isDelete = false;
                db.NhanViens.Add(nhanVien);
                if (MessageBox.Show("Bạn có thật sự muốn thêm Nhân Viên này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    db.SaveChanges();
                    refreshForm();
                    MessageBox.Show("Thêm nhân viên thành công");
                }
            }
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        void phanQuyen(NhanVien nhanVien)
        {
            
        }
        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            if (CheckNullString() == true)
            {
                int id = int.Parse(dtgvThongTInNhanVien.SelectedCells[0].OwningRow.Cells["maNhanVien"].Value.ToString());
                NhanVien nhanVien = db.NhanViens.Find(id);
                
                nhanVien.TENNHANVIEN = txbTenNhanVien.Text;
                nhanVien.NGAYSINH = dtpkNgaySinh.Value.Date;
                nhanVien.SODIENTHOAI = txbSDT.Text;
                if (CheckExistSDT(nhanVien, 2) == false)
                {
                    MessageBox.Show("SDT Tồn tại");
                    return;
                }
                if (fLogin.maChucVu == 4)
                {
                    if (nhanVien.MACHUCVU == 4 || nhanVien.MACHUCVU==5)
                    {
                        MessageBox.Show("Bạn không thể thay đổi chức vụ của nhân viên này");
                        return;
                    }
                }
                if (nhanVien.MACHUCVU == 5)
                {
                    MessageBox.Show("Không thể thay đổi chức vụ nhân viên này");
                    return;
                }
                nhanVien.DIACHI = txbDiaChi.Text;
                nhanVien.GIOITINH = cbbGioiTinh.Text;
                ChucVuDAO chucVuDAO = new ChucVuDAO();
                var chucVu = chucVuDAO.GetChucVuTheoTen(cbbChucVu.Text);
                nhanVien.MACHUCVU = chucVu.MACHUCVU;
                TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                if (MessageBox.Show("Sửa thông tin nhân Viên MSNV " + nhanVien.MANHANVIEN + " với thông tin này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    taiKhoanDAO.CapNhatTKCuaNhanVien(nhanVien);
                    db.SaveChanges();
                    MessageBox.Show("Sửa thông tin nhân viên thành công");
                    refreshForm();
                }
            }
        }

        bool KiemTraNhanVien(NhanVien nhanVien)
        {
            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            var lstHoaDon = hoaDonDAO.GetHoaDon();
            foreach (var hoaDon in lstHoaDon)
            {
                if (nhanVien.MANHANVIEN == hoaDon.MANHANVIEN)
                {
                    return true;
                }
            }
            return false;
        }
        private void dtgvThongTInNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var selectedNhanVien = db.NhanViens.Find(((RowNhanVien)dtgvThongTInNhanVien.CurrentRow.DataBoundItem).MaNhanVien);
                if (selectedNhanVien.MACHUCVU == 4 || selectedNhanVien.MACHUCVU == 5)
                {
                    MessageBox.Show("Không thể xóa quản trị");
                    return;
                }
                else if (MessageBox.Show("Bạn có thật sự muốn xóa Nhân Viên này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (KiemTraNhanVien(selectedNhanVien) == true)
                    {
                        db.NhanViens.Remove(selectedNhanVien);
                    }
                    else selectedNhanVien.isDelete = true;
                    db.SaveChanges();
                    MessageBox.Show("remove success");
                    refreshForm();
                }
            }
        }

        private void dtgvThongTInNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvThongTInNhanVien.Rows[e.RowIndex];
                ChucVuDAO chucVuDAO = new ChucVuDAO();
                var chucVu = chucVuDAO.GetChucVuTheoTen(cbbChucVu.Text = row.Cells["chucVu"].Value.ToString());
                if (chucVu.MACHUCVU == 5)
                {
                    loadCbbChucVuAll();
                }
                txbTenNhanVien.Text = row.Cells["TENNHANVIEN"].Value.ToString();
                cbbGioiTinh.Text = row.Cells["GIOITINH"].Value.ToString();
                dtpkNgaySinh.Value = DateTime.Parse(row.Cells["NGAYSINH"].Value.ToString());
                txbDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                cbbChucVu.Text = row.Cells["chucVu"].Value.ToString();
                txbSDT.Text = row.Cells["sdt"].Value.ToString();
            }
        }
    }
}
