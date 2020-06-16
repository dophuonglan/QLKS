using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS
{
    public partial class fThanhToan : Form
    {
        fPhong f = new fPhong();
        QLKSEntities2 db = null;
        private static string maDatp;

        public static string MaDatp { get => maDatp; set => maDatp = value; }

        public fThanhToan()
        {
            InitializeComponent();
            db = new QLKSEntities2();
        }

        double? tinhTongTienDichVu(int maDatPhong)
        {
            DatDichVuDAO datDichVuDAO = new DatDichVuDAO();
            double? gia = 0;
            var lsDatDichVu = datDichVuDAO.GetListDatDichVu(maDatPhong);
            foreach (var datDichVu in lsDatDichVu)
            {
                gia += datDichVu.giaDichVuHienTai;
            }
            return gia;
        }
        private void fThanhToan_Load(object sender, EventArgs e)
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            List<ThuePhong> lstThuePhong = null;
            if (fSoDo.IsClick == true)
            {
                lstThuePhong = thuePhongDAO.GetThuePhong();
                if (lstThuePhong.Count == 0)
                {
                    MessageBox.Show("Hiện không có phòng thuê");
                    this.Close();
                }
                else
                {
                    loadThongTin(lstThuePhong[0].MATHUEPHONG);
                    fSoDo.IsClick = false;
                }
            }
            else
            {
                lstThuePhong = thuePhongDAO.GetListThuePhong(fPhong.MaPtag);
                if (lstThuePhong.Count() == 0)
                {
                    MessageBox.Show("Hiện không có phòng thuê");
                    this.Close();
                }
                else
                loadThongTin(lstThuePhong[0].MATHUEPHONG);
            }
            foreach (var dp in lstThuePhong)
            {
                var btn = new Button() { Width = 60, Height = 60};
                float fontSize = 9;
                Font f = new Font("Microsoft Sans Serif", fontSize, FontStyle.Bold);
                btn.Font = f;
                btn.BackColor = Color.LightBlue;
                flowDanhSachDP.Controls.Add(btn);
                btn.Tag = dp;
                btn.Text = dp.MATHUEPHONG.ToString();
                var kh = khachHangDAO.GetKhachHang(dp.MAKH);
                toolTip1.SetToolTip(btn, "Phòng: " + dp.MAPHONG + "\n" + "Tên KH :" + kh.TENKH + "\n" + "Ngày Ở: " + dp.NGAYO.Value.ToShortDateString());
                btn.Click += btn_Click;
            }
        }
        double? tinhTongTienPhong(ThuePhong thuePhong)
        {
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(Convert.ToInt32(thuePhong.MAPHONG));
            double soNgay = (dtpkNgayDi.Value.Date - dtpkNgayO.Value.Date).TotalDays;
            if(soNgay == 0)
            {
                soNgay = 1;
            }
            double? tienPhong = phong.GIAPHONG * soNgay;
            return tienPhong;
        }

        void loadThongTin(int maThuePhong)
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            var thuePhong = thuePhongDAO.GetThuePhong(maThuePhong);
            var khachHang = khachHangDAO.GetKhachHang(thuePhong.MAKH);


            lbMaThuePhong.Text = thuePhong.MATHUEPHONG.ToString();
            MaDatp = lbMaThuePhong.Text;
            labMaPhong.Text = thuePhong.MAPHONG.ToString();
            lbMaKH.Text = thuePhong.MAKH.ToString();
            lbHoTen.Text = khachHang.TENKH;
            lbGioiTinh.Text = khachHang.GIOITINH;
            dtpkNgaySinh.Value = khachHang.NGAYSINH.Value.Date;
            lbDiaChi.Text = khachHang.DIACHI;
            lbCMND.Text = khachHang.CHUNGMINHTHU;
            lbSDT.Text = khachHang.SODIENTHOAI;

            var lstDatPhong = thuePhongDAO.GetListThuePhong(fPhong.MaPtag);
            dtpkNgayDi.MinDate = thuePhong.NGAYO.Value.Date;
            var thongTinPhongDat = (from a in db.Phongs
                                    from b in db.LoaiPhongs
                                    where a.MAPHONG == thuePhong.MAPHONG
                                    && a.MALOAIPHONG ==b.MALOAIPHONG
                                    select new ThongTinThanhToanPhong
                                    {
                                        TENPHONG = a.TENPHONG,
                                        TINHTRANGPHONG = a.TINHTRANGPHONG,
                                        MALOAIPHONG = a.MALOAIPHONG,
                                        TenLoaiPhong = b.TENLOAIPHONG,
                                        GIAPHONG = a.GIAPHONG,
                                        MOTA = a.MOTA
                                    }).ToList();
            LoaiPhongDAO loaiPhongDAO = new LoaiPhongDAO();
            foreach (var item in thongTinPhongDat)
            {
                var loaiPhong = loaiPhongDAO.GetLoaiPhong(item.MALOAIPHONG);
                item.TenLoaiPhong = loaiPhong.TENLOAIPHONG;
                
            }
            dtgvThongTinPhongThanhToan.DataSource = thongTinPhongDat;
            var thongTinDichVuDat = (from a in db.DatDichVus
                                     from b in db.DichVus
                                     where a.MATHUEPHONG == thuePhong.MATHUEPHONG
                                     && b.MADV ==a.MADV
                                     select new ThongTinThanhToanDichVu
                                     {
                                         TenDichVu = b.TENDV,
                                         SoLuong = a.SoLuong,
                                         ngayDung = a.ngayDung,
                                         giaDichVuHienTai = a.giaDichVuHienTai,
                                     }).ToList();
            dtgvThongTinDichVuThanhToan.DataSource = thongTinDichVuDat;
            double? tienDV = 0;
            int i = 1;
            foreach (var datDV in thongTinDichVuDat)
            {
                datDV.STT = i;
                i++;
                tienDV += datDV.giaDichVuHienTai;
            }
            lbTienDV.Text = tienDV.ToString();
            dtpkNgayO.Value = thuePhong.NGAYO.Value.Date;
            dtpkNgayDi.Value = thuePhong.NGAYDI.Value.Date;

            var tienPhong = tinhTongTienPhong(db.ThuePhongs.Find(thuePhong.MATHUEPHONG));
            lbTienPhg.Text = tienPhong.ToString();
            lbTienDV.Text = tienDV.ToString();
            var TongTien = tienDV + tienPhong;
            lbTongTien.Text = TongTien.ToString();
            dtpkNgayThanhToan.Value = DateTime.Today;
            
        }
        private void btn_Click(object sender, EventArgs e)
        {
            var dp = ((sender as Button).Tag as ThuePhong).MATHUEPHONG;
            loadThongTin(dp);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DatDichVuDAO datDichVuDAO = new DatDichVuDAO();
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            if (txbTienMat.Text == "") lbThongBao.Visible = true;
            if (txbTienMat.Text != "" && Convert.ToDouble(txbTienMat.Text) >= Convert.ToDouble(lbTongTien.Text))
            {
                lbThongBao.Visible = false;
                var thuePhong = thuePhongDAO.GetThuePhong(Convert.ToInt32(lbMaThuePhong.Text));
                var lsdatDichVu = datDichVuDAO.GetListDatDichVu(thuePhong.MATHUEPHONG);
                HoaDon hoaDon = new HoaDon()
                {
                    NGAYTHANHTOAN = DateTime.Today,
                    MAKH = thuePhong.MAKH,
                    TIENPHONG = Convert.ToInt32(lbTienPhg.Text),
                    MANHANVIEN = fLogin.MaNhanVien,
                    TIENDV = tinhTongTienDichVu(thuePhong.MATHUEPHONG),
                };
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                foreach (var ddv in lsdatDichVu)
                {
                    var a = db.DatDichVus.Find(ddv.Id);
                    a.isDelete = true;
                }
                db.SaveChanges();

                var dp = db.ThuePhongs.Find(thuePhong.MATHUEPHONG);
                dp.isDelete = true;
                db.SaveChanges();

                int ma = hoaDon.MAHD;
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon()
                {
                    MAHD = ma,
                    MATHUEPHONG = thuePhong.MATHUEPHONG,
                    GHICHU = ""
                };
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();

                MessageBox.Show("Thành công");
                this.Close();
            }
            else MessageBox.Show("Không hợp lệ");

        }


        private void txbTienMat_KeyUp(object sender, KeyEventArgs e)
        {
            if (txbTienMat.Text == "") lbThongBao.Visible = true;
            else if (e.KeyCode == Keys.Enter)
            {
                lbThongBao.Visible = false;

                var tien = Convert.ToDouble(txbTienMat.Text) - Convert.ToDouble(lbTongTien.Text);
                if (tien < 0) lbThongBao2.Visible = true;
                else
                {
                    lbThongBao2.Visible = false;
                    lbTienThua.Text = tien.ToString();
                }
            }
        }

        private void txbTienMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dtpkNgayDi_ValueChanged(object sender, EventArgs e)
        {
            PhongDAO phongDAO = new PhongDAO();
            double soNgayThue = 0;
            var phong = phongDAO.GetPhong(Convert.ToInt32(labMaPhong.Text));
            if (dtpkNgayDi.Value.Date == dtpkNgayO.Value.Date)
            {
                soNgayThue = 1;
            }
            else soNgayThue = (dtpkNgayDi.Value.Date - dtpkNgayO.Value.Date).TotalDays;
            lbTienPhg.Text = (soNgayThue * phong.GIAPHONG).ToString();
            //    fPrintChiTietHoaDon.NgayDi = dtpkNgayDi.Value.Date;
        }

        private void fThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.loadSoDoPhong();
        }

        private void txbTienMat_TextChanged(object sender, EventArgs e)
        {
            if (txbTienMat.Text == "") lbThongBao.Visible = true;
            else
            {
                lbThongBao.Visible = false;
                if (double.Parse(txbTienMat.Text) >= double.Parse(lbTongTien.Text))
                {
                    lbThongBao2.Visible = false;
                    lbTienThua.Text = (double.Parse(txbTienMat.Text) - double.Parse(lbTongTien.Text)).ToString();
                }
                else
                {
                    lbThongBao2.Visible = true;
                    lbTienThua.Text = "0";
                }
            }

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpkNgayDi.Value = DateTime.Today;
        }
        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = panel1.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btnInHoaDon_Click_1(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_1);
        }

        private void dtgvThongTinPhongThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbTienPhg_TextChanged(object sender, EventArgs e)
        {
            var TongTien = float.Parse(lbTienDV.Text) + float.Parse(lbTienPhg.Text);
            lbTongTien.Text = TongTien.ToString();
        }
    }
}

