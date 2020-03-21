using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class NhanVienDTO
    {
        private QLKSEntities2 db;
        public NhanVienDTO()
        {
            db = new QLKSEntities2();
        }
        public NhanVien GetNhanVien(int maNhanVien)
        {
            return db.NhanViens.SingleOrDefault(x => x.MANHANVIEN == maNhanVien);
        }
    }
}
