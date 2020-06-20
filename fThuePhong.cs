using KS.DAO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KS
{
    public partial class fThuePhong : Form
    {
        fPhong f = new fPhong();
        QLKSEntities2 db = null;
        public fThuePhong()
        {
            InitializeComponent();
            db = new QLKSEntities2();
        }
        bool checkDatPhongHopLe()
        {
            if (txbTenkh.Text == "") lbtenkh.Visible = true;
            else lbtenkh.Visible = false;
            if (txbGioiTinh.Text == "") lbgioitinh.Visible = true;
            else lbgioitinh.Visible = false;
            if (txbDiaChi.Text == "") lbdiachi.Visible = true;
            else lbdiachi.Visible = false;
            if (txbSDT.Text == "") lbSDT.Visible = true;
            else lbSDT.Visible = false;
            if (txbCMT.Text == "") lbCMT.Visible = true;
            else lbCMT.Visible = false;
            if (cbbChonLoaiPhg.Text == "") lbChonLoaiPhong.Visible = true;
            else lbChonLoaiPhong.Visible = false;
            if (cbbChonPhg.Text == "") lbChonPhong.Visible = true;
            else lbChonPhong.Visible = false;
            if (txbTenkh.Text != "" && txbGioiTinh.Text != "" && txbDiaChi.Text != "" && txbSDT.Text != "" && txbCMT.Text != "") return true;
            return false;
        }

        void CapNhatDanhSachPhongCoNguoiThue()
        {
            PhongDAO phongDAO = new PhongDAO();
            var listPhong = phongDAO.GetPhongNotDeleted();
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            foreach (var phg in listPhong)
            {
                var thuePhong = thuePhongDAO.GetListThuePhong(phg.MAPHONG);
                Phong editPhong = db.Phongs.Find(phg.MAPHONG);
                if (thuePhong.Count != 0)
                {
                    editPhong.TINHTRANGPHONG = "Đang cho thuê";
                    db.SaveChanges();
                }
                else
                {
                    editPhong.TINHTRANGPHONG = "Trống";
                    db.SaveChanges();
                }
            }
        }

        bool checkThoiGianDatPhongCoTrungDatPhongKo(ThuePhong thuePhong)
        {
            DatPhongDAO datPhongDAO = new DatPhongDAO();
            var datPhg = datPhongDAO.GetDatPhong();
            foreach (var phg in datPhg)
            {
                if (phg.MAPHONG == thuePhong.MAPHONG && phg.isLate !="Late")
                {
                    if ((thuePhong.NGAYO.Value.Date >= phg.NGAYO.Value.Date && thuePhong.NGAYO.Value.Date <= phg.NGAYDI.Value.Date) || (thuePhong.NGAYDI.Value.Date >= phg.NGAYO.Value.Date && thuePhong.NGAYDI.Value.Date <= phg.NGAYDI.Value.Date) ||
                        (thuePhong.NGAYO.Value.Date <= phg.NGAYO.Value.Date && thuePhong.NGAYDI.Value.Date <= phg.NGAYDI.Value.Date &&
                        thuePhong.NGAYDI.Value.Date >= phg.NGAYDI.Value.Date ||
                        thuePhong.NGAYO.Value.Date <= phg.NGAYO.Value.Date && thuePhong.NGAYDI.Value.Date >= phg.NGAYDI.Value.Date
                        )
                        )
                    {
                        MessageBox.Show("Thời Gian này trùng đơn đặt phòng khác!!");
                        return false;
                    }
                }
            }
            return true;
        }

        bool checkThoiGianDatPhongHopLe(ThuePhong thuePhong, int kind)
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(cbbChonPhg.Text);
            var thuePhg = thuePhongDAO.GetThuePhong();
            if (dtPKerNgayVao.Value.Date > dtPKerNgayRa.Value.Date)
            {
                MessageBox.Show("Không được ngày ở > ngày đi");
                return false;
            }

            foreach (var phg in thuePhg)
            {
                if (kind == 1)
                {
                    if (phg.MAPHONG == phong.MAPHONG)
                    {
                        if ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))
                        {
                            MessageBox.Show("Không được trùng thời gian với đơn đặt/thuê cùng phòng");
                            return false;
                        }
                        if (dtPKerNgayVao.Value.Date < DateTime.Today || dtPKerNgayRa.Value.Date < DateTime.Today)
                        {
                            MessageBox.Show("Không được đặt/thuê thời gian trong quá khứ");
                            return false;
                        }
                    }
                }
                if (kind == 2)
                {
                    if (phg.MAPHONG == phong.MAPHONG)
                    {
                        if (phg.MATHUEPHONG == thuePhong.MATHUEPHONG && ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))) continue;
                        if ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))
                            return false;
                    }
                }
            }
            return true;
        }

        void loadLoaiPhong()
        {
            LoaiPhongDAO loaiPhongDAO = new LoaiPhongDAO();
            var lstLoaiPhong = loaiPhongDAO.GetLoaiPhong();
            cbbChonLoaiPhg.DataSource = lstLoaiPhong;
            cbbChonLoaiPhg.DisplayMember = "TenLoaiPhong";
        }

        void RefreshForm()
        {
            CapNhatDanhSachPhongCoNguoiThue();
            loadLoaiPhong();
            loadThongTinPhongDangChon();
            loadDanhSachDatCuaPhong();
        }

        void editDatPhong()
        {
            if (dtgvThongTinPhg.RowCount == 0)
            {
                MessageBox.Show("Bạn chưa chọn đơn thuê phòng!!");
                return;
            }
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(cbbChonPhg.Text);
            int id = int.Parse(dtgvThongTinPhg.SelectedCells[1].OwningRow.Cells["MTP"].Value.ToString());
            ThuePhong thuePhong = db.ThuePhongs.Find(id);
            thuePhong.MAPHONG = phong.MAPHONG;
            thuePhong.NGAYO = dtPKerNgayVao.Value.Date;
            thuePhong.NGAYDI = dtPKerNgayRa.Value.Date;
            thuePhong.GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text);
            //thuePhong.TRATRUOC = Convert.ToDouble(txbTraTruoc.Text);
            if (checkThoiGianDatPhongHopLe(thuePhong, 2) == true)
            {
                if (checkThoiGianDatPhongCoTrungDatPhongKo(thuePhong) == true)
                {
                    //if (MessageBox.Show("Bạn có thật sự muốn Sửa thuê phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    //{
                        db.SaveChanges();
                        loadThongTinPhongDangChon();
                        MessageBox.Show("Sửa thành công");
                    //}
                }
            }
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
            dtgvThongTinPhg.Columns.Add(buttonXoa);
        }

        void loadDanhSachPhong()
        {
            var result = from c in db.Phongs
                         from a in db.LoaiPhongs
                         where c.MALOAIPHONG == a.MALOAIPHONG
                         && c.isDelete == false
                         && a.TENLOAIPHONG == cbbChonLoaiPhg.Text
                         select new
                         {
                             c.TENPHONG,
                             c.TINHTRANGPHONG,
                             a.TENLOAIPHONG,
                             c.GIAPHONG,
                         };
            dtgvDSPhg.DataSource = result.ToList();
        }//ok
        void loadThongTinPhongDat()
        {
            PhongDAO phongDAO = new PhongDAO();
            var result = (from a in db.Phongs
                          from b in db.LoaiPhongs
                          where a.MALOAIPHONG == b.MALOAIPHONG
                          && b.TENLOAIPHONG == cbbChonLoaiPhg.Text
                          && a.isDelete == false
                          select new
                          {
                              tenPhong = a.TENPHONG.ToString(),
                              giaPhong = a.GIAPHONG
                          }).ToList();
            var lstPhong = phongDAO.GetPhongNotDeleted();
            if (result.Count > 0)
            {
                foreach (var value in result)
                {
                    cbbChonPhg.Items.Add(value.tenPhong);
                }
                cbbChonPhg.Text = result[0].tenPhong;
            }
        }
        void loadDanhSachDatCuaPhong()
        {
            int stt = 1;
            var result = (from a in db.Phongs
                          from b in db.DatPhongs
                          from c in db.KhachHangs
                          where a.MAPHONG == b.MAPHONG && b.MAKH == c.MAKH 
                          &&cbbChonPhg.Text == a.TENPHONG.ToString()
                          && b.isDelete == false
                          && b.isUse == false
                          select new RowDatPhong
                          {
                              STT = stt,
                              MaDatPhong = b.MADATPHONG,
                              TenPhong = a.TENPHONG,
                              TenKhachHang = c.TENKH,
                              SoDienThoai = c.SODIENTHOAI,
                              GiaPhong = a.GIAPHONG,
                              NgayO = b.NGAYO,
                              NgayDi = b.NGAYDI,
                              TinhTrang = b.isLate,
                          }).ToList();
            foreach (var item in result)
            {
                item.STT = stt;
                stt++;
            }
            //capNhatDatPhongCoLateKo();
            ngayO.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayDi.DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvThongTinPhongDat.DataSource = result;
        }
        
        void loadThongTinPhongDangChon()
        {
            var result = (from a in db.Phongs
                          from b in db.ThuePhongs
                          from c in db.KhachHangs
                          where a.MAPHONG == b.MAPHONG && b.MAKH == c.MAKH &&
                          cbbChonPhg.Text == a.TENPHONG.ToString()
                          && b.isDelete == false
                          select new RowThuePhong
                          {
                              MaThuePhong = b.MATHUEPHONG,
                              TenPhong = a.TENPHONG,
                              TenKhachHang = c.TENKH,
                              SoDienThoai = c.SODIENTHOAI,
                              GiaPhong = b.GiaPhongHienTai,
                              NgayO = b.NGAYO,
                              NgayDi = b.NGAYDI,
                          }).ToList();
            int stt = 1;
            foreach (var item in result)
            {
                item.STT = stt;
                stt++;
            }
            ngayO.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayDi.DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvThongTinPhg.DataSource = result;
            loadDanhSachDatCuaPhong();
        }
        void loadGiaPhong()
        {
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(cbbChonPhg.Text);
            var tongNgayo = (dtPKerNgayRa.Value.Date - dtPKerNgayVao.Value.Date).TotalDays;
            if (tongNgayo < 0) MessageBox.Show("Chọn ngày ở <ngày đi");
            else
            {
                if (tongNgayo == 0) tongNgayo = 0.5;
                txbgiaPhong.Text = (phong.GIAPHONG * tongNgayo).ToString();
                txbTraTruoc.Text = (phong.GIAPHONG * tongNgayo * 0.2).ToString();
            }
        }
        private void fThuePhong_Load(object sender, EventArgs e)
        {
            loadThongTinPhongDat();
            loadDanhSachPhong();
            //loadDanhSachDatCuaPhong();
            loadThongTinPhongDangChon();
            RefreshForm();
            if (fLogin.maChucVu == 4 || fLogin.maChucVu == 5)
            {
                CreateButtonDelete();
            }
            dtPKerNgayVao.MinDate = DateTime.Today;
            dtPKerNgayRa.MinDate = DateTime.Today;
        }

        private void btnThuePhg_Click(object sender, EventArgs e)
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            var datPhg = thuePhongDAO.GetThuePhong();
            KhachHang khachHang = new KhachHang()
            {
                TENKH = txbTenkh.Text,
                GIOITINH = txbGioiTinh.Text,
                NGAYSINH = datimeNgaySinh.Value.Date,
                DIACHI = txbDiaChi.Text,
                SODIENTHOAI = txbSDT.Text,
                CHUNGMINHTHU = txbCMT.Text
            };
            if (checkDatPhongHopLe() == true)
            {
                PhongDAO phongDAO = new PhongDAO();
                var phong = phongDAO.GetPhong(cbbChonPhg.Text);
                KhachHangDAO khachHangDAO = new KhachHangDAO();
                var kh = khachHangDAO.GetKhachHang(txbCMT.Text);
                ThuePhong thuePhong;
                thuePhong = new ThuePhong()
                {
                    MAPHONG = phong.MAPHONG,
                    //MAKH = null,
                    //TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                    NGAYO = dtPKerNgayVao.Value.Date,
                    NGAYDI = dtPKerNgayRa.Value.Date,
                    //TrangThaiThanhToan = "",
                    //GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                    isDelete = false
                };

                if (checkThoiGianDatPhongHopLe(thuePhong, 1) == true)
                {
                    if (checkThoiGianDatPhongCoTrungDatPhongKo(thuePhong) == true)
                    {
                        if (MessageBox.Show("Bạn có thật sự muốn thuê phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (khachHangDAO.isKhachHangHopLe(khachHang) == false)//ko hop le
                            {
                                MessageBox.Show("CMT hoặc SĐT tồn tại");
                                return;
                            }
                            if (khachHangDAO.isKhachHangTonTai(khachHang) == false)//ko ton tai
                            {
                                db.KhachHangs.Add(khachHang);
                                db.SaveChanges();
                                thuePhong = new ThuePhong()
                                {
                                    MAPHONG = phong.MAPHONG,
                                    MAKH = khachHang.MAKH,
                                    TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                                    NGAYO = dtPKerNgayVao.Value.Date,
                                    NGAYDI = dtPKerNgayRa.Value.Date,
                                    TrangThaiThanhToan = "Chưa thanh toán",
                                    GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                                    isDelete = false
                                };
                                db.ThuePhongs.Add(thuePhong);
                                db.SaveChanges();
                            }
                            else
                            {
                                thuePhong = new ThuePhong()
                                {
                                    MAPHONG = phong.MAPHONG,
                                    MAKH = kh.MAKH,
                                    TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                                    NGAYO = dtPKerNgayVao.Value.Date,
                                    NGAYDI = dtPKerNgayRa.Value.Date,
                                    TrangThaiThanhToan = "Chưa thanh toán",
                                    GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                                    isDelete = false
                                };
                                db.ThuePhongs.Add(thuePhong);
                                db.SaveChanges();
                            }

                            MessageBox.Show("Thuê phòng thành công", "Thông báo");
                            RefreshForm();
                            loadThongTinPhongDangChon();
                        }
                    }
                }
            }
        }

        private void txbSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var result = (from c in db.KhachHangs
                              where c.SODIENTHOAI == txbSDT.Text
                              select new
                              {
                                  MaKH = c.MAKH,
                                  TenKH = c.TENKH,
                                  GioiTinh = c.GIOITINH,
                                  NgaySinh = c.NGAYSINH,
                                  DiaChi = c.DIACHI,
                                  SDT = c.SODIENTHOAI,
                                  CMT = c.CHUNGMINHTHU
                              }).ToList();
                if (result.Count != 0)
                {
                    txbTenkh.Text = result.SingleOrDefault().TenKH;
                    txbCMT.Text = result.SingleOrDefault().CMT;
                    txbDiaChi.Text = result.SingleOrDefault().DiaChi;
                    txbGioiTinh.Text = result.SingleOrDefault().GioiTinh;
                    datimeNgaySinh.Value = result.SingleOrDefault().NgaySinh.Value;
                }
                else
                {
                    MessageBox.Show("Khách hàng chưa đăng kí thông tin");
                }
            }
        }

        private void cbbChonLoaiPhg_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbChonPhg.Items.Clear();
            loadThongTinPhongDat();
        }

        private void cbbChonPhg_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGiaPhong();
            dtgvThongTinPhg.DataBindings.Clear();
            loadThongTinPhongDangChon();
            loadDanhSachDatCuaPhong();
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        void XoaDichVuCuaThuePhong(int maDP)
        {
            DatDichVuDAO datDichVu = new DatDichVuDAO();
            var dv = datDichVu.GetListDatDichVu(maDP);
            foreach (var datdichvu in dv)
            {
                var xoaDatDichVu = db.DatDichVus.Find(datdichvu.Id);
                db.DatDichVus.Remove(xoaDatDichVu);
            }
        }
        private void dtgvThongTinPhg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn có thật sự muốn hủy thuê phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedThuePhong = db.ThuePhongs.Find(((RowThuePhong)dtgvThongTinPhg.CurrentRow.DataBoundItem).MaThuePhong);
                    //db.DatDichVus.RemoveRange(selectedThuePhong.);
                    //db.ThuePhongs.Remove(selectedThuePhong);
                    XoaDichVuCuaThuePhong(selectedThuePhong.MATHUEPHONG);
                    selectedThuePhong.isDelete = true;
                    db.SaveChanges();
                    MessageBox.Show("Hủy thành công");
                    RefreshForm();
                }
            }
            
        }

        private void dtPKerNgayVao_ValueChanged(object sender, EventArgs e)
        {
            loadGiaPhong();
        }

        private void dtPKerNgayRa_ValueChanged(object sender, EventArgs e)
        {
            loadGiaPhong();
        }

        private void btnSuaDatPhong_Click(object sender, EventArgs e)
        {
            editDatPhong();
        }

        private void cbbChonLoaiPhg_TextChanged(object sender, EventArgs e)
        {
            loadDanhSachPhong();
        }
    }
}
