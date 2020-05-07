using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        static public string tenDN;
        string maHoaPass(string pass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (var item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            var user = taiKhoanDAO.GetTaiKhoan(txbUserName.Text);
            if (user == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông Báo");
            }
            else
            {
                if (maHoaPass(txbPass.Text)!= user.PASS)
                {
                    MessageBox.Show("Sai mật khẩu!", "Thông Báo");
                }
                else
                {
                    maChucVu = Convert.ToInt32(user.MACHUCVU);
                    MaNhanVien = Convert.ToInt32(user.MANHANVIEN);
                    tenDN = user.TENTAIKHOAN;
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

        private void txbPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txbUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbPass.Focus();
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel) 
            //    != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
