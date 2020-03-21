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
            List<DatPhong> lst = new List<DatPhong>();
            foreach (var dp in db.DatPhongs)
            {
                if (dp.isDelete == false)
                {
                    lst.Add(dp);
                }
            }
            return lst;
        }
        public DatPhong GetDatPhong(int ma)
        {
            return db.DatPhongs.Find( ma);
        }
        public List<DatPhong> GetListDatPhong(int maPhong)
        {
            List<DatPhong> lst = new List<DatPhong>();
            foreach (var dphong in db.DatPhongs)
            {
                if(dphong.isDelete == false)
                {
                    if (dphong.MAPHONG == maPhong)
                    {
                        lst.Add(dphong);
                    }
                }
                
            }
            return lst;
        }
        //public DatPhong GetDatPhongg(int ma)
        //{
        //    return db.DatPhongs.Find(x => x.MADATPHONG == ma);
        //}
    }
}
