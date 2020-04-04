using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class DatPhongDTO
    {
        private QLKSEntities2 db = null;
        public DatPhongDTO()
        {
            db = new QLKSEntities2();
        }
        public List<DatPhong> GetDatPhong()
        {
            return db.DatPhongs.Where(x => x.isDelete == false).ToList();
        }
        public DatPhong GetDatPhong(int ma)
        {
            return db.DatPhongs.Find( ma);
        }
        public List<DatPhong> GetListDatPhong(int maPhong)
        {
            return db.DatPhongs.Where(x => x.isDelete == false && x.MAPHONG ==maPhong).ToList();
        }
        //public DatPhong GetDatPhongg(int ma)
        //{
        //    return db.DatPhongs.Find(x => x.MADATPHONG == ma);
        //}
    }
}
