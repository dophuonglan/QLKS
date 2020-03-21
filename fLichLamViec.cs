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
    public partial class fLichLamViec : Form
    {
        QLKSEntities2 db = new QLKSEntities2();
        public fLichLamViec()
        {
            InitializeComponent();
        }

        private void fLichLamViec_Load(object sender, EventArgs e)
        {
            
            var result = from c in db.LichLamViecs
                         from a in db.NhanViens

                         where c.MANHANVIEN == a.MANHANVIEN
                         //&& c.MAPHONG == id
                         select new
                         {
                             MaNhanVien = c.MANHANVIEN,
                             TenNhanVien = a.TENNHANVIEN,
                             NgayLamViec = c.NGAYLAMVIEC,
                             Buoi = c.BUOI,
                             
                         };
            dtgvLichLamViec.DataSource = result.ToList();
        }
      
        private void txbTimLichLamViec_TextChanged(object sender, EventArgs e)
        {
            //if (db.LichLamViecs.SingleOrDefault(x => x.MANHANVIEN.ToString() == (txbTimLichLamViec.Text)) == null)
            //{
            //    MessageBox.Show("Không tồn tại");
            //}
            //else
            //{
                //var lich = lichLamViecDAO.GetLichLamViec(txbTimLichLamViec.Text);
                //dtgvLichLamViec.DataSource = lich.ToString();

                this.dtgvLichLamViec.Columns.Clear();
                var result = from c in db.LichLamViecs
                             from a in db.NhanViens
                             where c.MANHANVIEN == a.MANHANVIEN
                             && a.TENNHANVIEN.Contains(txbTimLichLamViec.Text)
                             //&& c.MAPHONG == id
                             select new
                             {
                                 MaNhanVien = c.MANHANVIEN,
                                 TenNhanVien = a.TENNHANVIEN,
                                 NgayLamViec = c.NGAYLAMVIEC,
                                 Buoi = c.BUOI,

                             };
                dtgvLichLamViec.DataSource = result.ToList();
            //}
        }
    }
}
