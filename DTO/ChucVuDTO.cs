using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    class ChucVuDTO
    {
        QLKSEntities2 db = null;
        public ChucVuDTO()
        {
            db = new QLKSEntities2();
        }
        public ChucVu GetChucVuTheoTen(string ten)
        {
            return db.ChucVus.SingleOrDefault(x => x.TENCHUCVU == ten);
        }
        public List<ChucVu> GetChucVu()
        {
            return db.ChucVus.ToList();
        }

        public List<ChucVu> GetChucVuTruQuanLy()
        {
            List<ChucVu> lst = new List<ChucVu>();
            foreach (var chucVu in db.ChucVus)
            {
                if (chucVu.MACHUCVU == 5) continue;
                lst.Add(chucVu);
            }
            return lst;
        }

        bool checkExistSuaChucVu(ChucVu chucVu)
        {
            foreach (var x in db.ChucVus)
            {
                if (x.TENCHUCVU == chucVu.TENCHUCVU && x.MACHUCVU == chucVu.MACHUCVU) continue;
                if (x.TENCHUCVU != chucVu.TENCHUCVU) return true;
            }
            return false;
        }
        public bool checkExistChucVu(ChucVu chucVu, int type)
        {
            if(type == 1)
            {
                if (db.ChucVus.SingleOrDefault(x => x.TENCHUCVU == chucVu.TENCHUCVU) == null) return true;
            }
            if (type == 2)
            {
                if (checkExistSuaChucVu(chucVu) == true) return true;
            }
            return false;
        }
        public ChucVu GetChucVuTheoMa(int? ma)
        {
            return db.ChucVus.SingleOrDefault(x => x.MACHUCVU == ma);
        }
    }
}
