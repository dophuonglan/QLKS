using KS.Common;
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
    public partial class fChucVu : Form
    {
        QLKSEntities2 db = new QLKSEntities2();
        public fChucVu()
        {
            InitializeComponent();
        }

        void refreshForm()
        {
            loadCbbChucVu();
            loadChucVu();
        }

        private void CreateButtonDelete()
        {
            DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
            buttonXoa.Name = "ButtonXoa";
            buttonXoa.HeaderText = "";
            buttonXoa.Text = "X";
            buttonXoa.DefaultCellStyle.Padding = new Padding(2);
            buttonXoa.UseColumnTextForButtonValue = true; //dont forget this line
            buttonXoa.FlatStyle = FlatStyle.Popup;
            buttonXoa.DefaultCellStyle.BackColor = Color.Red;
            dtgvChucVu.Columns.Add(buttonXoa);
        }

        void loadCbbChucVu()
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var listChucVu = chucVuDAO.GetChucVu();
            cbbSuaTenChucVu.DataSource = listChucVu;
            cbbSuaTenChucVu.DisplayMember = "TENCHUCVU";
        }

        void loadCbbToanBoChucVu()
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var listChucVu = chucVuDAO.GetChucVu();
            cbbSuaTenChucVu.DataSource = listChucVu;
            cbbSuaTenChucVu.DisplayMember = "TENCHUCVU";
        }

        void loadChucVu()
        {
            var result =( from c in db.ChucVus
                         select new RowChucVu
                         {
                             MaChucVu= c.MACHUCVU,
                             TenChucVu= c.TENCHUCVU
                         }).ToList();
            dtgvChucVu.DataSource = result;
            loadCbbChucVu();

        }
        private void fLichLamViec_Load(object sender, EventArgs e)
        {
            var topLeftHeaderCell = dtgvChucVu.TopLeftHeaderCell;
            loadChucVu();
            CreateButtonDelete();
        }

        private void btnThemChucVu_Click(object sender, EventArgs e)
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            ChucVu chucVu = new ChucVu();
            chucVu.TENCHUCVU = txbTenChucVuThem.Text;
            if (chucVuDAO.checkExistChucVu(chucVu,1) == false)
            {
                MessageBox.Show("Chức vụ tồn tại");
                return;
            }
            db.ChucVus.Add(chucVu);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công");
            refreshForm();
        }

        private void btnSuaChucVu_Click(object sender, EventArgs e)
        {
            ChucVuDAO chucVuDAO = new ChucVuDAO();
            var chucVu = chucVuDAO.GetChucVuTheoTen(cbbSuaTenChucVu.Text);
            ChucVu sua = db.ChucVus.Find(chucVu.MACHUCVU);
            sua.TENCHUCVU = txbSuaTenChucVu.Text;
            if (chucVuDAO.checkExistChucVu(sua, 2) == false)
            {
                MessageBox.Show("Chức vụ tồn tại");
                return;
            }
            db.SaveChanges();
            refreshForm();
            MessageBox.Show("Sửa thành công");
        }
        void changeChucVu(ChucVu chucVu)
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            var lstNhanVienCanSuaChucVu = db.NhanViens.Where(x => x.MACHUCVU == chucVu.MACHUCVU).ToList();
            if (lstNhanVienCanSuaChucVu != null)
            {
                foreach (var nhanVien in lstNhanVienCanSuaChucVu)
                {
                    nhanVien.MACHUCVU = 3;
                    db.SaveChanges();
                }
            }
        }
        private void dtgvChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //if (MessageBox.Show("Bạn có thật sự muốn xóa chức vụ này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                //{
                    var selectedChucVu = db.ChucVus.Find(((RowChucVu)dtgvChucVu.CurrentRow.DataBoundItem).MaChucVu);
                    if(selectedChucVu.MACHUCVU ==4 || selectedChucVu.MACHUCVU ==5 || selectedChucVu.MACHUCVU == 3)
                    {
                        MessageBox.Show("Không thể xóa chức vụ mặc định");
                        return;
                    }
                    changeChucVu(selectedChucVu);
                    db.ChucVus.Remove(selectedChucVu);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    refreshForm();
                //}
            }
        }

        private void dtgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvChucVu.Rows[e.RowIndex];
                cbbSuaTenChucVu.Text = row.Cells["tenChucVu"].Value.ToString();
            }
        }
    }
}
