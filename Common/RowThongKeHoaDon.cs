using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Common
{
    class RowThongKeHoaDon
    {
        private int maHD;
        private DateTime? ngayThanhToan;
        private string tenKH;
        private string soDienThoai;
        private DateTime? ngayO;
        private DateTime? ngayDi;
        private double? tienDV;
        private double? tienPhong;
        private double? tongTien;

        public int MaHD { get => maHD; set => maHD = value; }
        public DateTime? NgayThanhToan { get => ngayThanhToan; set => ngayThanhToan = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime? NgayO { get => ngayO; set => ngayO = value; }
        public DateTime? NgayDi { get => ngayDi; set => ngayDi = value; }
        public double? TienDV { get => tienDV; set => tienDV = value; }
        public double? TienPhong { get => tienPhong; set => tienPhong = value; }
        public double ?TongTien { get => tongTien; set => tongTien = value; }
    }
}
