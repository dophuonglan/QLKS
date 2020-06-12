using System;

namespace KS
{
    internal class SelectThuePhong
    {
        public int MaThuePhong { get; set; }
        public string TenPhong { get; set; }
        public DateTime? NgayO { get; set; }
        public DateTime? NgayDi { get; set; }
        public string TenKhachHang { get; internal set; }
        public DateTime? NgaySinh { get; internal set; }
        public string SoDienThoai { get; internal set; }
    }
}