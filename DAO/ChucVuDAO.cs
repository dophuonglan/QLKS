using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    class ChucVuDAO
    {
        ChucVuDTO chucVuDTO = null;
        public ChucVuDAO()
        {
            chucVuDTO = new ChucVuDTO();
        }
        public ChucVu GetChucVuTheoTen(string ten)
        {
            return chucVuDTO.GetChucVuTheoTen(ten);
        }

        public ChucVu GetChucVuTheoMa(int? ma)
        {
            return chucVuDTO.GetChucVuTheoMa(ma);
        }
    
        public bool checkExistChucVu(ChucVu chucVu, int type)
        {
            return chucVuDTO.checkExistChucVu(chucVu, 1);
        }
        public List<ChucVu> GetChucVu()
        {
            return chucVuDTO.GetChucVu();
        }
        public List<ChucVu> GetChucVuTruQuanLy()
        {
            return chucVuDTO.GetChucVuTruQuanLy();
        }
    }
}
