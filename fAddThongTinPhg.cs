using KS.DAO;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KS
{
    public partial class fAddThongTinPhg : Form
    {
        fPhong fphong = new fPhong();
        private QLKSEntities2 db = new QLKSEntities2();
        PhongDAO phongDAO = new PhongDAO();
        public fAddThongTinPhg()
        {
            InitializeComponent();
        }

        private bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private bool checkTenPhongHopLe(string tenphong)
        {
            PhongDAO phongDAO = new PhongDAO();
            var lstPhong = phongDAO.GetPhongNotDeleted();

            foreach (var item in lstPhong)
            {
                if (item.TENPHONG == tenphong && item.isDelete == false) return false;
            }
            return true;
        }

        private bool checkHople()
        {
            if (txbAddTenPhg.Text == "")
            {
                labTBSaiTenPhg.Visible = true;
            }
            else labTBSaiTenPhg.Visible = false;
            if (txbAddLoaiPhg.Text == "")
            {
                labTBSaiLoaiPhg.Visible = true;
            }
            else labTBSaiLoaiPhg.Visible = false;
            if (txbAddGiaPhg.Text == "")
            {
                labTBSaiGiaPhg.Visible = true;
            }
            else labTBSaiGiaPhg.Visible = false;
            //if (txbAddDonViTT.Text == "")
            //{
            //    labTBSaiDVTT.Visible = true;
            //}
            //else labTBSaiDVTT.Visible = false;
            if (cbbDonViTienTe.Text == "")
            {
                lbThongBaoDonViTienTe.Visible = true;
            }
            else lbThongBaoDonViTienTe.Visible = false;
            if (txbAddTenPhg.Text == "" || txbAddLoaiPhg.Text == "" || txbAddGiaPhg.Text == "" || cbbDonViTienTe.Text == "") return false;
            return true;
        }

        private void btnSubMitAddPhg_Click(object sender, EventArgs e)
        {
            if (checkHople() == true)
            {
                if (checkTenPhongHopLe(txbAddTenPhg.Text) == false)
                {
                    MessageBox.Show("Tên phòng tồn tại");
                    return;
                }
                if (!IsNumber(txbAddGiaPhg.Text))
                {
                    MessageBox.Show("Giá phòng không hợp lệ");
                    return;
                }
                //if (MessageBox.Show("Bạn có thật sự muốn thêm phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                //{
                var maLP = 0;
                if (txbAddLoaiPhg.Text == "Cao Cấp") maLP = 2;
                else maLP = 1;
                Phong phg = new Phong()
                {
                    TINHTRANGPHONG = "Trống",
                    TENPHONG = txbAddTenPhg.Text,
                    MALOAIPHONG = maLP,
                    GIAPHONG = Convert.ToDouble(txbAddGiaPhg.Text),
                    DONVITIENTE = txbAddDonViTT.Text,
                    MOTA = txbAddDonViTT.Text,
                    isDelete = false
                };
                db.Phongs.Add(phg);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                fphong.refreshSoDo();
                this.Close();
                //}
            }

        }

    }
}
