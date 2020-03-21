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
    public partial class fLogin : Form
    {
        private TaiKhoanDAO taiKhoanDAO;
        public fLogin()
        {
            InitializeComponent();
            taiKhoanDAO = new TaiKhoanDAO();
        }

        static public int maChucVu { get; private set; }
        static public int MaNhanVien { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = taiKhoanDAO.GetTaiKhoan(txbUserName.Text);
            if (user == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông Báo");
            }
            else
            {
                if (txbPass.Text != user.PASS)
                {
                    MessageBox.Show("Sai mật khẩu!", "Thông Báo");
                }
                else
                {
                    maChucVu = Convert.ToInt32(user.MACHUCVU);
                    MaNhanVien = Convert.ToInt32(user.MANHANVIEN);
                    fSoDo fMain = new fSoDo();
                    this.Hide();
                    fMain.ShowDialog();
                    this.Show();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
