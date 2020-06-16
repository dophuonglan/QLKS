using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Common
{
    public class RowDichVu
    {
        private int id;
        private int maDatPhong;
        private int maDV;
        private string tenDV;
        private int? soLuong;
        private DateTime ngayDung;
        private double? giaDV;
        private double? gia;

        public int Id { get => id; set => id = value; }
        public int MaDatPhong { get => maDatPhong; set => maDatPhong = value; }
        public int MaDV { get => maDV; set => maDV = value; }
        public int STT { get; internal set; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public int? SoLuong { get => soLuong; set => soLuong = value; }
        public DateTime NgayDung { get => ngayDung; set => ngayDung = value; }
        public double? GiaDV { get => giaDV; set => giaDV = value; }
        public double? Gia { get => gia; set => gia = value; }
    }
}
