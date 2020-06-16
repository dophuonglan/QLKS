using KS.DAO;
using System;
using System.Text.RegularExpressions;
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

        private bool checkHopLe()
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
            //if (txbEditMoTa.Text == "")
            //{
            //    labTBSaiDVTT.Visible = true;
            //}
            if (cbbDonViTienTe.Text == "")
            {
                lbThongBaoDonViTienTe.Visible = true;
            }
            else lbThongBaoDonViTienTe.Visible = false;
            //else labTBSaiDVTT.Visible = false;
            if (txbEditTenPhg.Text == "" && txbEditLoaiPhg.Text == "" && txbEditGiaPhg.Text == "" &&
               txbEditMoTa.Text == "" && cbbDonViTienTe.Text == "") return false;
            return true;
        }

        private bool checkTenPhongHopLe(Phong ph)
        {
            PhongDAO phongDAO = new PhongDAO();
            var lstPhong = phongDAO.GetPhongNotDeleted();
            foreach (var item in lstPhong)
            {
                if (item.TENPHONG == txbEditTenPhg.Text && item.isDelete == false && item.TENPHONG == ph.TENPHONG) continue;
                if (item.TENPHONG == txbEditTenPhg.Text && item.isDelete == false)
                {
                    MessageBox.Show("Tên phòng tồn tại");
                    return false;
                }
            }
            return true;
        }

        private void btnSubMitEditPhg_Click(object sender, EventArgs e)
        {
            if (checkHopLe() == true)
            {
                PhongDAO phongDAO = new PhongDAO();
                var ph = phongDAO.GetPhong(fPhong.PhongID);
                if (!IsNumber(txbEditGiaPhg.Text))
                {
                    MessageBox.Show("Giá phòng không hợp lệ");
                    return;
                }
                if (checkTenPhongHopLe(ph) == false)
                {
                    return;
                }
                var maLP = 0;
                if (txbEditLoaiPhg.Text == "Cao Cấp") maLP = 2;
                else maLP = 1;
                int IDPhong = fPhong.PhongID;
                Phong phong = db.Phongs.Find(IDPhong);
                phong.TENPHONG = txbEditTenPhg.Text;
                phong.MALOAIPHONG = maLP;
                phong.GIAPHONG = Convert.ToDouble(txbEditGiaPhg.Text);
                phong.DONVITIENTE = cbbDonViTienTe.Text;
                phong.MOTA = txbEditMoTa.Text;
                //if (MessageBox.Show("Bạn có thật sự muốn sửa phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                //{
                db.SaveChanges();
                MessageBox.Show("Updata thành công!");
                //}
                //this.Close();
            }
        }

        private void fEditDSPhg_Load(object sender, EventArgs e)
        {
            int IDPhong = fPhong.PhongID;
            lbID.Text = IDPhong.ToString();
            var rooms = phongDAO.GetPhong(IDPhong);
            txbEditTenPhg.Text = rooms.TENPHONG;
            txbEditGiaPhg.Text = rooms.GIAPHONG.ToString();
            txbEditMoTa.Text = rooms.MOTA;
            cbbDonViTienTe.Text = rooms.DONVITIENTE;
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
        }
    }
}