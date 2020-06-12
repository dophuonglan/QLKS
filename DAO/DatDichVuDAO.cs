using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class DatDichVuDAO
    {
        private DatDichVuDTO datDichVuDTO = null;
        public DatDichVuDAO()
        {
            datDichVuDTO = new DatDichVuDTO();
        }
        public List<DatDichVu> GetDatDichVu()
        {
            return datDichVuDTO.GetDatDichVu();
        }
        public DatDichVu GetDatDichVu(int maDP, int maDV, DateTime ngayDung)
        {
            return datDichVuDTO.GetDatDichVu(maDP, maDV, ngayDung);
        }

        public void Remove(int maThuePhong)
        {
            datDichVuDTO.Remove(maThuePhong);
        }
        public DatDichVu GetDatDichVu(int ma)
        {
            return datDichVuDTO.GetDatDichVu(ma);
        }
        public List<DatDichVu> GetListDatDichVu(int id)
        {
            return datDichVuDTO.GetListDatDichVu(id);
        }
        public DatDichVu GetDatDichVu(DateTime ngay)
        {
            return datDichVuDTO.GetDatDichVu(ngay);
        }
    }
}
