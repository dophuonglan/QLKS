using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class TaiKhoanDTO
    {
        private QLKSEntities2 db;
        public TaiKhoanDTO()
        {
            db = new QLKSEntities2();
        }
        public TaiKhoan GetTaiKhoan(string tenTaiKhoan)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TENTAIKHOAN == tenTaiKhoan &&x.isBan ==false);
        }
        public TaiKhoan GetTaiKhoanAll(string tenTaiKhoan)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TENTAIKHOAN == tenTaiKhoan);
        }
        public TaiKhoan GetTaiKhoan(int maTK)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.MANHANVIEN == maTK);
        }
        public void CapNhatTKCuaNhanVien(NhanVien nhanVien)
        {
            foreach (var tk in db.TaiKhoans)
            {
                if(tk.MANHANVIEN == nhanVien.MANHANVIEN)
                {
                    tk.MACHUCVU = nhanVien.MACHUCVU;
                }
            }
            db.SaveChanges();
        }
    }
}
