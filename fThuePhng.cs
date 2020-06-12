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
    public partial class fThuePhng : Form
    {
        fPhong f = new fPhong();
        QLKSEntities2 db = new QLKSEntities2();
        PhongDAO phongDAO = null;
        DatPhongDAO datPhongDAO = null;
        KhachHangDAO khachHangDAO = null;
        public fThuePhng()
        {
            InitializeComponent();
            phongDAO = new PhongDAO();
            khachHangDAO = new KhachHangDAO();
            datPhongDAO = new DatPhongDAO();
        }
    }
}
