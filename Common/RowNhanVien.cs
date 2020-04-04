using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Common
{
    class RowNhanVien
    {
        private int maNhanVien;
        private string tenNhanVien;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;
        private string tenChucVu;
        private string soDienThoai;

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
    }
}
