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

        void loadDuLieu(int line ,int page)
        {
            if (page == 0)
                page = 1;

            if (line == 0)
                line = int.MaxValue;

            var skip = (page - 1) * line;

            //var hoaDon = hoaDonDAO.GetHoaDon();
            //dtgvThongke.DataSource = hoaDon;
            var result =  (from a in db.HoaDons
                          from b in db.ChiTietHoaDons
                          from c in db.DatPhongs
                          from d in db.KhachHangs
                          where b.MADATPHONG == c.MADATPHONG && a.MAHD == b.MAHD && d.MAKH == c.MAKH
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
                              TongTien = a.TIENPHONG + a.TIENDV
                          }).ToList();
            var dataPagination = result.OrderBy(x=> x.MaHD).Skip(skip).Take(line).ToList();// get list to paginate
            var pageNumber = (result.ToList().Count() / line);
            if (result.Count() % 2 == 0)
            {
                NumCount = pageNumber;
            }
            else NumCount = pageNumber + 1;
            ngayThanhToan.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayO.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayDi.DefaultCellStyle.Format = "dd/MM/yyyy";
            //var timNum = top.Except(result.Take(line * (page - 1))).ToList();
            if (page != 0)
            {
                dtgvThongke.DataSource = dataPagination;
            }
            double? tien = 0;
            foreach (var hoaDon in result)
            {
                tien += hoaDon.TongTien;
            }
            lbTongTien.Text = tien + " vnđ";
        }

        public void refresh()
        {
            dtgvThongke.DataBindings.Clear();
            int num = int.Parse(txbNumberPage.Text);
            loadDuLieu(10,num);
        }
        private void fThongKe_Load(object sender, EventArgs e)
        {
            int num = int.Parse(txbNumberPage.Text);
            loadDuLieu(10,num);
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
            if(int.Parse(txbNumberPage.Text) < numCount)
            {
                txbNumberPage.Text = (int.Parse(txbNumberPage.Text) + 1).ToString();
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if(txbNumberPage.Text != "1")
            {
                txbNumberPage.Text = (int.Parse(txbNumberPage.Text)-1).ToString();
            }
        }
    }
}
