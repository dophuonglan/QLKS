using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    class ThuePhongDTO
    {
        private QLKSEntities2 db = null;
        public ThuePhongDTO()
        {
            db = new QLKSEntities2();
        }
        public List<ThuePhong> GetThuePhong()
        {
            return db.ThuePhongs.Where(x => x.isDelete == false).ToList();
        }
        public ThuePhong GetThuePhong(int ma)
        {
            return db.ThuePhongs.Find(ma);
        }
        public List<ThuePhong> GetListThuePhong(int maPhong)
        {
            return db.ThuePhongs.Where(x => x.isDelete == false && x.MAPHONG == maPhong).ToList();
        }
    }
}
