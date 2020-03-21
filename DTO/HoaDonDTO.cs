using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class HoaDonDTO
    {
        QLKSEntities2 db = null;
        public HoaDonDTO()
        {
            db = new QLKSEntities2();
        }
        public HoaDon GetHoaDon(int ma)
        {
            return db.HoaDons.Find(ma);
        }
        public List<HoaDon> GetHoaDon()
        {
            return db.HoaDons.ToList() ;
        }
    }
}
