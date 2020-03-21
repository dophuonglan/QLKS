﻿using System;
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
        public Phong GetPhong(int ma)
        {
            return db.Phongs.Find( ma);
        }
        public Phong GetLoaiPhong(int ma)
        {
            return db.Phongs.SingleOrDefault(x => x.MALOAIPHONG == ma);
        }
    }
}