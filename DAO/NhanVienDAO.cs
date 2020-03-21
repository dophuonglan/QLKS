using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class NhanVienDAO
    {
        private NhanVienDTO NhanVienDTO;
        public NhanVienDAO()
        {
            NhanVienDTO = new NhanVienDTO();
        }
        public NhanVien GetNhanVien(int maNhanVien)
        {
            return NhanVienDTO.GetNhanVien(maNhanVien);
        }
    }
}
