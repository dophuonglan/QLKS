using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Common
{
    class RowLichLamViec
    {
        private int maLichLamViec;
        private int maNhanVien;
        private string tenNhanVien;
        private DateTime ngayLamViec;
        private string buoi;

        public int MaLichLamViec { get => maLichLamViec; set => maLichLamViec = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public DateTime NgayLamViec { get => ngayLamViec; set => ngayLamViec = value; }
        public string Buoi { get => buoi; set => buoi = value; }
        
    }
}
