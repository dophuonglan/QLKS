using KS.Common;
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
    public partial class fDatPhong : Form
    {
        fPhong f = new fPhong();
        QLKSEntities2 db = new QLKSEntities2();
        PhongDAO phongDAO = null;
        DatPhongDAO datPhongDAO = null;
        KhachHangDAO khachHangDAO = null;

        public fDatPhong()
        {
            InitializeComponent();
            phongDAO = new PhongDAO();
            khachHangDAO = new KhachHangDAO();
            datPhongDAO = new DatPhongDAO();
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
            dtgvThongTinPhg.Columns.Add(buttonXoa);
        }
        void loadDanhSachPhong()
        {
            var result = from c in db.Phongs
                         from a in db.LoaiPhongs

                         where c.MALOAIPHONG == a.MALOAIPHONG
                         select new
                         {
                             c.MAPHONG,
                             c.TENPHONG,
                             c.TINHTRANGPHONG,
                             a.TENLOAIPHONG,
                             c.GIAPHONG,
                             c.DONVITIENTE
                         };
            dtgvDSPhg.DataSource = result.ToList();
        }

        void loadThongTinPhongDat()
        {
            var result = (from a in db.Phongs
                          from b in db.LoaiPhongs
                          where a.MALOAIPHONG == b.MALOAIPHONG
                          && b.TENLOAIPHONG == cbbChonLoaiPhg.Text
                          select new
                          {
                              tenPhong = a.MAPHONG.ToString(),
                              giaPhong = a.GIAPHONG
                          }).ToList();
            var lstPhong = phongDAO.GetPhong();
            if (result.Count > 0)
            {
                foreach (var value in result)
                {
                    cbbChonPhg.Items.Add(value.tenPhong);
                }
                cbbChonPhg.Text = result[0].tenPhong;
            }
            dtPKerNgayVao.MinDate = DateTime.Today;
            dtPKerNgayRa.MinDate = DateTime.Today;
        }
        void loadThongTinPhongDangChon()
        {
            var result = (from a in db.Phongs
                          from b in db.DatPhongs
                          where a.MAPHONG == b.MAPHONG &&
                          cbbChonPhg.Text == a.MAPHONG.ToString()
                          && b.isDelete ==false
                          select new RowDatPhong
                          {
                              MaDatPhong = b.MADATPHONG,
                              MaPhong = a.MAPHONG,
                              TenPhong = a.TENPHONG,
                              GiaPhong = a.GIAPHONG,
                              NgayO = b.NGAYO,
                              NgayDi = b.NGAYDI,
                          }).ToList();
            ngayO.DefaultCellStyle.Format = "dd/MM/yyyy";
            ngayDi.DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvThongTinPhg.DataSource = result;
        }

        private void btnDatPhg_Click(object sender, EventArgs e)
        {
            if (txbTenkh.Text == "") lbtenkh.Visible = true;
            else lbtenkh.Visible = false;
            if (txbGioiTinh.Text == "") lbgioitinh.Visible = true;
            else lbgioitinh.Visible = false;
            if (txbDiaChi.Text == "") lbdiachi.Visible = true;
            else lbdiachi.Visible = false;
            if (txbSDT.Text == "") lbSDT.Visible = true;
            else lbSDT.Visible = false;
            if (txbCMT.Text == "") lbCMT.Visible = true;
            else lbCMT.Visible = false;
            if (cbbChonLoaiPhg.Text == "") lbChonLoaiPhong.Visible = true;
            else lbChonLoaiPhong.Visible = false;
            if (cbbChonPhg.Text == "") lbChonPhong.Visible = true;
            else lbChonPhong.Visible = false;
            var datPhg = datPhongDAO.GetDatPhong();
            if (cbbChonPhg.Text != "" && cbbChonLoaiPhg.Text != "" && txbTenkh.Text != "" && txbGioiTinh.Text != "" && txbDiaChi.Text != "" && txbSDT.Text != "" && txbCMT.Text != "")
            {
                foreach (var phg in datPhg)
                {
                    if (phg.MAPHONG == Convert.ToInt32(cbbChonPhg.Text)){
                        if((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date)|| (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))
                        {
                            MessageBox.Show("Đặt ko thành công!Trùng thời gian ", "Thông Báo");
                            return;
                        }
                    }
                }
            }
            if (txbTenkh.Text != "" && txbGioiTinh.Text != "" && txbDiaChi.Text != "" && txbSDT.Text != "" && txbCMT.Text != "")
            {
                if(dtPKerNgayVao.Value.Date > dtPKerNgayRa.Value.Date)
                {
                    MessageBox.Show("Không thành công! Ngày ở sau ngày đi");
                }
                else if (MessageBox.Show("Bạn có thật sự muốn đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    KhachHang khachHang = new KhachHang()
                    {
                        TENKH = txbTenkh.Text,
                        GIOITINH = txbGioiTinh.Text,
                        NGAYSINH = datimeNgaySinh.Value.Date,
                        DIACHI = txbDiaChi.Text,
                        SODIENTHOAI = txbSDT.Text,
                        CHUNGMINHTHU = txbCMT.Text
                    };
                    if (db.KhachHangs.SingleOrDefault(x => x.CHUNGMINHTHU == khachHang.CHUNGMINHTHU) == null)
                    {
                        db.KhachHangs.Add(khachHang);
                        db.SaveChanges();
                    }
                    var kh = khachHangDAO.GetKhachHang(txbCMT.Text);
                    DatPhong datPhong = new DatPhong()
                    {
                        MAPHONG = Convert.ToInt32(cbbChonPhg.Text),
                        MAKH = kh.MAKH,
                        TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                        NGAYO = dtPKerNgayVao.Value.Date,
                        NGAYDI = dtPKerNgayRa.Value.Date,
                        TrangThaiThanhToan = "Trả trước 20%",
                        GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                        isDelete = false
                    };
                    db.DatPhongs.Add(datPhong);
                    MessageBox.Show("Đặt phòng thành công", "Thông báo");
                    db.SaveChanges();
                    loadThongTinPhongDangChon();
                }
            }
        }

        private void fAddNewKH_Load(object sender, EventArgs e)
        {
            cbbChonLoaiPhg.Text = "Tiêu Chuẩn";
            cbbChonPhg.Items.Clear();
            loadThongTinPhongDat();
            loadThongTinPhongDangChon();
            loadDanhSachPhong();
            CreateButtonDelete();
            
        }

        private void txbSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var result = (from c in db.KhachHangs
                              where c.SODIENTHOAI == txbSDT.Text
                              select new
                              {
                                  MaKH = c.MAKH,
                                  TenKH = c.TENKH,
                                  GioiTinh = c.GIOITINH,
                                  NgaySinh = c.NGAYSINH,
                                  DiaChi = c.DIACHI,
                                  SDT = c.SODIENTHOAI,
                                  CMT = c.CHUNGMINHTHU
                              }).ToList();
                if (result.Count != 0)
                {
                    txbTenkh.Text = result.SingleOrDefault().TenKH;
                    txbCMT.Text = result.SingleOrDefault().CMT;
                    txbDiaChi.Text = result.SingleOrDefault().DiaChi;
                    txbGioiTinh.Text = result.SingleOrDefault().GioiTinh;
                    datimeNgaySinh.Value = result.SingleOrDefault().NgaySinh.Value;
                }
                else
                {
                    MessageBox.Show("Khách hàng chưa đăng kí thông tin");
                }
            }
        }

        private void cbbChonLoaiPhg_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbChonPhg.Items.Clear();
            loadThongTinPhongDat();
        }
        void loadTraTruoc()
        {
            int maphg = int.Parse(cbbChonPhg.Text);
            var phong = phongDAO.GetPhong(maphg);
            
            var tongNgayo = (dtPKerNgayRa.Value.Date - dtPKerNgayVao.Value.Date).TotalDays;
            if (tongNgayo < 0) MessageBox.Show("Chọn ngày ở <ngày đi");
            else
            {
                if (tongNgayo == 0) tongNgayo = 0.5;
                txbgiaPhong.Text = (phong.GIAPHONG * tongNgayo).ToString();
                txbTraTruoc.Text = (phong.GIAPHONG * tongNgayo * 0.2).ToString();
            }
        }
        private void cbbChonPhg_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
            dtgvThongTinPhg.DataBindings.Clear();
            loadThongTinPhongDangChon();
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dtgvThongTinPhg_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dtgvThongTinPhg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //ham tim theo id hoac object, ham sua , ham xoa reomve theo list object hoac remomve theo object
                var selectedDatPhong = db.DatPhongs.Find(((RowDatPhong)dtgvThongTinPhg.CurrentRow.DataBoundItem).MaDatPhong);
                db.DatDichVus.RemoveRange(selectedDatPhong.DatDichVus.ToList());
                db.DatPhongs.Remove(selectedDatPhong);
                db.SaveChanges();
                MessageBox.Show("remove success");
                loadThongTinPhongDangChon();
            }
        }

        private void dtPKerNgayRa_ValueChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
        }

        private void fDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.loadSoDoPhong();
        }

        private void dtPKerNgayVao_ValueChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
        }
    }
}
