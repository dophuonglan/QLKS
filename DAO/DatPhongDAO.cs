using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class DatPhongDAO
    {
        private DatPhongDTO datPhongDTO = null;
        public DatPhongDAO()
        {
            datPhongDTO = new DatPhongDTO();
        }
        public List<DatPhong> GetDatPhong()
        {
            return datPhongDTO.GetDatPhong();
        }
        public List<DatPhong> GetDatPhongCoDatPhongTre()
        {
            return datPhongDTO.GetDatPhongCoDatPhongTre();
        }
        public List<DatPhong> GetListDatPhong(int maPhong)
        {
            return datPhongDTO.GetListDatPhong(maPhong);
        }
        public DatPhong GetDatPhong(int ma)
        {
            return datPhongDTO.GetDatPhong(ma);
        }
        //public DatPhong GetDatPhongg(int ma)
        //{
        //    return datPhongDTO.GetDatPhongg(ma);
        //}
    }
}
