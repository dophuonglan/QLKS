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
using static System.Windows.Forms.ListViewItem;

namespace KS
{


    public partial class fPhong : Form
    {
        public class MyButton : Button
        {
            public MyButton()
            {
                SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            }
        }
        static int phongID = 0;
        static string tinhTrangPhg = "";
        QLKSEntities2 db = new QLKSEntities2();
        PhongDAO phongDAO = null;
        DatPhongDAO datPhongDAO = null;
        private static int maPtag;

        public static int PhongID { get => phongID; set => phongID = value; }
        public static string TinhTrangPhg { get => tinhTrangPhg; set => tinhTrangPhg = value; }
        public static int MaPtag { get => maPtag; set => maPtag = value; }

        public fPhong()
        {
            InitializeComponent();
            phongDAO = new PhongDAO();
            datPhongDAO = new DatPhongDAO();
        }
        private void loadDataPhg()
        {
            var result = from c in db.Phongs
                         from a in db.LoaiPhongs

                         where c.MALOAIPHONG == a.MALOAIPHONG
                         select new
                         {
                             Ma = c.MAPHONG,
                             TenPhong = c.TENPHONG,
                             TrangThai = c.TINHTRANGPHONG,
                             TenLoaiPhong = a.TENLOAIPHONG,
                             Gia = c.GIAPHONG,
                             DonVi = c.DONVITIENTE
                         };
            dtgrChiTietPhong.DataSource = result.ToList();
        }

        public void refreshSoDo()
        {
            flowRoom.Controls.Clear();
            loadSoDoPhong();
        }
        public void loadSoDoPhong()
        {
            var rooms = phongDAO.GetPhong();
            int i = 0;
            foreach (var room in rooms)
            {
                var btn = new MyButton() { Width = PhongDAO.btnWidth, Height = PhongDAO.btnHeight };
                float fontSize = 9;
                Font f = new Font("Microsoft Sans Serif", fontSize, FontStyle.Bold);
                lbTongSoPhg.Font = f;
                btn.Font = f;
                flowRoom.Controls.Add(btn);
                btn.Click += btn_Click;
                btn.DoubleClick += btn_DoubleClick;
                btn.Tag = room;
                i++;
                var datPhong = datPhongDAO.GetListDatPhong(room.MAPHONG);
                Phong editPhong = db.Phongs.Find(room.MAPHONG);
                if (datPhong.Count != 0)
                {
                    editPhong.TINHTRANGPHONG = "Đang cho thuê";
                    db.SaveChanges();
                }
                else
                {
                    editPhong.TINHTRANGPHONG = "Trống";
                    db.SaveChanges();
                }

                switch (room.TINHTRANGPHONG)
                {
                    case "Trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.SteelBlue;
                        break;
                }
                btn.Text = "Phòng "+ room.MAPHONG + "\n" + room.TINHTRANGPHONG;

            }
            lbTongSoPhg.Text = i.ToString();
        }

        private void btn_DoubleClick(object sender, EventArgs e)
        {
            tinhTrangPhg = ((sender as Button).Tag as Phong).TINHTRANGPHONG;
            MaPtag = ((sender as Button).Tag as Phong).MAPHONG;
            if (tinhTrangPhg == "Đang cho thuê")
            {
                fThanhToan thanhToan = new fThanhToan();
                Hide();
                thanhToan.ShowDialog();
                refreshSoDo();
            }
        }

        private void fPhong_Load(object sender, EventArgs e)
        {
            loadDataPhg();
            loadSoDoPhong();
        }

        void showThongTin(int id)
        {
            var result = from c in db.Phongs
                         from a in db.LoaiPhongs

                         where c.MALOAIPHONG == a.MALOAIPHONG && c.MAPHONG == id
                         select new
                         {
                             c.MAPHONG,
                             c.TENPHONG,
                             c.TINHTRANGPHONG,
                             a.TENLOAIPHONG,
                             c.GIAPHONG,
                             c.DONVITIENTE
                         };
            dtgrChiTietPhong.DataSource = result.ToList();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            PhongID = ((sender as Button).Tag as Phong).MAPHONG;
            showThongTin(PhongID);
        }

        private void btnExitDSP_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadDataPhg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fAddThongTinPhg fAdd = new fAddThongTinPhg();
            //this.Hide();
            fAdd.ShowDialog();
           refreshSoDo();
            this.Show();
        }

       
        private void btnSuaTTPhg_Click_1(object sender, EventArgs e)
        {
            if(phongID == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
            }
            else
            {
                fEditDSPhg fEdit = new fEditDSPhg();
                fEdit.ShowDialog();
                refreshSoDo();
                this.Show();
            }
        }

        private void btnXoaPhg_Click(object sender, EventArgs e)
        {
            if (phongID == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
            }
            else
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa phòng "+phongID+" này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Phong phong = db.Phongs.SingleOrDefault(x => x.MAPHONG == phongID);
                    db.Phongs.Remove(phong);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    db.SaveChanges();
                    refreshSoDo();
                }
            }
        }
    }
}
