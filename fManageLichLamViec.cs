using KS.Common;
using KS.DAO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KS
{
    public partial class fManageLichLamViec : Form
    {
        QLKSEntities2 db = null;
        public fManageLichLamViec()
        {
            db = new QLKSEntities2();
            InitializeComponent();
        }
        //void ClearBindingSuaLichLam()
        //{
        //    cbbMaNhanVienLich.DataBindings.Clear();
        //    cbbBuoiLich.DataBindings.Clear();
        //    dtpkLichLamLich.DataBindings.Clear();
        //    txbTenNhanVienLich.DataBindings.Clear();
        //}
        //void AddBindingSuaLichLam()
        //{
        //    if (dtgvLichLamViec.DataSource != null)
        //    {
        //        cbbMaNhanVienLich.DataBindings.Add(new Binding("Text", dtgvLichLamViec.DataSource, "manhanvien"));
        //        txbTenNhanVienLich.DataBindings.Add(new Binding("Text", dtgvLichLamViec.DataSource, "tennhanvien"));
        //        cbbBuoiLich.DataBindings.Add(new Binding("Text", dtgvLichLamViec.DataSource, "buoi"));
        //        dtpkLichLamLich.DataBindings.Add(new Binding("Text", dtgvLichLamViec.DataSource, "ngaylamviec"));
        //    }
        //}

        void loadCbbMaNhanVien()
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            var listNV = nhanVienDAO.GetListNhanVien();
            cbbMaNhanVienLich.DataSource = listNV;
            cbbMaNhanVienLich.DisplayMember = "MANHANVIEN";
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
            dtgvLichLamViec.Columns.Add(buttonXoa);
        }
        bool checkHopLe()
        {
            if (cbbMaNhanVienLich.Text == "") lbThongBaoMA.Visible = true;
            else lbThongBaoMA.Visible = false;
            if (cbbBuoiLich.Text == "") lbThongBaoBuoi.Visible = true;
            else lbThongBaoBuoi.Visible = false;
            if (cbbMaNhanVienLich.Text != "" && cbbBuoiLich.Text != "") return true;
            return false;
        }
        void loadLichLamViec()
        {
            var result = (from c in db.LichLamViecs
                          from a in db.NhanViens
                          where c.NGAYLAMVIEC >= dtpkNgaybatDau.Value.Date && c.NGAYLAMVIEC <= dtpkNgayKetThuc.Value.Date
                          && a.MANHANVIEN == c.MANHANVIEN
                          select new RowLichLamViec
                          {
                              MaLichLamViec = c.MALICHLAMVIEC,
                              MaNhanVien = c.MANHANVIEN,
                              TenNhanVien = a.TENNHANVIEN,
                              NgayLamViec = c.NGAYLAMVIEC,
                              Buoi = c.BUOI
                          }).ToList();
            dtgvLichLamViec.DataSource = result;
        }

        void refreshForm()
        {
            loadLichLamViec();
            loadCbbMaNhanVien();
            //ClearBindingSuaLichLam();
            //AddBindingSuaLichLam();
        }
        private void fManageLichLamViec_Load(object sender, EventArgs e)
        {
            refreshForm();
            CreateButtonDelete();
        }

        private void dtpkNgaybatDau_ValueChanged(object sender, EventArgs e)
        {
            loadLichLamViec();
            txbTimKiem_TextChanged(sender, e);
        }

        private void dtpkNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            loadLichLamViec();
            txbTimKiem_TextChanged(sender, e);
        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            var result = (from c in db.LichLamViecs
                          from a in db.NhanViens
                          where c.NGAYLAMVIEC >= dtpkNgaybatDau.Value.Date && c.NGAYLAMVIEC <= dtpkNgayKetThuc.Value.Date
                          &&
                          a.MANHANVIEN == c.MANHANVIEN &&
                          (a.TENNHANVIEN.Contains(txbTimKiem.Text) || a.MANHANVIEN.ToString().Contains(txbTimKiem.Text))
                          select new RowLichLamViec
                          {
                              MaLichLamViec = c.MALICHLAMVIEC,
                              MaNhanVien = c.MANHANVIEN,
                              TenNhanVien = a.TENNHANVIEN,
                              NgayLamViec = c.NGAYLAMVIEC,
                              Buoi = c.BUOI
                          }).ToList();
            dtgvLichLamViec.DataSource = result;
        }

        private void dtgvLichLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa lịch làm việc này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedLichLamViec = db.LichLamViecs.Find(((RowLichLamViec)dtgvLichLamViec.CurrentRow.DataBoundItem).MaLichLamViec);
                    db.LichLamViecs.Remove(selectedLichLamViec);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    txbTimKiem_TextChanged(sender, e);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LichLamViecDAO lichLamViecDAO = new LichLamViecDAO();
            if (checkHopLe() == true)
            {
                if (db.NhanViens.Find(int.Parse(cbbMaNhanVienLich.Text)) == null)
                {
                    MessageBox.Show("Không tồn tại nhân viên có mã trên");
                    return;
                }

                NhanVienDAO nhanVienDAO = new NhanVienDAO();
                var nhanVien = nhanVienDAO.GetNhanVien(int.Parse(cbbMaNhanVienLich.Text));
                LichLamViec lichLamViecMoi = new LichLamViec();
                lichLamViecMoi.MANHANVIEN = nhanVien.MANHANVIEN;
                lichLamViecMoi.NGAYLAMVIEC = dtpkLichLamLich.Value.Date;
                lichLamViecMoi.BUOI = cbbBuoiLich.Text;
                if (lichLamViecDAO.checkExistLichLam(lichLamViecMoi, 1) == false)
                {
                    MessageBox.Show("Lịch tồn tại");
                    return;
                }
                db.LichLamViecs.Add(lichLamViecMoi);
                db.SaveChanges();
                MessageBox.Show("Thành công");
                loadLichLamViec();
            }
            else MessageBox.Show("Dữ liệu nhập không hợp lệ");
        }

        private void cbbMaNhanVienLich_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cbbMaNhanVienLich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LichLamViecDAO lichLamViecDAO = new LichLamViecDAO();
            if (checkHopLe() == true) //check ko tong
            {
                if (db.NhanViens.Find(int.Parse(cbbMaNhanVienLich.Text)) == null)
                {
                    MessageBox.Show("Không tồn tại nhân viên có mã trên");
                    return;
                }
                int id = int.Parse(dtgvLichLamViec.SelectedCells[0].OwningRow.Cells["malichlamviec"].Value.ToString());
                LichLamViec lichLamViec = db.LichLamViecs.Find(id);
                lichLamViec.NGAYLAMVIEC = dtpkLichLamLich.Value.Date;
                lichLamViec.BUOI = cbbBuoiLich.Text;
                if (lichLamViecDAO.checkExistLichLam(lichLamViec, 2) == false)
                {
                    MessageBox.Show("Lịch tồn tại");
                    return;
                }
                db.SaveChanges();
                MessageBox.Show("Thành công");
            }
            else
                MessageBox.Show("Dữ liệu nhập không hợp lệ");
        }

        private void dtgvLichLamViec_SelectionChanged(object sender, EventArgs e)
        {
            //if (dtgvLichLamViec.DataSource != null)
            //{
            //        cbbMaNhanVienLich.Text = dtgvLichLamViec.SelectedRows[0].Cells["MANHANVIEN"].Value.ToString();
            //        txbTenNhanVienLich.Text = dtgvLichLamViec.SelectedRows[0].Cells["TENNHANVIEN"].Value.ToString();
            //        dtpkLichLamLich.Value = DateTime.Parse(dtgvLichLamViec.SelectedRows[0].Cells["NGAYLAMVIEC"].Value.ToString());
            //        cbbBuoiLich.Text = dtgvLichLamViec.SelectedRows[0].Cells["BUOI"].Value.ToString();
            //}
        }

        private void dtgvLichLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLichLamViec.Rows[e.RowIndex];
                cbbMaNhanVienLich.Text = row.Cells["maNhanVien"].Value.ToString();
                txbTenNhanVienLich.Text = row.Cells["tenNhanVien"].Value.ToString();
                dtpkLichLamLich.Value = DateTime.Parse(row.Cells["ngayLamViec"].Value.ToString());
                cbbBuoiLich.Text = row.Cells["buoi"].Value.ToString();
            }
        }
        private void cbbMaNhanVienLich_SelectedValueChanged(object sender, EventArgs e)
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            if (cbbMaNhanVienLich.Text != null)
            {
                var nhanVien = nhanVienDAO.GetNhanVien(int.Parse(cbbMaNhanVienLich.Text));
                if (nhanVien != null)
                {
                    txbTenNhanVienLich.Text = nhanVien.TENNHANVIEN;
                    lbTbMaNVKhongTonTai.Visible = true;
                }
                lbTbMaNVKhongTonTai.Visible = false;
            }
            else lbThongBaoMA.Visible = true;
        }

        private void cbbMaNhanVienLich_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
