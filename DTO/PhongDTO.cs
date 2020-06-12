using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class PhongDTO
    {
        private QLKSEntities2 db = null;
        public PhongDTO()
        {
            db = new QLKSEntities2();
        }
        public List<Phong> GetPhong()
        {
            return db.Phongs.ToList();
        }
        public List<Phong> GetPhongNotDeleted()
        {
            return db.Phongs.Where(x => x.isDelete == false).ToList();
        }
        public Phong GetPhong(int ma)
        {
            return db.Phongs.Find( ma);
        }
        public Phong GetPhong(string name)
        {
            return db.Phongs.Single(x=>x.TENPHONG ==name);
        }
        public Phong GetLoaiPhong(int ma)
        {
            return db.Phongs.SingleOrDefault(x => x.MALOAIPHONG == ma);
        }
    }
}
