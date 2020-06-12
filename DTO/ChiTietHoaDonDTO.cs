using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    class ChiTietHoaDonDTO
    {
        private QLKSEntities2 db;
        ChiTietHoaDonDTO()
        {
            db = new QLKSEntities2();
        }
        public ChiTietHoaDon GetChiTietHoaDon(int maThuePhong)
        {
            return db.ChiTietHoaDons.SingleOrDefault(x => x.MATHUEPHONG == maThuePhong);
        }
    }
}
