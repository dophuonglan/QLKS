using KS.Common;
using KS.DAO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KS
{
    public partial class fThongKe : Form
    {
        QLKSEntities2 db = null;
        HoaDonDAO hoaDonDAO = null;
        private int numCount;

        public int NumCount { get => numCount; set => numCount = value; }

        public fThongKe()
        {
            db = new QLKSEntities2();
            hoaDonDAO = new HoaDonDAO();
            InitializeComponent();
        }

        private void fillChart()
        {
            var result = (from a in db.Phongs
                          from b in db.ThuePhongs
                          from c in db.ChiTietHoaDons
                          from d in db.HoaDons
                          where b.MAPHONG == a.MAPHONG
                          && b.MATHUEPHONG == c.MATHUEPHONG
                          && d.MAHD == c.MAHD
                          && d.NGAYTHANHTOAN >= dtpkNgayBatDau.Value.Date && d.NGAYTHANHTOAN <= dtpkNgayKetThuc.Value.Date
                          select new QuanLyPhong
                          {
                              maThuePhong = c.MATHUEPHONG,
                              maPhong = a.MAPHONG,
                              NgayO = b.NGAYO,
                              NgayDi = b.NGAYDI,
                          }
                         ).ToList();
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhongNotDeleted();
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            double tongNgay = 0;
            foreach (var item in phong)
            {
                //var listThuePhg = thuePhongDAO.GetListThuePhong(item.MAPHONG);
                double tongngayo = 0;
                var list = result.Where(x => item.MAPHONG == x.maPhong).ToList();
                foreach (var it in list)
                {
                    tongngayo = (it.NgayDi.Value.Date - it.NgayO.Value.Date).TotalDays;
                    if (tongngayo == 0)
                    {
                        tongngayo = 1;
                    }
                    tongNgay += tongngayo;
                }
                chart1.Series["Số Ngày"].Points.AddXY(item.TENPHONG, tongNgay);
                chart1.Series["Số Ngày"].IsValueShownAsLabel = true;
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                tongNgay = 0;
                tongngayo = 0;
            }
        }

        private void fillChartDoanhThuPhong()
        {
            var result = (from a in db.Phongs
                          from b in db.ThuePhongs
                          from c in db.ChiTietHoaDons
                          from d in db.HoaDons
                          where b.MAPHONG == a.MAPHONG
                          && b.MATHUEPHONG == c.MATHUEPHONG
                          && d.MAHD == c.MAHD
                          && d.NGAYTHANHTOAN >= dtpkNgayBatDau.Value.Date && d.NGAYTHANHTOAN <= dtpkNgayKetThuc.Value.Date
                          select new QuanLyPhong
                          {
                              maThuePhong = b.MATHUEPHONG,
                              maPhong = a.MAPHONG,
                              NgayO = b.NGAYO,
                              NgayDi = b.NGAYDI,
                              TienPhong = d.TIENPHONG,
                          }
                         ).ToList();
            PhongDAO phongDAO = new PhongDAO();
            var phong = phongDAO.GetPhongNotDeleted();
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            foreach (var item in phong)
            {
                double? tongTien = 0;
                var list = result.Where(x => item.MAPHONG == x.maPhong).ToList();
                foreach (var it in list)
                {
                    tongTien += it.TienPhong;
                }

                chartDoanhThuPhong.Series["Số tiền"].Points.AddXY(item.TENPHONG, tongTien);
                chartDoanhThuPhong.Series["Số tiền"].IsValueShownAsLabel = true;
                chartDoanhThuPhong.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chartDoanhThuPhong.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            }
        }

        private void fillChartDV()
        {
            var result = (from a in db.DichVus
                          from b in db.DatDichVus
                          from c in db.ChiTietHoaDons
                          from d in db.HoaDons
                          where b.MADV == a.MADV
                          && b.MATHUEPHONG == c.MATHUEPHONG
                          && d.MAHD == c.MAHD
                          && d.NGAYTHANHTOAN >= dtpkNgayBatDau.Value.Date && d.NGAYTHANHTOAN <= dtpkNgayKetThuc.Value.Date
                          select new QuanLyDatDichVu
                          {
                              MaThuePhong = c.MATHUEPHONG,
                              SoLuong = b.SoLuong,
                              MaDichVu = b.MADV
                          }
                         );
            DichVuDAO dichVuDAO = new DichVuDAO();
            var dichVu = dichVuDAO.GetDichVu();
            foreach (var item in dichVu)
            {
                //var list = thuePhongDAO.GetListThuePhong(item.MAPHONG);
                int? tongsoluong = 0;
                var list = result.Where(x => item.MADV == x.MaDichVu).ToList();
                foreach (var it in list)
                {
                    tongsoluong += it.SoLuong;
                }
                chartDV.Series["Số lượng"].Points.AddXY(item.TENDV, tongsoluong);
                chartDV.Series["Số lượng"].IsValueShownAsLabel = true;
                chartDV.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chartDV.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                tongsoluong = 0;
            }
        }

        //private void fillChartDoanhThuDichVu()
        //{
        //    var result = (from a in db.DichVus
        //                  from b in db.DatDichVus
        //                  from c in db.ChiTietHoaDons
        //                  from d in db.HoaDons
        //                  where b.MADV == a.MADV
        //                  && b.MATHUEPHONG == c.MATHUEPHONG
        //                  && d.MAHD == c.MAHD
        //                  && d.NGAYTHANHTOAN >= dtpkNgayBatDau.Value.Date && d.NGAYTHANHTOAN <= dtpkNgayKetThuc.Value.Date
        //                  select new QuanLyDatDichVu
        //                  {
        //                      MaThuePhong = c.MATHUEPHONG,
        //                      SoLuong = b.SoLuong,
        //                      MaDichVu = b.MADV,
        //                      TienDichVu = d.TIENDV,
        //                  }
        //                 );
        //    DichVuDAO dichVuDAO = new DichVuDAO();
        //    var dichVu = dichVuDAO.GetDichVu();
        //    foreach (var item in dichVu)
        //    {
        //        //var list = thuePhongDAO.GetListThuePhong(item.MAPHONG);
        //        double? tongTien = 0;
        //        var list = result.Where(x => item.MADV == x.MaDichVu).ToList();
        //        foreach (var it in list)
        //        {
        //            tongTien += it.TienDichVu;
        //        }
        //        chartDoanhThuDichVu.Series["Số tiền"].Points.AddXY(item.TENDV, tongTien);
        //        chartDoanhThuDichVu.Series["Số tiền"].IsValueShownAsLabel = true;
        //        chartDoanhThuDichVu.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        //        chartDoanhThuDichVu.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
        //    }
        //}

        void loadDuLieu(int line, int page)
        {

            if (page == 0)
                page = 1;

            if (line == 0)
                line = int.MaxValue;
            var skip = (page - 1) * line;
            var result = (from a in db.HoaDons
                          from b in db.ChiTietHoaDons
                          from c in db.ThuePhongs
                          from d in db.KhachHangs
                          from e in db.Phongs
                          where b.MATHUEPHONG == c.MATHUEPHONG && a.MAHD == b.MAHD && d.MAKH == c.MAKH
                          && e.MAPHONG == c.MAPHONG
                          && a.NGAYTHANHTOAN >= dtpkNgayBatDau.Value.Date && a.NGAYTHANHTOAN <= dtpkNgayKetThuc.Value.Date
                          select new RowThongKeHoaDon
                          {
                              MaHD = a.MAHD,
                              NgayThanhToan = a.NGAYTHANHTOAN,
                              TenKH = d.TENKH,
                              SoDienThoai = d.SODIENTHOAI,
                              NgayO = c.NGAYO,
                              NgayDi = c.NGAYDI,
                              TienDV = a.TIENDV,
                              TienPhong = a.TIENPHONG,
                              TongTien = a.TIENPHONG + a.TIENDV,
                              TenPhong = e.TENPHONG,
                              MaThuePhong = c.MATHUEPHONG,
                          }).ToList();
            DatDichVuDAO datDichVuDAO = new DatDichVuDAO();

            DichVuDAO dichVuDAO = new DichVuDAO();
            var dataPagination = result.OrderBy(x => x.MaHD).Skip(skip).Take(line).ToList();// get list to paginate
            var pageNumber = (result.ToList().Count() / line);
            if (result.Count() % 2 == 0)
            {
                NumCount = pageNumber;
            }
            else NumCount = pageNumber + 1;
            ngayThanhToan.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayO.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayDi.DefaultCellStyle.Format = "dd/MM/yyyy";
            if (page != 0)
            {
                dtgvThongke.DataSource = dataPagination;
            }
            double? tien = 0;
            int i = 1;
            foreach (var item in result)
            {
                string dvsd = "";
                item.STT = i;
                i++;
                var ddv = datDichVuDAO.GetListDatDichVu(item.MaThuePhong);
                foreach (var it in ddv)
                {
                    var dv = dichVuDAO.GetDichVu(it.MADV);
                    dvsd += dv.TENDV + "x" + it.SoLuong + "; ";
                    item.DichVuSuDung = dvsd;
                }
                tien += item.TongTien;
            }
            lbTongTien.Text = tien + " vnđ";
        }

        void loadDuLieuTheoPhong(int line, int page)
        {
            if (page == 0)
                page = 1;
            if (line == 0)
                line = int.MaxValue;
            var skip = (page - 1) * line;
            var result = (from a in db.HoaDons
                          from b in db.ChiTietHoaDons
                          from c in db.ThuePhongs
                          from d in db.KhachHangs
                          from e in db.Phongs
                          where b.MATHUEPHONG == c.MATHUEPHONG && a.MAHD == b.MAHD && d.MAKH == c.MAKH
                          && e.MAPHONG == c.MAPHONG
                          && e.TENPHONG == cbbChonPhg.Text
                          && a.NGAYTHANHTOAN >= dtpkNgayBatDau.Value.Date && a.NGAYTHANHTOAN <= dtpkNgayKetThuc.Value.Date
                          select new RowThongKeHoaDon
                          {
                              MaHD = a.MAHD,
                              NgayThanhToan = a.NGAYTHANHTOAN,
                              TenKH = d.TENKH,
                              SoDienThoai = d.SODIENTHOAI,
                              NgayO = c.NGAYO,
                              NgayDi = c.NGAYDI,
                              TienDV = a.TIENDV,
                              TienPhong = a.TIENPHONG,
                              TongTien = a.TIENPHONG + a.TIENDV,
                              TenPhong = e.TENPHONG,
                              MaThuePhong = c.MATHUEPHONG,
                          }).ToList();
            DatDichVuDAO datDichVuDAO = new DatDichVuDAO();

            DichVuDAO dichVuDAO = new DichVuDAO();


            var dataPagination = result.OrderBy(x => x.MaHD).Skip(skip).Take(line).ToList();// get list to paginate
            var pageNumber = (result.ToList().Count() / line);
            if (result.Count() % 2 == 0)
            {
                NumCount = pageNumber;
            }
            else NumCount = pageNumber + 1;
            ngayThanhToan.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayO.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayDi.DefaultCellStyle.Format = "dd/MM/yyyy";
            if (page != 0)
            {
                dtgvThongke.DataSource = dataPagination;
            }
            double? tien = 0;
            int i = 1;
            foreach (var item in result)
            {
                string dvsd = null;
                item.STT = i;
                i++;
                var ddv = datDichVuDAO.GetListDatDichVu(item.MaThuePhong);
                foreach (var it in ddv)
                {
                    var dv = dichVuDAO.GetDichVu(it.MADV);
                    dvsd += dv.TENDV + "x" + it.SoLuong + ";";
                    item.DichVuSuDung = dvsd;
                }
                tien += item.TongTien;
            }
            lbTongTien.Text = tien + " vnđ";
        }
        public void refresh()
        {
            dtgvThongke.DataBindings.Clear();
            int num = int.Parse(txbNumberPage.Text);
            loadDuLieu(10, num);
            loadDanhSachKhachHangDangThue();
            chart();
        }
        private void chart()
        {
            chart1.Series["Số Ngày"].Points.Clear();
            chartDV.Series["Số lượng"].Points.Clear();
            chartDoanhThuPhong.Series["Số tiền"].Points.Clear();
            fillChart();
            fillChartDV();
            fillChartDoanhThuPhong();
            chartDoanhThuPhong.Refresh();
            chartDV.Refresh();
            chart1.Refresh();
        }
        void loadCbbTenPhong()
        {
            PhongDAO phongDAO = new PhongDAO();
            var lstPhg = phongDAO.GetPhongNotDeleted();
            cbbChonPhg.DataSource = lstPhg;
            cbbChonPhg.DisplayMember = "TENPHONG";
            cbbChonPhg.Text = "Tất cả";

        }

        private void loadDanhSachKhachHangDangThue()
        {
            var result = (from a in db.KhachHangs
                         from b in db.ThuePhongs
                          from c in db.Phongs
                          from d in db.LoaiPhongs
                          where 
                         a.MAKH ==b.MAKH
                         && b.MAPHONG == c.MAPHONG
                         && c.MALOAIPHONG == d.MALOAIPHONG
                         && b.isDelete ==false
                         select new ThongTinKhachHangDangThue
                         {
                             TenKH = a.TENKH,
                             NgaySinh = a.NGAYSINH,
                             SoDienThoai = a.SODIENTHOAI,
                             DiaChi = a.DIACHI,
                             CMT = a.CHUNGMINHTHU,
                             MaThuePhong = b.MATHUEPHONG,
                             TenPhong = c.TENPHONG,
                             TenLoaiPhong = d.TENLOAIPHONG,
                             NgayNhanPhong = b.NGAYO,
                             NgayDi = b.NGAYDI,
                             TienPhong = b.GiaPhongHienTai,
                         }).ToList();
            dtgvDanhSachKhachHangDangThue.DataSource = result;
            int i = 1;
            DatDichVuDAO datDichVuDAO = new DatDichVuDAO();
            DichVuDAO dichVuDAO = new DichVuDAO();
            foreach (var item in result)
            {
                string dvsd = "";
                item.STT = i;
                i++;
                var ddv = datDichVuDAO.GetListDatDichVu(item.MaThuePhong);
                foreach (var it in ddv)
                {
                    var dv = dichVuDAO.GetDichVu(it.MADV);
                    dvsd += dv.TENDV + "x" + it.SoLuong + "; ";
                    item.DichVuSuDung = dvsd;
                }
            }
        }

        private void loadChartPie()
        {
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            var lst = thuePhongDAO.GetThuePhong();
            var soPhong = lst.Count();
            PhongDAO phongDAO = new PhongDAO();
            var lstPh = phongDAO.GetPhongNotDeleted();
            var soPhongTrong = lstPh.Count - soPhong;
            chartPie.Series["Series1"].Points.AddXY("Trống",soPhongTrong);
            chartPie.Series["Series1"].Points.AddXY("Đang Thuê", soPhong);
            chartPie.Series["Series1"].IsValueShownAsLabel = true;
        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
            int num = int.Parse(txbNumberPage.Text);
            loadDuLieu(10, num);
            loadCbbTenPhong();
            chart();
            loadDanhSachKhachHangDangThue();
            loadChartPie();
        }

        private void dtpkNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            refresh();
            txbNumberPage.Text = "1";
        }

        private void dtpkNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            refresh();
            txbNumberPage.Text = "1";
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txbNumberPage.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            refresh();
            txbNumberPage.Text = NumCount.ToString();
        }

        private void txbNumberPage_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {

            //txbNumberPage.Text = (int.Parse(txbNumberPage.Text)).ToString();
            if (int.Parse(txbNumberPage.Text) < numCount)
            {
                txbNumberPage.Text = (int.Parse(txbNumberPage.Text) + 1).ToString();
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (txbNumberPage.Text != "1")
            {
                txbNumberPage.Text = (int.Parse(txbNumberPage.Text) - 1).ToString();
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            int num = int.Parse(txbNumberPage.Text);
            loadDuLieu(10, num);
        }

        private void cbbChonPhg_SelectedValueChanged(object sender, EventArgs e)
        {
            int num = int.Parse(txbNumberPage.Text);
            loadDuLieuTheoPhong(10, num);
            txbNumberPage.Text = "1";
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            if (chart1.Visible == true)
            {
                chart1.Visible = false;
                chartDoanhThuPhong.Visible = true;
                chartDoanhThuPhong.Series["Số tiền"].Points.Clear();
                fillChartDoanhThuPhong();
            }
            else
            {
                chart1.Visible = true;
                chartDoanhThuPhong.Visible = false;
                chart1.Series["Số Ngày"].Points.Clear();
                fillChart();
            }
        }

        private void chartDoanhThuPhong_Click(object sender, EventArgs e)
        {
            if (chart1.Visible == true)
            {
                chart1.Visible = false;
                chartDoanhThuPhong.Visible = true;
                chartDoanhThuPhong.Series["Số tiền"].Points.Clear();
                fillChartDoanhThuPhong();
            }
            else
            {
                chart1.Visible = true;
                chartDoanhThuPhong.Visible = false;
                chart1.Series["Số Ngày"].Points.Clear();
                fillChart();
            }
        }
    }
}
