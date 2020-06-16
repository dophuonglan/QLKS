using System;

namespace KS
{
    internal class ThongTinKhachHangDangThue
    {
        public int STT { get; set; }
        public string TenKH { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string CMT { get; set; }
        public string TenPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public DateTime? NgayNhanPhong { get; set; }
        public DateTime? NgayDi { get; set; }
        public string DichVuSuDung { get; set; }
        public int MaThuePhong { get; internal set; }
        public double? TienPhong { get; internal set; }
    }
}