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
        QLKSEntities2 db = null;
        private static int maPtag;

        public static int PhongID { get => phongID; set => phongID = value; }
        public static string TinhTrangPhg { get => tinhTrangPhg; set => tinhTrangPhg = value; }
        public static int MaPtag { get => maPtag; set => maPtag = value; }

        private void phanQuyen()
        {
            if ((fLogin.maChucVu == 4) || fLogin.maChucVu == 5)
            {
                panelAdmin.Enabled = true;
            }
            else panelAdmin.Enabled = false;
        }
        public fPhong()
        {
            InitializeComponent();
            db = new QLKSEntities2();
        }
        private void loadDataPhg()
        {
            phanQuyen();
            var result =( from c in db.Phongs
                         from a in db.LoaiPhongs

                         where c.MALOAIPHONG == a.MALOAIPHONG
                         && c.isDelete == false
                         select new RowPhong
                         {
                             TENPHONG = c.TENPHONG,
                             TINHTRANGPHONG = c.TINHTRANGPHONG,
                             TENLOAIPHONG = a.TENLOAIPHONG,
                             GIAPHONG = c.GIAPHONG,
                             MOTA = c.MOTA,
                         }).ToList();
            int stt = 1;
            foreach (var item in result)
            {
                item.STT = stt;
                stt++;
            }
            dtgrChiTietPhong.DataSource = result;
        }

        void showThongTin(int id)
        {
            var result = (from c in db.Phongs
                          from a in db.LoaiPhongs

                          where c.MALOAIPHONG == a.MALOAIPHONG && c.MAPHONG == id
                          && c.isDelete == false
                          select new RowPhong
                          {
                              TINHTRANGPHONG = c.TINHTRANGPHONG,
                              TENLOAIPHONG = a.TENLOAIPHONG,
                              GIAPHONG = c.GIAPHONG,
                              TENPHONG = c.TENPHONG,
                          }).ToList();
            int stt = 1;
            foreach (var item in result)
            {
                item.STT = stt;
                stt++;
            }
            dtgrChiTietPhong.DataSource = result;
        }
        public void refreshSoDo()
        {
            flowRoom.Controls.Clear();
            loadDataPhg();
            loadSoDoPhong();
        }
        public void loadSoDoPhong()
        {
            PhongDAO phongDAO = new PhongDAO();
            var rooms = phongDAO.GetPhongNotDeleted();
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
                ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
                var thuePhong = thuePhongDAO.GetListThuePhong(room.MAPHONG);
                Phong editPhong = db.Phongs.Find(room.MAPHONG);
                if (thuePhong.Count != 0)
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
                btn.Text = "Phòng "+ i + "\n" + room.TINHTRANGPHONG;

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
                Show();
                refreshSoDo();
            }
        }

        private void fPhong_Load(object sender, EventArgs e)
        {
            loadDataPhg();
            loadSoDoPhong();
        }

        
        private void btn_Click(object sender, EventArgs e)
        {
            PhongID = ((sender as Button).Tag as Phong).MAPHONG;
            showThongTin(PhongID);
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
            ThuePhongDAO thuePhongDAO = new ThuePhongDAO();
            if (phongID == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
            }
            else
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa phòng "+phongID+" này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    
                    var listDatPhong = thuePhongDAO.GetListThuePhong(phongID);
                    if (listDatPhong.Count() != 0)
                    {
                        MessageBox.Show("Phòng đang có đơn thuê phòng. Vui lòng hủy thuê và quay lại!");
                    }
                    else
                    {
                        Phong phong = db.Phongs.Find(phongID);
                        phong.isDelete = true;
                        db.SaveChanges();
                        refreshSoDo();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                }
            }
        }

        private void btnChuyenPhg_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
