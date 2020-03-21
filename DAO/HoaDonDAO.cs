using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class HoaDonDAO
    {
        private HoaDonDTO hoaDonDTO=null;
        public HoaDonDAO()
        {
            hoaDonDTO = new HoaDonDTO();
        }
        public HoaDon GetHoaDon(int ma)
        {
            return hoaDonDTO.GetHoaDon(ma);
        }

        public List<HoaDon> GetHoaDon()
        {
            return hoaDonDTO.GetHoaDon();
        }
    }
}
