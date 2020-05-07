﻿using KS.DAO;
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
    public partial class fThanhToan : Form
    {
        fPhong f = new fPhong();
        QLKSEntities2 db = null;

        KhachHangDAO khachHangDAO = null;
        DatPhongDAO datPhongDAO = null;
        PhongDAO phongDAO = null;
        DatDichVuDAO datDichVuDAO = null;
        private static string maDatp;

        public static string MaDatp { get => maDatp; set => maDatp = value; }

        public fThanhToan()
        {
            InitializeComponent();
            db = new QLKSEntities2();
            khachHangDAO = new KhachHangDAO();
            datPhongDAO = new DatPhongDAO();
            phongDAO = new PhongDAO();
            datDichVuDAO = new DatDichVuDAO();
        }

        double? tinhTongTienDichVu(int maDatPhong)
        {
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
            DatPhongDAO datPhongDAO = new DatPhongDAO();
            List<DatPhong> lstDatPhong = null;
            //clik lấy ra mã phong đang click
            if (fSoDo.IsClick == true)
            {
                lstDatPhong = datPhongDAO.GetDatPhong();
                if (lstDatPhong.Count == 0)
                {
                    MessageBox.Show("Hiện không có đơn đăt phòng");
                    this.Close();
                }
                else
                {
                    loadThongTin(lstDatPhong[0].MADATPHONG);
                    fSoDo.IsClick = false;
                }
            }
            else
            {
                lstDatPhong = datPhongDAO.GetListDatPhong(fPhong.MaPtag);
                if (lstDatPhong.Count() == 0)
                {
                    MessageBox.Show("Hiện không có đơn đăt phòng");
                    this.Close();
                }
                else
                loadThongTin(lstDatPhong[0].MADATPHONG);
            }
            foreach (var dp in lstDatPhong)
            {
                var btn = new Button() { Width = 60, Height = 60};
                float fontSize = 9;
                Font f = new Font("Microsoft Sans Serif", fontSize, FontStyle.Bold);
                btn.Font = f;
                btn.BackColor = Color.LightBlue;
                flowDanhSachDP.Controls.Add(btn);
                btn.Tag = dp;
                btn.Text = dp.MADATPHONG.ToString();
                var kh = khachHangDAO.GetKhachHang(dp.MAKH);
                toolTip1.SetToolTip(btn, "Phòng: " + dp.MAPHONG + "\n" + "Tên KH :" + kh.TENKH + "\n" + "Ngày Ở: " + dp.NGAYO.Value.ToShortDateString());
                btn.Click += btn_Click;
            }
        }
        double? tinhTongTienPhong(DatPhong datPhong)
        {
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhong(Convert.ToInt32(datPhong.MAPHONG));
            double soNgay = (dtpkNgayDi.Value.Date - dtpkNgayO.Value.Date).TotalDays;
            if(soNgay == 0)
            {
                soNgay = 0.5;
            }
            double? tienPhong = phong.GIAPHONG * soNgay;
            return tienPhong;
        }

        void loadThongTin(int maDatPhong)
        {
            var datPhong = datPhongDAO.GetDatPhong(maDatPhong);
            var khachHang = khachHangDAO.GetKhachHang(datPhong.MAKH);


            lbMaDatPhong.Text = datPhong.MADATPHONG.ToString();
            MaDatp = lbMaDatPhong.Text;
            labMaPhong.Text = datPhong.MAPHONG.ToString();
            lbMaKH.Text = datPhong.MAKH.ToString();
            lbHoTen.Text = khachHang.TENKH;
            lbGioiTinh.Text = khachHang.GIOITINH;
            dtpkNgaySinh.Value = khachHang.NGAYSINH.Value.Date;
            lbDiaChi.Text = khachHang.DIACHI;
            lbCMND.Text = khachHang.CHUNGMINHTHU;
            lbSDT.Text = khachHang.SODIENTHOAI;

            var lstDatPhong = datPhongDAO.GetListDatPhong(fPhong.MaPtag);
            dtpkNgayDi.MinDate = datPhong.NGAYO.Value.Date;
            var thongTinPhongDat = (from a in db.Phongs
                                    where a.MAPHONG == datPhong.MAPHONG
                                    select new
                                    {
                                        MAPHONG = a.MAPHONG,
                                        TENPHONG = a.TENPHONG,
                                        TINHTRANGPHONG = a.TINHTRANGPHONG,
                                        MALOAIPHONG = a.MALOAIPHONG,
                                        GIAPHONG = a.GIAPHONG,
                                        DONVITIENTE = a.DONVITIENTE
                                    }).ToList();

            dtgvThongTinPhongThanhToan.DataSource = thongTinPhongDat;
            var thongTinDichVuDat = (from a in db.DatDichVus
                                     where a.MADATPHONG == datPhong.MADATPHONG
                                     select new
                                     {
                                         Id = a.Id,
                                         MADATPHONG = a.MADATPHONG,
                                         MADV = a.MADV,
                                         SoLuong = a.SoLuong,
                                         ngayDung = a.ngayDung,
                                         giaDichVuHienTai = a.giaDichVuHienTai,
                                     }).ToList();
            dtgvThongTinDichVuThanhToan.DataSource = thongTinDichVuDat;
            double? tienDV = 0;
            foreach (var datDV in thongTinDichVuDat)
            {
                tienDV += datDV.giaDichVuHienTai;
            }
            lbTienDV.Text = tienDV.ToString();
            lbTraTruoc.Text = datPhong.TRATRUOC.ToString();
            dtpkNgayO.Value = datPhong.NGAYO.Value.Date;
            dtpkNgayDi.Value = dtpkNgayThanhToan.Value.Date;

            var tienPhong = tinhTongTienPhong(db.DatPhongs.Find(datPhong.MADATPHONG));
            lbTienPhg.Text = tienPhong.ToString();
            lbTienDV.Text = tienDV.ToString();
            var TongTien = tienDV + tienPhong;
            lbTongTien.Text = TongTien.ToString();
            var conLai = TongTien - datPhong.TRATRUOC;
            lbConLai.Text = conLai.ToString();
            dtpkNgayThanhToan.Value = DateTime.Today;
            
        }
        private void btn_Click(object sender, EventArgs e)
        {
            var dp = ((sender as Button).Tag as DatPhong).MADATPHONG;
            loadThongTin(dp);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txbTienMat.Text == "") lbThongBao.Visible = true;
            if (txbTienMat.Text != "" && Convert.ToDouble(txbTienMat.Text) >= Convert.ToDouble(lbConLai.Text))
            {
                lbThongBao.Visible = false;
                var datPhong = datPhongDAO.GetDatPhong(Convert.ToInt32(lbMaDatPhong.Text));
                var lsdatDichVu = datDichVuDAO.GetListDatDichVu(datPhong.MADATPHONG);
                HoaDon hoaDon = new HoaDon()
                {
                    NGAYTHANHTOAN = DateTime.Today,
                    MAKH = datPhong.MAKH,
                    TIENPHONG = Convert.ToInt32(lbTienPhg.Text),
                    MANHANVIEN = fLogin.MaNhanVien,
                    TIENDV = tinhTongTienDichVu(datPhong.MADATPHONG),
                };
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                foreach (var ddv in lsdatDichVu)
                {
                    DatDichVu a = db.DatDichVus.Find(ddv.Id);
                    db.DatDichVus.Remove(a);
                }
                db.SaveChanges();

                var dp = db.DatPhongs.Find(datPhong.MADATPHONG);
                dp.isDelete = true;
                db.SaveChanges();

                int ma = hoaDon.MAHD;
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon()
                {
                    MAHD = ma,
                    MADATPHONG = datPhong.MADATPHONG,
                    GHICHU = ""
                };
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();

                MessageBox.Show("Thanh cong");
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

                var tien = Convert.ToDouble(txbTienMat.Text) - Convert.ToDouble(lbConLai.Text);
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
            //    double soNgayThue = 0;
            //    var phong = phongDAO.GetPhong(Convert.ToInt32(labMaPhong.Text));
            //    if (dtpkNgayDi.Value.Date == dtpkNgayO.Value.Date)
            //    {
            //        soNgayThue = 0.5;
            //    }
            //    else soNgayThue = (dtpkNgayDi.Value.Date - dtpkNgayO.Value.Date).TotalDays;
            //    lbTienPhg.Text = (soNgayThue * phong.GIAPHONG).ToString();
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
                if (double.Parse(txbTienMat.Text) >= double.Parse(lbConLai.Text))
                {
                    lbThongBao2.Visible = false;
                    lbTienThua.Text = (double.Parse(txbTienMat.Text) - double.Parse(lbConLai.Text)).ToString();
                }
                else
                {
                    lbThongBao2.Visible = true;
                    lbTienThua.Text = "0";
                }
            }

        }
    }
}

