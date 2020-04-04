using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class KhachHangDAO
    {
        private KhachHangDTO khachHangDTO;
        public KhachHangDAO()
        {
            khachHangDTO = new KhachHangDTO();
        }
        public List<KhachHang> GetKhachHang()
        {
            return khachHangDTO.GetKhachHang();
        }
        public KhachHang GetKhachHang(int? ma)
        {
            return khachHangDTO.GetKhachHang(ma);
        }
        public KhachHang GetKhachHang(string cmt)
        {
            return khachHangDTO.GetKhachHang(cmt);
        }
        public bool isKhachHangTonTai(KhachHang kh)
        {
            return khachHangDTO.isKhachHangTonTai(kh);
        }
        public bool isKhachHangHopLe(KhachHang kh)
        {
            return khachHangDTO.isKhachHangHopLe(kh);
        }
    }
}
