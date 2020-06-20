using KS.Common;
using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS
{
    public partial class fDichVu : Form
    {
        QLKSEntities2 db = null;
        public fDichVu()
        {
            InitializeComponent();
            db = new QLKSEntities2();
        }

        void phanQuyen()
        {
            if ((fLogin.maChucVu == 4) || fLogin.maChucVu == 5)
            {
                panelAdmin1.Enabled = true;
                panelAdmin2.Enabled = true;
            }
            else
            {
                panelAdmin1.Enabled = false;
                panelAdmin2.Enabled = false;
            }
        }
        void tinhTienDichVu()
        {
            DichVu dichVuSelected = (DichVu)cbbTenDichVu.SelectedItem;
            txbTienDV.Text = (Convert.ToInt32(numSoLuong.Value) * dichVuSelected.GIADV).ToString();
        }

        void loadThongTinDatDichVu()
        {
            var result = (from c in db.DatDichVus
                          from a in db.DichVus
                          where c.MADV == a.MADV
                          && c.MATHUEPHONG.ToString() == cbbMaTP.Text
                          select new RowDichVu
                          {
                              STT=1,
                              Id = c.Id,
                              MaDatPhong = c.MATHUEPHONG,
                              MaDV = c.MADV,
                              TenDV = a.TENDV,
                              SoLuong = c.SoLuong,
                              NgayDung = c.ngayDung,
                              GiaDV = a.GIADV,
                              Gia = c.giaDichVuHienTai,
                          }).ToList();
            ngayDung.DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvThongTinDatDichVu.DataSource = result;
            double tongTien = 0;
            int i = 1;
            foreach (var item in result)
            {
                item.STT = i;
                i++;
                tongTien += item.Gia.Value;
            }
            lbTongTienDichVu.Text = tongTien + " VNĐ";
        }
        void loadDichVu()
        {
            DichVuDAO dichVuDAO = new DichVuDAO();
            var lstDichVu = dichVuDAO.GetDichVu();
            cbbTenDichVu.DataSource = lstDichVu;
            cbbTenDichVu.DisplayMember = "TENDV";
            cbbTenDV_Sua.DataSource = lstDichVu;
            cbbTenDV_Sua.DisplayMember = "TENDV";
        }
        void loadThuePhong()
        {
            var result = (from a in db.ThuePhongs
                          from b in db.Phongs
                          from c in db.KhachHangs
                          where a.MAPHONG == b.MAPHONG
                          && a.MAKH == c.MAKH
                           && a.isDelete == false
                          && b.TENPHONG == cbbChonPhong.Text
                          select new SelectThuePhong
                          {
                              MaThuePhong = a.MATHUEPHONG,
                              TenPhong = b.TENPHONG,
                              NgayO = a.NGAYO,
                              NgayDi = a.NGAYDI,
                              TenKhachHang = c.TENKH,
                              NgaySinh = c.NGAYSINH,
                              SoDienThoai = c.SODIENTHOAI,
                          }).ToList();
            cbbMaTP.DataSource = result;
            cbbMaTP.DisplayMember = "maThuePhong";
        }

        void loadCacBox()
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            loadThuePhong();

            var lstThuephg = thuePhongDAO.GetThuePhong();
            if (lstThuephg.Count != 0)
            {
                cbbMaTP.Text = lstThuephg[0].MATHUEPHONG.ToString();
                var thuePhg = thuePhongDAO.GetThuePhong(Convert.ToInt32(cbbMaTP.Text));
                dtpkNgayDi.Value = thuePhg.NGAYDI.Value;
                dtpkNgayO.Value = thuePhg.NGAYO.Value;
            }
        }
        void loadTenDV_CapNhatDV()
        {
            DichVu dichVuSelected = (DichVu)cbbTenDV_Sua.SelectedItem;
            txbDonGia_Sua.Text = dichVuSelected.GIADV.ToString();
        }

        DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
        private void CreateButtonDelete()
        {
            buttonXoa.Name = "ButtonXoa";
            buttonXoa.HeaderText = "Hủy";
            buttonXoa.Text = "X";
            buttonXoa.DefaultCellStyle.Padding = new Padding(2);
            buttonXoa.UseColumnTextForButtonValue = true; //dont forget this line
            buttonXoa.FlatStyle = FlatStyle.Popup;
            buttonXoa.DefaultCellStyle.BackColor = Color.Red;
            this.dtgvThongTinDatDichVu.Columns.Add(buttonXoa);
        }

        void loadTenPhongThuePhong()
        {
            var result = (from a in db.ThuePhongs
                         from b in db.Phongs
                         from c in db.KhachHangs
                         where a.MAPHONG == b.MAPHONG
                         && a.MAKH == c.MAKH
                         && a.isDelete == false
                         select new SelectThuePhong
                         {
                             MaThuePhong = a.MATHUEPHONG,
                             TenPhong = b.TENPHONG,
                             NgayO= a.NGAYO,
                             NgayDi=a.NGAYDI,
                             TenKhachHang = c.TENKH,
                             NgaySinh = c.NGAYSINH,
                             SoDienThoai = c.SODIENTHOAI,
                         }).ToList();
            cbbChonPhong.DataSource = result;
            cbbChonPhong.DisplayMember = "TENPHONG";
        }
        private void fDichVu_Load(object sender, EventArgs e)
        {
            phanQuyen();
            loadTenPhongThuePhong();
            dtpkNgayDung.Value = DateTime.Today;
            loadDichVu();
            loadCacBox();
            loadThongTinDatDichVu();
            CreateButtonDelete();
        }

        private void cbbMaDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            SelectThuePhong TPSelected = (SelectThuePhong)cbbMaTP.SelectedItem;
            var thuePhong = thuePhongDAO.GetThuePhong(TPSelected.MaThuePhong);
            dtpkNgayDi.Value = thuePhong.NGAYDI.Value;
            dtpkNgayO.Value = thuePhong.NGAYO.Value;
            //txbTenKH.Text = TPSelected.TenKhachHang;
            //txbSDTKH.Text = TPSelected.SoDienThoai;
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            var kh = khachHangDAO.GetKhachHang(thuePhong.MAKH);
            txbTenKH.Text = kh.TENKH;
            txbSDTKH.Text = kh.SODIENTHOAI;
            dtgvThongTinDatDichVu.DataBindings.Clear();
            loadThongTinDatDichVu();
        }

        private void cbbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhTienDichVu();
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            tinhTienDichVu();
        }

        private void refreshForm()
        {
            loadDichVu();
            loadCacBox();
            loadThongTinDatDichVu();
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (txbThemTenDV.Text == "") lbThongBaoTenDV.Visible = true;
            else lbThongBaoTenDV.Visible = false;
            if (txbThemDonGia.Text == "") lbThongBaoGiaDV.Visible = true;
            else lbThongBaoGiaDV.Visible = false;
            if (txbThemTenDV.Text != "" && txbThemDonGia.Text != "")
            {
                if (!IsNumber(txbThemDonGia.Text) || (double.Parse(txbThemDonGia.Text) < 0))
                {
                    MessageBox.Show("Không hợp lệ");
                }
                else if (db.DichVus.SingleOrDefault(x => x.TENDV == txbThemTenDV.Text && x.isDelete ==false) != null)
                {
                    MessageBox.Show("Dịch vụ đã tồn tại");
                    return;
                }
                else
                {
                    DichVu dichVuMoi = new DichVu();
                    dichVuMoi.TENDV = txbThemTenDV.Text;
                    dichVuMoi.GIADV = Convert.ToDouble(txbThemDonGia.Text);
                    dichVuMoi.isDelete = false;
                    db.DichVus.Add(dichVuMoi);
                    db.SaveChanges();
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                    refreshForm();
                }
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (txbDonGia_Sua.Text != "")
            {
                if (!IsNumber(txbDonGia_Sua.Text) || (int.Parse(txbDonGia_Sua.Text) < 0))
                {
                    MessageBox.Show("Không hợp lệ");
                }
                else
                {
                    DichVuDAO dichVuDAO = new DichVuDAO();
                    var DV = dichVuDAO.GetDichVu(cbbTenDichVu.Text);
                    DichVu dichVu = db.DichVus.SingleOrDefault(x => x.MADV == DV.MADV);
                    dichVu.GIADV = Convert.ToDouble(txbDonGia_Sua.Text);
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    refreshForm();

                }

            }
        }

        private void cbbTenDV_Sua_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTenDV_CapNhatDV();
        }


        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa dịch vụ này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DichVu dichVuSelected = (DichVu)cbbTenDV_Sua.SelectedItem;
                //db.DichVus.Remove(db.DichVus.Single(x => x.MADV == dichVuSelected.MADV));
                var dv = db.DichVus.Single(x => x.MADV == dichVuSelected.MADV);
                dv.isDelete = true;
                db.SaveChanges();
                refreshForm();
                MessageBox.Show("Xóa dịch vụ " + dichVuSelected.TENDV + " thành công!");
            }
        }

        private void dtgvThongTinDatDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DatDichVuDAO datDichVuDAO = new DatDichVuDAO();
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var selectedDatDV = ((RowDichVu)dtgvThongTinDatDichVu.CurrentRow.DataBoundItem);
                if (MessageBox.Show("Bạn có chắc chắm muốn hủy không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    datDichVuDAO.Remove(selectedDatDV.Id);
                    MessageBox.Show("Hủy thành công", "Thông báo");
                    loadThongTinDatDichVu();
                }
            }
        }

        private bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private void txbThemDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txbThemDonGia.Text == "")
            {
                lbThongBaoGiaDV.Visible = true;
                lbThongBao2.Visible = false;
            }
            else if (!IsNumber(txbThemDonGia.Text))
            {
                lbThongBaoGiaDV.Visible = false;
                lbThongBao2.Visible = true;
            }
            else
            {
                lbThongBaoGiaDV.Visible = false;
                lbThongBao2.Visible = false;
            }
        }

        private void txbDonGia_Sua_TextChanged(object sender, EventArgs e)
        {
            if (txbDonGia_Sua.Text == "")
            {
                lbSuaGiaDV.Visible = true;
                lbThongBaoSua2.Visible = false;
            }
            else if (!IsNumber(txbDonGia_Sua.Text))
            {
                lbSuaGiaDV.Visible = false;
                lbThongBaoSua2.Visible = true;
            }
            else
            {
                lbSuaGiaDV.Visible = false;
                lbThongBaoSua2.Visible = false;
            }
        }

        private void cbbChonPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            loadThuePhong();
        }

        private void btnDatDV_Click_1(object sender, EventArgs e)
        {
            DichVuDAO dichVuDAO = new DichVuDAO();
            var lstDichVu = dichVuDAO.GetDichVu();

            if (numSoLuong.Value == 0)
            {
                lbThongBaoChonSoLg.Visible = true;
            }
            else
            {
                lbThongBaoChonSoLg.Visible = false;
                var dichVu = dichVuDAO.GetDichVu(cbbTenDichVu.Text);//lay dichvu co ten xac dinh
                int ma = dichVu.MADV;// madv đang dc dat
                DatDichVu datDV = null;
                int slgThem = Convert.ToInt32(numSoLuong.Value);
                double giaThem = Convert.ToDouble(txbTienDV.Text);
                foreach (var datdv in db.DatDichVus.ToList())
                {
                    if (datdv.MATHUEPHONG.ToString() == cbbMaTP.Text && datdv.MADV == ma && datdv.ngayDung.Date == dtpkNgayDung.Value.Date)
                    {
                        if (MessageBox.Show("Thêm dịch vụ này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            datdv.SoLuong = slgThem + datdv.SoLuong;
                            datdv.giaDichVuHienTai = datdv.giaDichVuHienTai + giaThem;
                            MessageBox.Show("Thêm thành công!");
                            db.SaveChanges();
                            loadThongTinDatDichVu();
                            return;
                        }
                    }
                    continue;
                }
                if (MessageBox.Show("Thêm dịch vụ này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    datDV = new DatDichVu();
                    datDV.MATHUEPHONG = Convert.ToInt32(cbbMaTP.Text);
                    datDV.SoLuong = Convert.ToInt32(numSoLuong.Value);
                    datDV.ngayDung = dtpkNgayDung.Value;
                    datDV.giaDichVuHienTai = Convert.ToDouble(txbTienDV.Text);
                    datDV.MADV = dichVu.MADV;
                    datDV.isDelete = false;
                    db.DatDichVus.Add(datDV);
                    db.SaveChanges();
                    MessageBox.Show("Đặt thành công!");
                }
                loadThongTinDatDichVu();
            }
        }

        //private void cbbMaDP_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}
