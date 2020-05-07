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
    public partial class fEditDSPhg : Form
    {
        QLKSEntities2 db = new QLKSEntities2();
        fPhong fPhong = null;
        PhongDAO phongDAO = null;
        public fEditDSPhg()
        {
            InitializeComponent();
            fPhong = new fPhong();
            phongDAO = new PhongDAO();
        }
        private bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private void btnSubMitEditPhg_Click(object sender, EventArgs e)
        {
            if (txbEditTenPhg.Text == "")
            {
                labTBSaiTenPhg.Visible = true;
            }
            else labTBSaiTenPhg.Visible = false;
            if (txbEditLoaiPhg.Text == "")
            {
                labTBSaiLoaiPhg.Visible = true;
            }
            else labTBSaiLoaiPhg.Visible = false;
            if (txbEditGiaPhg.Text == "")
            {
                labTBSaiGiaPhg.Visible = true;
            }
            else labTBSaiGiaPhg.Visible = false;
            if (txbEditDonViTT.Text == "")
            {
                labTBSaiDVTT.Visible = true;
            }
            else labTBSaiDVTT.Visible = false;
            //if (db.Phongs.SingleOrDefault(x => x.MAPHONG.ToString() == txbEditMaPhg.Text) != null)
            //{
            //    labTBTrungMaPhg.Visible = true;
            //}
            //else labTBTrungMaPhg.Visible = false;

            if (!IsNumber(txbEditGiaPhg.Text))
            {
                MessageBox.Show("Giá phòng không hợp lệ");
            }
            else if (txbEditMaPhg.Text != "" && txbEditTenPhg.Text != "" && txbEditLoaiPhg.Text != "" && txbEditGiaPhg.Text != "" &&
               txbEditDonViTT.Text != "" && txbEditDonViTT.Text != "")
            {

                var maLP = 0;
                if (txbEditLoaiPhg.Text == "Cao Cấp") maLP = 2;
                else maLP = 1;
                Phong phg = new Phong()
                {

                    MAPHONG = Convert.ToInt32(txbEditMaPhg.Text),
                    TINHTRANGPHONG = "Trống",
                    TENPHONG = txbEditTenPhg.Text,
                    MALOAIPHONG = maLP,
                    GIAPHONG = Convert.ToDouble(txbEditGiaPhg.Text),
                    DONVITIENTE = txbEditDonViTT.Text
                };
                //db.Phongs.Add(phg);
                int IDPhong = fPhong.PhongID;
                Phong phong = db.Phongs.Find(IDPhong);
                phong.TENPHONG = txbEditTenPhg.Text;
                phong.MALOAIPHONG = maLP;
                phong.GIAPHONG = Convert.ToDouble(txbEditGiaPhg.Text);
                phong.DONVITIENTE = txbEditDonViTT.Text;
                if (MessageBox.Show("Bạn có thật sự muốn sửa phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    db.SaveChanges();
                    MessageBox.Show("Updata thành công!");
                }
                this.Close();
            }
        }

        private void fEditDSPhg_Load(object sender, EventArgs e)
        {
            int IDPhong = fPhong.PhongID;
            txbEditMaPhg.Text = IDPhong.ToString();
            var rooms = phongDAO.GetPhong(IDPhong);
            txbEditTenPhg.Text = rooms.TENPHONG;
            txbEditGiaPhg.Text = rooms.GIAPHONG.ToString();
            txbEditDonViTT.Text = rooms.DONVITIENTE;
            switch (rooms.MALOAIPHONG)
            {
                case 1:
                    txbEditLoaiPhg.Text = "Tiêu Chuẩn";
                    break;
                case 2:
                    txbEditLoaiPhg.Text = "Cao Cấp";
                    break;
                default:
                    break;
            }
            txbEditMaPhg.Enabled = false;
        }
    }
}