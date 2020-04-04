using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{

    public class KhachHangDTO
    {
        private QLKSEntities2 db;
        public KhachHangDTO()
        {
            db = new QLKSEntities2();
        }
        //public List<KhachHang> GetKhachHang(string sdt)
        //{
        //    var result = from c in db.KhachHangs
        //                 where c.SODIENTHOAI.Contains(txbTimKiem.Text)
        //                 //&& c.MAPHONG == id
        //                 select new
        //                 {
        //                     MaKH = c.MAKH,
        //                     TenKH = c.TENKH,
        //                     GioiTinh = c.GIOITINH,
        //                     NgaySinh = c.NGAYSINH,
        //                     DiaChi = c.DIACHI,
        //                     SDT = c.SODIENTHOAI,
        //                     CMT = c.CHUNGMINHTHU
        //                 };
        //    return = result.ToList();
        //}
        public List<KhachHang> GetKhachHang()
        {
            return db.KhachHangs.ToList();
        }
        public KhachHang GetKhachHang(int? ma)
        {
            return db.KhachHangs.SingleOrDefault(x => x.MAKH == ma);
        }
        public KhachHang GetKhachHang(string cmt)
        {
            return db.KhachHangs.SingleOrDefault(x => x.CHUNGMINHTHU == cmt);
        }
        public bool isKhachHangTonTai(KhachHang kh)
        {
            if (db.KhachHangs.SingleOrDefault(x=>x.TENKH == kh.TENKH && x.CHUNGMINHTHU ==kh.CHUNGMINHTHU)!= null)
            {
                return true;
            }
            if(db.KhachHangs.SingleOrDefault(x => x.TENKH == kh.TENKH && x.SODIENTHOAI == kh.SODIENTHOAI) != null)
            {
                return true;
            }
            return false;
        }
        public bool isKhachHangHopLe(KhachHang kh)
        {
            if (db.KhachHangs.SingleOrDefault(x => x.TENKH != kh.TENKH && x.CHUNGMINHTHU == kh.CHUNGMINHTHU) != null)
            {
                return false; //ten khac , cmt giong
            }
            if (db.KhachHangs.SingleOrDefault(x => x.TENKH != kh.TENKH && x.SODIENTHOAI == kh.SODIENTHOAI) != null)
            {
                return false; //ten khac , sdt giong
            }
            if (db.KhachHangs.SingleOrDefault(x => x.TENKH == kh.TENKH && x.SODIENTHOAI == kh.SODIENTHOAI &&
            x.CHUNGMINHTHU != kh.CHUNGMINHTHU) != null)
            {
                return false;//ten giong , sdt giong , cmt khac
            }
            
            return true;
        }
    }
}
