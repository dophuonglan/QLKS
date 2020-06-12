using KS.Common;
using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS
{
    public partial class fDatPhong : Form
    {
        fPhong f = new fPhong();
        QLKSEntities2 db = null;
        public fDatPhong()
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
        bool checkThoiGianDatPhongCoTrungThuePhongKo(DatPhong datPhong)
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            var thuePhg = thuePhongDAO.GetThuePhong();
            foreach (var phg in thuePhg)
            {
                if (phg.MAPHONG == datPhong.MAPHONG)
                {
                    if ((datPhong.NGAYO.Value.Date >= phg.NGAYO.Value.Date && datPhong.NGAYO.Value.Date <= phg.NGAYDI.Value.Date) || (datPhong.NGAYDI.Value.Date >= phg.NGAYO.Value.Date && datPhong.NGAYDI.Value.Date <= phg.NGAYDI.Value.Date) ||
                       (datPhong.NGAYO.Value.Date <= phg.NGAYO.Value.Date && datPhong.NGAYDI.Value.Date <= phg.NGAYDI.Value.Date &&
                       datPhong.NGAYDI.Value.Date >= phg.NGAYDI.Value.Date ||
                       datPhong.NGAYO.Value.Date <= phg.NGAYO.Value.Date && datPhong.NGAYDI.Value.Date >= phg.NGAYDI.Value.Date
                       )
                       )
                    {
                        MessageBox.Show("Thời Gian này trùng đơn Thuê phòng khác!!");
                        return false;
                    }
                }
            }
            return true;
        }
        bool checkThoiGianDatPhongHopLe(DatPhong datPhong, int kind)
        {
            DatPhongDAO datPhongDAO = new DatPhongDAO();
            var datPhg = datPhongDAO.GetDatPhong();
            if (dtPKerNgayVao.Value.Date > dtPKerNgayRa.Value.Date)
            {
                MessageBox.Show("Không được ngày ở > ngày đi");
                return false;
            }
            //if ((dtPKerNgayVao.Value.Date - DateTime.Today.Date).TotalDays < 1)
            //{
            //    MessageBox.Show("Đặt trước tối thiểu 1 ngày");
            //    return false;
            //}
            PhongDAO phongDAO = new PhongDAO();
            var ph = phongDAO.GetPhong(cbbChonPhg.Text);
            foreach (var phg in datPhg)
            {
                if (kind == 1)
                {
                    if (phg.MAPHONG == ph.MAPHONG)
                    {
                        if ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))
                        {
                            MessageBox.Show("Không được trùng thời gian với đơn đặt cùng phòng");
                            return false;
                        }
                        if (dtPKerNgayVao.Value.Date < DateTime.Today || dtPKerNgayRa.Value.Date < DateTime.Today)
                        {
                            MessageBox.Show("Không được đặt thời gian trong quá khứ");
                            return false;
                        }
                    }
                }
                if (kind == 2)
                {
                    
;                    if (phg.MAPHONG == ph.MAPHONG)
                    {
                        if (phg.MADATPHONG == datPhong.MADATPHONG && ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))) continue;
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
            loadDanhSachDangChoThueCuaPhong();
            loadDanhSachPhong();
            
        }

        void editDatPhong()
        {
            if (dtgvThongTinPhg.RowCount == 0)
            {
                MessageBox.Show("Bạn chưa chọn đơn đặt phòng!!");
                return;
            }
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(cbbChonPhg.Text);
            int id = int.Parse(dtgvThongTinPhg.SelectedCells[3].OwningRow.Cells["maDatPhong"].Value.ToString());
            DatPhong datPhong = db.DatPhongs.Find(id);
            datPhong.MAPHONG = phong.MAPHONG;
            datPhong.NGAYO = dtPKerNgayVao.Value.Date;
            datPhong.NGAYDI = dtPKerNgayRa.Value.Date;
            datPhong.GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text);
            //datPhong.TRATRUOC = Convert.ToDouble(txbTraTruoc.Text);
            if (checkThoiGianDatPhongHopLe(datPhong, 2) == true)
            {
                if (checkThoiGianDatPhongCoTrungThuePhongKo(datPhong) == true)
                {
                    if (MessageBox.Show("Bạn có thật sự muốn Sửa đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        db.SaveChanges();
                        loadThongTinPhongDangChon();
                        MessageBox.Show("Sửa thành công");
                    }
                }
            }
        }
       
        void loadDanhSachDangChoThueCuaPhong()
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
            dtgvDanhSachDangThue.DataSource = result;
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
        void loadDanhSachPhong()
        {
            CapNhatDanhSachPhongCoNguoiThue();
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
            DataGridViewButtonColumn buttonXoa;
            buttonXoa = (DataGridViewButtonColumn)dtgvThongTinPhg.Columns["btnHuy"];
            buttonXoa.Text = "X";
            buttonXoa.DefaultCellStyle.Padding = new Padding(2);
            buttonXoa.UseColumnTextForButtonValue = true; //dont forget this line
            buttonXoa.FlatStyle = FlatStyle.Popup;
            buttonXoa.DefaultCellStyle.BackColor = Color.Red;
            DataGridViewButtonColumn buttonThue;
            buttonThue = (DataGridViewButtonColumn)dtgvThongTinPhg.Columns["btnThue"];
            buttonThue.Text = "✔";
            buttonThue.DefaultCellStyle.Padding = new Padding(2);
            buttonThue.UseColumnTextForButtonValue = true; //dont forget this line
            buttonThue.FlatStyle = FlatStyle.Popup;
            buttonThue.DefaultCellStyle.BackColor = Color.Green;
        }
        //void capNhatDatPhongCoLateKo()
        //{
        //    DatPhongDAO datPhongDAO = new DatPhongDAO();
        //    var dp = datPhongDAO.GetDatPhongCoDatPhongTre();
            
        //    foreach (var datphg in dp)
        //    {
        //        var capnhat = db.DatPhongs.Find(datphg.MADATPHONG);
        //        if ((DateTime.Today.Date - datphg.NGAYO.Value.Date).TotalDays  > 0)
        //        {
        //            capnhat.isLate = "Late";
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            capnhat.isLate = "Early";
        //            db.SaveChanges();
        //        }
        //    }
        //}
        void loadThongTinPhongDangChon()
        {
            int stt = 1;
            var result = (from a in db.Phongs
                           from b in db.DatPhongs
                           from c in db.KhachHangs
                           where a.MAPHONG == b.MAPHONG && b.MAKH == c.MAKH &&
                           cbbChonPhg.Text == a.TENPHONG.ToString()
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
            dtgvThongTinPhg.DataSource = result;
            //CreateButton();
        }
        void loadTraTruoc()
        {
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(cbbChonPhg.Text);

            var tongNgayo = (dtPKerNgayRa.Value.Date - dtPKerNgayVao.Value.Date).TotalDays;
            if (tongNgayo < 0) MessageBox.Show("Chọn ngày ở <ngày đi");
            else
            {
                if (tongNgayo == 0) tongNgayo = 0.5;
                txbgiaPhong.Text = (phong.GIAPHONG * tongNgayo).ToString();
                //txbTraTruoc.Text = "0";
            }
        }

        private void btnDatPhg_Click(object sender, EventArgs e)
        {
            DatPhongDAO datPhongDAO = new DatPhongDAO();
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            var datPhg = datPhongDAO.GetDatPhong();
            PhongDAO phongDAO = new PhongDAO();
            var phg= phongDAO.GetPhong(cbbChonPhg.Text);
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
                var kh = khachHangDAO.GetKhachHang(txbCMT.Text);
                DatPhong datPhong;
                datPhong = new DatPhong()
                {
                    MAPHONG = phg.MAPHONG,
                    NGAYO = dtPKerNgayVao.Value.Date,
                    NGAYDI = dtPKerNgayRa.Value.Date,
                    TrangThaiThanhToan = "Chưa thanh toán",
                    isDelete = false
                };

                if (checkThoiGianDatPhongHopLe(datPhong, 1) == true)
                {
                    if (checkThoiGianDatPhongCoTrungThuePhongKo(datPhong) == true)
                    {
                        if (MessageBox.Show("Bạn có thật sự muốn đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
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
                                datPhong = new DatPhong()
                                {
                                    MAPHONG = phg.MAPHONG,
                                    MAKH = khachHang.MAKH,
                                    //TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                                    NGAYO = dtPKerNgayVao.Value.Date,
                                    NGAYDI = dtPKerNgayRa.Value.Date,
                                    TrangThaiThanhToan = "Chưa thanh toán",
                                    GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                                    isUse = false,
                                    isDelete = false,
                                    isLate = "Early"
                                };
                                db.DatPhongs.Add(datPhong);
                                db.SaveChanges();
                            }
                            else
                            {
                                datPhong = new DatPhong()
                                {
                                    MAPHONG = phg.MAPHONG,
                                    MAKH = kh.MAKH,
                                    //TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                                    NGAYO = dtPKerNgayVao.Value.Date,
                                    NGAYDI = dtPKerNgayRa.Value.Date,
                                    TrangThaiThanhToan = "Chưa thanh toán",
                                    GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                                    isUse = false,
                                    isDelete = false,
                                    isLate = "Early"
                                };
                                db.DatPhongs.Add(datPhong);
                                db.SaveChanges();
                            }

                            MessageBox.Show("Đặt trước phòng thành công", "Thông báo");
                            RefreshForm();
                        }
                    }

                }
                //else MessageBox.Show("TG ko hop le");
            }
        }

        private void fAddNewKH_Load(object sender, EventArgs e)
        {
            loadThongTinPhongDat();
            loadDanhSachPhong();
            RefreshForm();
            dtPKerNgayVao.MinDate = DateTime.Today;
            dtPKerNgayRa.MinDate = DateTime.Today;
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
            loadTraTruoc();
            dtgvThongTinPhg.DataBindings.Clear();
            loadThongTinPhongDangChon();
            loadDanhSachDangChoThueCuaPhong();
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

        private void dtgvThongTinPhg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex ==0)
            {
                if (MessageBox.Show("Bạn có thật sự muốn hủy đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedDatPhong = db.DatPhongs.Find(((RowDatPhong)dtgvThongTinPhg.CurrentRow.DataBoundItem).MaDatPhong);
                    //db.DatDichVus.RemoveRange(selectedDatPhong.DatDichVus.ToList());
                    db.DatPhongs.Remove(selectedDatPhong);
                    db.SaveChanges();
                    MessageBox.Show("Hủy thành công");
                    loadThongTinPhongDangChon();
                }
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Chuyển Đặt Trước sáng Thuê Phòng?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedDatPhong = db.DatPhongs.Find(((RowDatPhong)dtgvThongTinPhg.CurrentRow.DataBoundItem).MaDatPhong);
                    ThuePhong tp = new ThuePhong()
                    {
                        MAPHONG = selectedDatPhong.MAPHONG,
                        MAKH = selectedDatPhong.MAKH,
                        TRATRUOC = selectedDatPhong.TRATRUOC,
                        NGAYO = selectedDatPhong.NGAYO,
                        NGAYDI = selectedDatPhong.NGAYDI,
                        TrangThaiThanhToan = selectedDatPhong.TrangThaiThanhToan,
                        GiaPhongHienTai = selectedDatPhong.GiaPhongHienTai,
                        isDelete = false
                    };
                    var update = db.DatPhongs.Find(selectedDatPhong.MADATPHONG);
                    update.isUse = true;
                    db.ThuePhongs.Add(tp);
                    db.SaveChanges();
                    MessageBox.Show("Thành công");
                }
            }
            RefreshForm();
        }

        private void dtPKerNgayRa_ValueChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
        }

        private void dtPKerNgayVao_ValueChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
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
