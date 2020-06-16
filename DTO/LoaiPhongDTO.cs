using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class LoaiPhongDTO
    {
        private QLKSEntities2 db = null;
        public LoaiPhongDTO()
        {
            db = new QLKSEntities2();
        }
        public List<LoaiPhong> GetLoaiPhong()
        {
            return db.LoaiPhongs.ToList();
        }
        public LoaiPhong GetLoaiPhong(string ten)
        {
            return db.LoaiPhongs.SingleOrDefault(x => x.TENLOAIPHONG == ten);
        }
        public LoaiPhong GetLoaiPhong(int? ma)
        {
            return db.LoaiPhongs.SingleOrDefault(x => x.MALOAIPHONG == ma);
        }

    }
}
