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

        bool checkDatPhongHopLe()
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
            if (txbTenkh.Text != "" && txbGioiTinh.Text != "" && txbDiaChi.Text != "" && txbSDT.Text != "" && txbCMT.Text != "") return true;
            return false;
        }

        bool checkThoiGianDatPhongHopLe(DatPhong datPhong, int kind)
        {
            DatPhongDAO datPhongDAO = new DatPhongDAO();
            var datPhg = datPhongDAO.GetDatPhong();
            if (dtPKerNgayVao.Value.Date > dtPKerNgayRa.Value.Date)
            {
                MessageBox.Show("Không được ngày ở > ngày đi");
                return false;
            }
            
            foreach (var phg in datPhg)
            {
                if (kind == 1)
                {
                    if (phg.MAPHONG == Convert.ToInt32(cbbChonPhg.Text))
                    {
                        if ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))
                        {
                            MessageBox.Show("Không được trùng thời gian với đơn đặt cùng phòng");
                            return false;
                        }
                        if (dtPKerNgayVao.Value.Date < DateTime.Today || dtPKerNgayRa.Value.Date < DateTime.Today)
                        {
                            MessageBox.Show("Không được đặt thời gian trong quá khứ");
                            return false;
                        }
                    }
                }
                if (kind == 2)
                {
                    if (phg.MAPHONG == Convert.ToInt32(cbbChonPhg.Text))
                    {
                        if (phg.MADATPHONG == datPhong.MADATPHONG && ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))) continue;
                        if ((dtPKerNgayVao.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayVao.Value.Date <= phg.NGAYDI.Value.Date) || (dtPKerNgayRa.Value.Date >= phg.NGAYO.Value.Date && dtPKerNgayRa.Value.Date <= phg.NGAYDI.Value.Date))
                            return false;
                    }
                }
            }
            return true;
        }

        void loadLoaiPhong()
        {
            LoaiPhongDAO loaiPhongDAO = new LoaiPhongDAO();
            var lstLoaiPhong = loaiPhongDAO.GetLoaiPhong();
            cbbChonLoaiPhg.DataSource = lstLoaiPhong;
            cbbChonLoaiPhg.DisplayMember = "TenLoaiPhong";
        }

        void RefreshForm()
        {
            loadLoaiPhong();
            loadThongTinPhongDangChon();
        }

        void editDatPhong()
        {
            if(dtgvThongTinPhg.RowCount ==0)
            {
                MessageBox.Show("Bạn chưa chọn đơn đặt phòng!!");
                return;
            }
            int id = int.Parse(dtgvThongTinPhg.SelectedCells[0].OwningRow.Cells["maDatPhong"].Value.ToString());
            DatPhong datPhong = db.DatPhongs.Find(id);
            datPhong.MAPHONG = int.Parse(cbbChonPhg.Text);
            datPhong.NGAYO = dtPKerNgayVao.Value.Date;
            datPhong.NGAYDI = dtPKerNgayRa.Value.Date;
            datPhong.GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text);
            datPhong.TRATRUOC = Convert.ToDouble(txbTraTruoc.Text);
            if (checkThoiGianDatPhongHopLe(datPhong, 2) == true)
            {
                if (MessageBox.Show("Bạn có thật sự muốn Sửa đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    db.SaveChanges();
                    loadThongTinPhongDangChon();
                    MessageBox.Show("Sửa thành công");
                }
            }

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
                         && c.isDelete == false
                         && a.TENLOAIPHONG == cbbChonLoaiPhg.Text
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
        }//ok
        void loadThongTinPhongDat()
        {
            var result = (from a in db.Phongs
                          from b in db.LoaiPhongs
                          where a.MALOAIPHONG == b.MALOAIPHONG
                          && b.TENLOAIPHONG == cbbChonLoaiPhg.Text
                          && a.isDelete == false
                          select new
                          {
                              tenPhong = a.MAPHONG.ToString(),
                              giaPhong = a.GIAPHONG
                          }).ToList();
            var lstPhong = phongDAO.GetPhongNotDeleted();
            if (result.Count > 0)
            {
                foreach (var value in result)
                {
                    cbbChonPhg.Items.Add(value.tenPhong);
                }
                cbbChonPhg.Text = result[0].tenPhong;
            }
        }
        void loadThongTinPhongDangChon()
        {
            var result = (from a in db.Phongs
                          from b in db.DatPhongs
                          where a.MAPHONG == b.MAPHONG &&
                          cbbChonPhg.Text == a.MAPHONG.ToString()
                          && b.isDelete == false
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
            var datPhg = datPhongDAO.GetDatPhong();
            KhachHang khachHang = new KhachHang()
            {
                TENKH = txbTenkh.Text,
                GIOITINH = txbGioiTinh.Text,
                NGAYSINH = datimeNgaySinh.Value.Date,
                DIACHI = txbDiaChi.Text,
                SODIENTHOAI = txbSDT.Text,
                CHUNGMINHTHU = txbCMT.Text
            };
            if (checkDatPhongHopLe() == true)
            {
                var kh = khachHangDAO.GetKhachHang(txbCMT.Text);
                DatPhong datPhong;
                datPhong = new DatPhong()
                {
                    //MAPHONG = Convert.ToInt32(cbbChonPhg.Text),
                    //MAKH = null,
                    //TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                    NGAYO = dtPKerNgayVao.Value.Date,
                    NGAYDI = dtPKerNgayRa.Value.Date,
                    TrangThaiThanhToan = "Trả trước 20%",
                    //GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                    isDelete = false
                };

                if (checkThoiGianDatPhongHopLe(datPhong, 1) == true)
                {
                    if (MessageBox.Show("Bạn có thật sự muốn đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        KhachHangDAO khachHangDAO = new KhachHangDAO();
                        if (khachHangDAO.isKhachHangHopLe(khachHang) == false)//ko hop le
                        {
                            MessageBox.Show("CMT hoặc SĐT tồn tại");
                            return;
                        }
                        if (khachHangDAO.isKhachHangTonTai(khachHang) == false)//ko ton tai
                        {
                            db.KhachHangs.Add(khachHang);
                            db.SaveChanges();
                             datPhong = new DatPhong()
                            {
                                MAPHONG = Convert.ToInt32(cbbChonPhg.Text),
                                MAKH = khachHang.MAKH,
                                TRATRUOC = Convert.ToDouble(txbTraTruoc.Text),
                                NGAYO = dtPKerNgayVao.Value.Date,
                                NGAYDI = dtPKerNgayRa.Value.Date,
                                TrangThaiThanhToan = "Trả trước 20%",
                                GiaPhongHienTai = Convert.ToDouble(txbgiaPhong.Text),
                                isDelete = false
                            };
                            db.DatPhongs.Add(datPhong);
                            db.SaveChanges();
                        }
                        else
                        {
                            datPhong = new DatPhong()
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
                            db.SaveChanges();
                        }
                        
                        MessageBox.Show("Đặt phòng thành công", "Thông báo");
                        loadThongTinPhongDangChon();
                    }
                }
            }
        }

        private void fAddNewKH_Load(object sender, EventArgs e)
        {
            loadThongTinPhongDat();
            loadDanhSachPhong();
            RefreshForm();
            CreateButtonDelete();
            dtPKerNgayVao.MinDate = DateTime.Today;
            dtPKerNgayRa.MinDate = DateTime.Today;
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

        private void dtgvThongTinPhg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn có thật sự muốn hủy đặt phòng này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedDatPhong = db.DatPhongs.Find(((RowDatPhong)dtgvThongTinPhg.CurrentRow.DataBoundItem).MaDatPhong);
                    db.DatDichVus.RemoveRange(selectedDatPhong.DatDichVus.ToList());
                    db.DatPhongs.Remove(selectedDatPhong);
                    db.SaveChanges();
                    MessageBox.Show("Hủy thành công");
                    loadThongTinPhongDangChon();
                }
            }
        }

        private void dtPKerNgayRa_ValueChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
        }

        private void dtPKerNgayVao_ValueChanged(object sender, EventArgs e)
        {
            loadTraTruoc();
        }

        private void btnSuaDatPhong_Click(object sender, EventArgs e)
        {
            editDatPhong();
        }

        private void cbbChonLoaiPhg_TextChanged(object sender, EventArgs e)
        {
            loadDanhSachPhong();
        }
    }
}
