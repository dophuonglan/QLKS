using System;

namespace KS
{
    internal class ThongTinThanhToanDichVu
    {
        public string TenDichVu { get; set; }
        public int? SoLuong { get; set; }
        public DateTime ngayDung { get; set; }
        public double? giaDichVuHienTai { get; set; }
        public int STT { get; internal set; }
    }
}