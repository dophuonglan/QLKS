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
        private void btnSubMitAddPhg_Click(object sender, EventArgs e)
        {
            //if (txbAddMaPhg.Text == "")
            //{
            //    labTBSaiMa.Visible = true;
            //}
            //else labTBSaiMa.Visible = false;
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
            if (txbAddDonViTT.Text == "")
            {
                labTBSaiDVTT.Visible = true;
            }
            else labTBSaiDVTT.Visible = false;
            //if (db.Phongs.SingleOrDefault(x => x.MAPHONG.ToString() == txbAddMaPhg.Text)!= null){
            //    labTBTrungMaPhg.Visible = true;
            //}
            //else labTBTrungMaPhg.Visible = false;
            if(!IsNumber(txbAddGiaPhg.Text))
            {
                MessageBox.Show("Giá phòng không hợp lệ");
            }
            else if (txbAddTenPhg.Text != "" && txbAddLoaiPhg.Text != "" && txbAddGiaPhg.Text != "" &&
               txbAddDonViTT.Text != "" && txbAddDonViTT.Text != "")
                 {
                if (MessageBox.Show("Bạn có thật sự muốn thêm phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var maLP = 0;
                    if (txbAddLoaiPhg.Text == "Cao Cấp") maLP = 2;
                    else maLP = 1;
                    Phong phg = new Phong()
                    {
                        //MAPHONG = Convert.ToInt32(txbAddMaPhg.Text),
                        TINHTRANGPHONG = "Trống",
                        TENPHONG = txbAddTenPhg.Text,
                        MALOAIPHONG = maLP,
                        GIAPHONG = Convert.ToDouble(txbAddGiaPhg.Text),
                        DONVITIENTE = txbAddDonViTT.Text
                    };
                    db.Phongs.Add(phg);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công!");
                    fphong.refreshSoDo();
                    this.Close();
                }
               
                
            }
        }

    }
}
