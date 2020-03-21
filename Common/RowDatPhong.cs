using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Common
{
    public class RowDatPhong
    {
        //b.MADATPHONG,
        //                      a.MAPHONG,
        //                      a.TENPHONG,
        //                      a.GIAPHONG,
        //                      b.NGAYO,
        //                      ngayDi = b.NGAYDI,
        private int maDatPhong;
        private int maPhong;
        private string tenPhong;
        private double? giaPhong;
        private DateTime? ngayO;
        private DateTime? ngayDi;

        public int MaDatPhong { get => maDatPhong; set => maDatPhong = value; }
        public int MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public double? GiaPhong { get => giaPhong; set => giaPhong = value; }
        public DateTime? NgayO { get => ngayO; set => ngayO = value; }
        public DateTime? NgayDi { get => ngayDi; set => ngayDi = value; }
    }
}
