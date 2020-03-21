using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class DichVuDAO
    {
        private DichVuDTO dichVuDTO = null;
        public DichVuDAO()
        {
            dichVuDTO = new DichVuDTO();
        }
        public List<DichVu> GetDichVu()
        {
            return dichVuDTO.GetDichVu();
        }
        public DichVu GetDichVu(int ma)
        {
            return dichVuDTO.GetDichVu(ma);
        }
        public DichVu GetDichVu(string tendv)
        {
            return dichVuDTO.GetDichVu(tendv);
        }
        public List<DichVu> GetDichVus(string tendv)
        {
            return dichVuDTO.GetDichVus(tendv);
        }
    }
}
