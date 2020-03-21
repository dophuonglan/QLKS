using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class LichLamViecDTO
    {
        private QLKSEntities2 db = null;
        public LichLamViecDTO()
        {
            db = new QLKSEntities2();
        }
        public List<LichLamViec> GetLichLamViec()
        {
            return db.LichLamViecs.ToList();
        }
        public LichLamViec GetLichLamViec(String ma)
        {
            return db.LichLamViecs.SingleOrDefault(x => x.MANHANVIEN.ToString() == ma);
        }
    }
}
