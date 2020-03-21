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
    public partial class fThongTinKH : Form
    {
        public static string Ten = null;
        public static string Ma = null;
        QLKSEntities2 db = new QLKSEntities2();
        KhachHangDAO khachHangDAO = null;
        public fThongTinKH()
        {
            InitializeComponent();
            khachHangDAO = new KhachHangDAO();
        }

        private void fThongTinKH_Load(object sender, EventArgs e)
        {
            var kh =khachHangDAO.GetKhachHang();
            dtgvDanhSachKH.DataSource = kh;
            addDataBiding();

        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            this.dtgvDanhSachKH.Columns.Clear();
            var result = from c in db.KhachHangs
                         where c.SODIENTHOAI.Contains(txbTimKiem.Text)
                         //&& c.MAPHONG == id
                         select new
                         {
                             MaKH = c.MAKH,
                             TenKH = c.TENKH,
                             GioiTinh = c.GIOITINH,
                             NgaySinh = c.NGAYSINH,
                             DiaChi = c.DIACHI,
                             SDT = c.SODIENTHOAI,
                             CMT = c.CHUNGMINHTHU
                         };
            
            dtgvDanhSachKH.DataSource = result.ToList();
            //var kh = khachHangDAO.GetKhachHang(txbTimKiem.Text);
            //dtgvDanhSachKH.DataSource = kh;
        }
        void addDataBiding()
        {
            txbTenKH.DataBindings.Add(new Binding("Text", dtgvDanhSachKH.DataSource, "TENKH"));
            txbMaKH.DataBindings.Add(new Binding("Text", dtgvDanhSachKH.DataSource, "MAKH"));
            Ten= txbTenKH.Text;
            Ma = txbMaKH.Text;
        }
        private void addNewKH_Click(object sender, EventArgs e)
        {
            fDatPhong addNewKH = new fDatPhong();
            this.Hide();
            addNewKH.ShowDialog();
            this.Show();
        }

      
    }
}
