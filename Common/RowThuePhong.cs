using System;

namespace KS
{
    internal class RowThuePhong
    {
        public int STT { get; set; }
        public int MaThuePhong { get; set; }
        public string TenPhong { get; internal set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public double? GiaPhong { get; set; }
        public DateTime? NgayO { get; set; }
        public DateTime? NgayDi { get; set; }
        
    }
}