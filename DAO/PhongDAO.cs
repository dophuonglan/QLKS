using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class PhongDAO
    {
        private PhongDTO phongDTO;
        public PhongDAO()
        {
            phongDTO = new PhongDTO();
        }
        public List<Phong> GetPhong()
        {
            return phongDTO.GetPhong();
        }
        public Phong GetPhong(int id)
        {
            return phongDTO.GetPhong(id);
        }
        public Phong GetLoaiPhong(int ma)
        {
            return phongDTO.GetLoaiPhong(ma);
        }
        public static int btnWidth = 130;
        public static int btnHeight = 130;
    }
}
