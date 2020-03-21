using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class TaiKhoanDAO
    {
        private TaiKhoanDTO taiKhoanDTO;
        public TaiKhoanDAO()
        {
            taiKhoanDTO = new TaiKhoanDTO();
        }
        public TaiKhoan GetTaiKhoan(string tenTaiKhoan)
        {
            return taiKhoanDTO.GetTaiKhoan(tenTaiKhoan);
        }
    }
}
