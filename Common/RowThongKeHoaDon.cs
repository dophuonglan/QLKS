using System;

namespace KS.Common
{
    class RowThongKeHoaDon
    {
        public int STT { get; internal set; }
        public int MaHD { get; internal set; }
        public DateTime? NgayThanhToan { get; internal set; }
        public string TenKH { get; internal set; }
        public string SoDienThoai { get; internal set; }
        public DateTime? NgayO { get; internal set; }
        public DateTime? NgayDi { get; internal set; }
        public double? TienDV { get; internal set; }
        public double? TienPhong { get; internal set; }
        public double? TongTien { get; internal set; }
        public string TenPhong { get; internal set; }
        public string DichVuSuDung { get; internal set; }
        public int MaThuePhong { get; internal set; }
        
    }
}
