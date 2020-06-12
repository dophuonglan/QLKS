using System;

namespace KS
{
    internal class QuanLyPhong
    {
        internal int maThuePhong;
        internal int maPhong;

        public double TongSoNgayO { get; set; }
        public DateTime? NgayO { get; internal set; }
        public DateTime? NgayDi { get; internal set; }
        public double? TienPhong { get; internal set; }
    }
}