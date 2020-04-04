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

        bool checkExistSuaLichLam(LichLamViec lichLamViec)
        {
            foreach (var x in db.LichLamViecs)
            {
                if (x.MANHANVIEN == lichLamViec.MANHANVIEN && x.NGAYLAMVIEC == lichLamViec.NGAYLAMVIEC && x.BUOI == lichLamViec.BUOI && x.MALICHLAMVIEC == lichLamViec.MALICHLAMVIEC) continue;
                if (x.MANHANVIEN == lichLamViec.MANHANVIEN && x.NGAYLAMVIEC == lichLamViec.NGAYLAMVIEC && x.BUOI == lichLamViec.BUOI) return false;
            }
            return true;
        }

        bool checkExistThemLichLam(LichLamViec lichLamViec)
        {
            foreach (var x in db.LichLamViecs)
            {
                if (x.MANHANVIEN == lichLamViec.MANHANVIEN && x.NGAYLAMVIEC == lichLamViec.NGAYLAMVIEC && x.BUOI == lichLamViec.BUOI) return false;
            }
            return true;
        }

        public bool checkExistLichLam(LichLamViec lichLamViec, int type)
        {
            if (type == 1)
            {
                if (checkExistThemLichLam(lichLamViec) == true) return true;
            }
            if (type == 2)
            {
                if(checkExistSuaLichLam(lichLamViec)==true) return true;
            }
            return false;
        }
        public void Remove(int id)
        {
            var lich = db.LichLamViecs.Find(id);
            db.LichLamViecs.Remove(lich);
        }
        public LichLamViec GetLichLamViec(String ma)
        {
            return db.LichLamViecs.SingleOrDefault(x => x.MANHANVIEN.ToString() == ma);
        }
    }
}
