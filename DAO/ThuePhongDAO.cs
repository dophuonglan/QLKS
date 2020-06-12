using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    class ThuePhongDAO
    {
        private ThuePhongDTO thuePhongDTO = null;
        public ThuePhongDAO()
        {
            thuePhongDTO = new ThuePhongDTO();
        }
        public List<ThuePhong> GetThuePhong()
        {
            return thuePhongDTO.GetThuePhong();
        }
        public List<ThuePhong> GetListThuePhong(int maPhong)
        {
            return thuePhongDTO.GetListThuePhong(maPhong);
        }
        public ThuePhong GetThuePhong(int ma)
        {
            return thuePhongDTO.GetThuePhong(ma);
        }
    }
}
