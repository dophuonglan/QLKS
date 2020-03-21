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
    public partial class fPrintChiTietHoaDon : Form
    {
        DatDichVuDAO datDichVuDAO = null;
        HoaDonDAO hoaDonDAO = null;
        DatPhongDAO datPhongDAO = null;
        KhachHangDAO khachHangDAO = null;
        QLKSEntities2 db = null;
        private static DateTime ngayDi;

        public static DateTime NgayDi { get => ngayDi; set => ngayDi = value; }

        public fPrintChiTietHoaDon()
        {
            db = new QLKSEntities2();
            khachHangDAO = new KhachHangDAO();
            datDichVuDAO = new DatDichVuDAO();
            datPhongDAO = new DatPhongDAO();
            hoaDonDAO = new HoaDonDAO();
            InitializeComponent();
        }

        private void fPrintChiTietHoaDon_Load(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(fThanhToan.MaDatp);
            //var listDichVu = datDichVuDAO.GetListDatDichVu(ma);
            var dv = (from a in db.DatDichVus
                      from b in db.DichVus
                                    where a.MADV ==b.MADV &&
                                    a.MADATPHONG == ma
                                    select new
                                    {
                                        ngayDung = a.ngayDung,
                                        TENDV = b.TENDV,
                                        giaDichVuHienTai = a.giaDichVuHienTai,
                                    }).ToList();
            dtgvChiTietHoaDon.DataSource = dv;
            var datPhong = datPhongDAO.GetDatPhong(ma);
            var khachHang = khachHangDAO.GetKhachHang(datPhong.MAKH);
            lbTen.Text = khachHang.TENKH;
            lbDiaChi.Text = khachHang.DIACHI;
            lbDienThoai.Text = khachHang.SODIENTHOAI;
            lbMaPhong.Text = datPhong.MAPHONG.ToString();
            dtpkNgayThanhToan.Value = DateTime.Today;
            dtpkNgayDen.Value = datPhong.NGAYO.Value.Date;
            dtpkNgayDi.Value = datPhong.NGAYDI.Value.Date;
            lbTienPhong.Text = fThanhToan.Tienphong.ToString();
            lbTongCong.Text = (fThanhToan.Tienphong + fThanhToan.TienDV).ToString();
            dtpkNgayDi.Value = NgayDi;
            lbSoNgay.Text = ((dtpkNgayDen.Value.Date - dtpkNgayDi.Value.Date).TotalDays).ToString();
        }
    }
}
