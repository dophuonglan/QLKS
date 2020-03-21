using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DTO
{
    public class DatDichVuDTO
    {
        private QLKSEntities2 db = null;
        public DatDichVuDTO()
        {
            db = new QLKSEntities2();
        }
        public void Remove(int id)
        {
            var datDichVuFound = db.DatDichVus.Find(id);
            db.DatDichVus.Remove(datDichVuFound);
            db.SaveChanges();
        }
        public List<DatDichVu> GetDatDichVu()
        {
            return db.DatDichVus.ToList();
        }

        public DatDichVu GetDatDichVu(int maDP, int maDV, DateTime ngayDung)
        {
            return db.DatDichVus.SingleOrDefault(x => x.MADATPHONG == maDP && x.MADV == maDV && x.ngayDung == ngayDung);
        }

        public DatDichVu GetDatDichVu(int id)
        {
            return db.DatDichVus.Find(id);
        }
        public List<DatDichVu> GetListDatDichVu(int ma)
        {
            List<DatDichVu> lst = new List<DatDichVu>();
            foreach (var datDichVu in db.DatDichVus)
            {
                if(datDichVu.MADATPHONG == ma)
                {
                    lst.Add(datDichVu);
                }
            }
            return lst;
        }
        public DatDichVu GetDatDichVu(DateTime ngay)
        {
            return db.DatDichVus.FirstOrDefault(x => x.ngayDung == ngay);
        }
    }
}
