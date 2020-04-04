using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class DichVuDTO
    {
        private QLKSEntities2 db = null;
        public DichVuDTO()
        {
            db = new QLKSEntities2();
        }
        public List<DichVu> GetDichVu()
        {
            return db.DichVus.Where(x => x.isDelete == false).ToList();
        }
        public DichVu GetDichVu(int ma)
        {
            return db.DichVus.Find(ma);
        }
        public DichVu GetDichVu(string tendv)
        {
            return db.DichVus.SingleOrDefault(x => x.TENDV == tendv);
        }

        public List<DichVu> GetDichVus(string tendv)
        {
            return db.DichVus.Where(x=>x.TENDV.Contains(tendv) == true).ToList();
        }
    }
}
