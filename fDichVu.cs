using KS.Common;
using KS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS
{
    public partial class fDichVu : Form
    {
        QLKSEntities2 db = null;
        DatPhongDAO datPhongDAO = null;
        DichVuDAO dichVuDAO = null;
        DatDichVuDAO datDichVuDAO = null;
        public fDichVu()
        {
            InitializeComponent();
            datPhongDAO = new DatPhongDAO();
            dichVuDAO = new DichVuDAO();
            db = new QLKSEntities2();
            datDichVuDAO = new DatDichVuDAO();
        }

        void tinhTienDichVu()
        {
            DichVu dichVuSelected = (DichVu)cbbTenDichVu.SelectedItem;
            txbTienDV.Text = (Convert.ToInt32(numSoLuong.Value) * dichVuSelected.GIADV).ToString();
        }

        void loadThongTinDatDichVu()
        {
            var result = (from c in db.DatDichVus
                          from a in db.DichVus
                          where c.MADV == a.MADV
                          && c.MADATPHONG.ToString() == cbbMaDP.Text
                          select new RowDichVu
                          {
                              Id = c.Id,
                              MaDatPhong = c.MADATPHONG,
                              MaDV = c.MADV,
                              TenDV = a.TENDV,
                              SoLuong = c.SoLuong,
                              NgayDung = c.ngayDung,
                              GiaDV = a.GIADV,
                              Gia = c.giaDichVuHienTai,
                          }).ToList();
            ngayDung.DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvThongTinDatDichVu.DataSource = result;
            double tongTien = 0;
            foreach (var item in result)
            {
                tongTien += item.Gia.Value;
            }
            lbTongTienDichVu.Text = tongTien + " VNĐ";
        }
        void loadDichVu()
        {
            var lstDichVu = dichVuDAO.GetDichVu();
            cbbTenDichVu.DataSource = lstDichVu;
            cbbTenDichVu.DisplayMember = "TENDV";
            cbbTenDV_Sua.DataSource = lstDichVu;
            cbbTenDV_Sua.DisplayMember = "TENDV";
        }
        void loadCacBox()
        {
            var lstDatphg = datPhongDAO.GetDatPhong();
            if (lstDatphg.Count != 0)
            {
                cbbMaDP.Text = lstDatphg[0].MADATPHONG.ToString();
                var datPhong = datPhongDAO.GetDatPhong(Convert.ToInt32(cbbMaDP.Text));
                dtpkNgayDi.Value = datPhong.NGAYDI.Value;
                dtpkNgayO.Value = datPhong.NGAYO.Value;
                txbmaPhong.Text = datPhong.MAPHONG.ToString();
            }
            
        }
        void loadTenDV_CapNhatDV()
        {
            DichVu dichVuSelected = (DichVu)cbbTenDV_Sua.SelectedItem;
            txbDonGia_Sua.Text = dichVuSelected.GIADV.ToString();
        }

        DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
        private void CreateButtonDelete()
        {
            buttonXoa.Name = "ButtonXoa";
            buttonXoa.HeaderText = "Hủy";
            buttonXoa.Text = "X";
            buttonXoa.DefaultCellStyle.Padding = new Padding(2);
            buttonXoa.UseColumnTextForButtonValue = true; //dont forget this line
            buttonXoa.FlatStyle = FlatStyle.Popup;
            buttonXoa.DefaultCellStyle.BackColor = Color.Red;
            this.dtgvThongTinDatDichVu.Columns.Add(buttonXoa);
        }

        private void fDichVu_Load(object sender, EventArgs e)
        {
            var lstDatphg = datPhongDAO.GetDatPhong();
            cbbMaDP.DataSource = lstDatphg;
            cbbMaDP.DisplayMember = "MADATPHONG";
            dtpkNgayDung.Value = DateTime.Today;
            loadDichVu();
            loadCacBox();
            loadThongTinDatDichVu();
            CreateButtonDelete();
            //CreateButtonEdit();
        }

        private void cbbMaDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatPhong DPSelected = (DatPhong)cbbMaDP.SelectedItem;
            var datPhong = datPhongDAO.GetDatPhong(DPSelected.MADATPHONG);//////////
            dtpkNgayDi.Value = datPhong.NGAYDI.Value;
            dtpkNgayO.Value = datPhong.NGAYO.Value;
            txbmaPhong.Text = datPhong.MAPHONG.ToString();
            dtgvThongTinDatDichVu.DataBindings.Clear();
            loadThongTinDatDichVu();
        }

        private void cbbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhTienDichVu();
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            tinhTienDichVu();
        }

        private void refreshForm()
        {
            loadDichVu();
            loadCacBox();
            loadThongTinDatDichVu();
        }

        private void btnDatDV_Click(object sender, EventArgs e)
        {
            var lstDichVu = dichVuDAO.GetDichVu();

            if (numSoLuong.Value == 0)
            {
                lbThongBaoChonSoLg.Visible = true;
            }
            else
            {
                lbThongBaoChonSoLg.Visible = false;
                var dichVu = dichVuDAO.GetDichVu(cbbTenDichVu.Text);//lay dichvu co ten xac dinh
                int ma = dichVu.MADV;// madv đang dc dat
                DatDichVu datDV = null;
                int slgThem = Convert.ToInt32(numSoLuong.Value);
                double giaThem = Convert.ToDouble(txbTienDV.Text);
                foreach (var datdv in db.DatDichVus.ToList())
                {
                    if (datdv.MADATPHONG.ToString() == cbbMaDP.Text && datdv.MADV == ma && datdv.ngayDung.Date == dtpkNgayDung.Value.Date)
                    {
                        datdv.SoLuong = slgThem + datdv.SoLuong;
                        datdv.giaDichVuHienTai = datdv.giaDichVuHienTai + giaThem;
                        MessageBox.Show("Thêm thành công!");
                        db.SaveChanges();
                        loadThongTinDatDichVu();
                        return;
                    }
                    continue;
                }
                datDV = new DatDichVu();
                datDV.MADATPHONG = Convert.ToInt32(cbbMaDP.Text);
                datDV.SoLuong = Convert.ToInt32(numSoLuong.Value);
                datDV.ngayDung = dtpkNgayDung.Value;
                datDV.giaDichVuHienTai = Convert.ToDouble(txbTienDV.Text);
                datDV.MADV = dichVu.MADV;
                db.DatDichVus.Add(datDV);
                db.SaveChanges();
                MessageBox.Show("Đặt thành công!");
                loadThongTinDatDichVu();
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (txbThemTenDV.Text == "") lbThongBaoTenDV.Visible = true;
            else lbThongBaoTenDV.Visible = false;
            if (txbThemDonGia.Text == "") lbThongBaoGiaDV.Visible = true;
            else lbThongBaoGiaDV.Visible = false;
            if (txbThemTenDV.Text != "" && txbThemDonGia.Text != "")
            {
                if (IsNumber(txbThemDonGia.Text))
                {
                    if (db.DichVus.SingleOrDefault(x => x.TENDV == txbThemTenDV.Text) != null)
                    {
                        MessageBox.Show("Dịch vụ đã tồn tại");
                        return;
                    }
                    DichVu dichVuMoi = new DichVu();
                    dichVuMoi.TENDV = txbThemTenDV.Text;
                    dichVuMoi.GIADV = Convert.ToDouble(txbThemDonGia.Text);
                    db.DichVus.Add(dichVuMoi);
                    db.SaveChanges();
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                }
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (txbDonGia_Sua.Text != "")
            {
                if (IsNumber(txbDonGia_Sua.Text))
                {
                    var DV = dichVuDAO.GetDichVu(cbbTenDichVu.Text);
                    DichVu dichVu = db.DichVus.SingleOrDefault(x => x.MADV == DV.MADV);
                    dichVu.GIADV = Convert.ToDouble(txbDonGia_Sua.Text);
                    db.SaveChanges();
                    refreshForm();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                }
            }
        }

        private void cbbTenDV_Sua_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTenDV_CapNhatDV();
        }


        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            DichVu dichVuSelected = (DichVu)cbbTenDV_Sua.SelectedItem;
            db.DichVus.Remove(db.DichVus.Single(x => x.MADV == dichVuSelected.MADV));
            db.SaveChanges();
            refreshForm();
            MessageBox.Show("Xóa dịch vụ " + dichVuSelected.TENDV + " thành công!");
        }

        private void dtgvThongTinDatDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var selectedDatDV = ((RowDichVu)dtgvThongTinDatDichVu.CurrentRow.DataBoundItem);
                if (MessageBox.Show("Bạn có chắc chắm muốn hủy không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    datDichVuDAO.Remove(selectedDatDV.Id);
                    MessageBox.Show("Hủy thành công","Thông báo");
                    loadThongTinDatDichVu();
                }
            }
        }

        private bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private void txbThemDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txbThemDonGia.Text == "")
            {
                lbThongBaoGiaDV.Visible = true;
                lbThongBao2.Visible = false;
            }
            else if (!IsNumber(txbThemDonGia.Text))
            {
                lbThongBaoGiaDV.Visible = false;
                lbThongBao2.Visible = true;
            }
            else
            {
                lbThongBaoGiaDV.Visible = false;
                lbThongBao2.Visible = false;
            }
        }

        private void txbDonGia_Sua_TextChanged(object sender, EventArgs e)
        {
            if (txbDonGia_Sua.Text == "")
            {
                lbSuaGiaDV.Visible = true;
                lbThongBaoSua2.Visible = false;
            }
            else if (!IsNumber(txbDonGia_Sua.Text))
            {
                lbSuaGiaDV.Visible = false;
                lbThongBaoSua2.Visible = true;
            }
            else
            {
                lbSuaGiaDV.Visible = false;
                lbThongBaoSua2.Visible = false;
            }
        }
    }
}
