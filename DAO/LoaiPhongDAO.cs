using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class LoaiPhongDAO
    {
        private LoaiPhongDTO phongDTO;
        public LoaiPhongDAO()
        {
            phongDTO = new LoaiPhongDTO();
        }
        public List<LoaiPhong> GetLoaiPhong()
        {
            return phongDTO.GetLoaiPhong();
        }
        public LoaiPhong GetLoaiPhong(string ten)
        {
            return phongDTO.GetLoaiPhong(ten);
        }
        public LoaiPhong GetLoaiPhong(int? ma)
        {
            return phongDTO.GetLoaiPhong(ma);
        }
    }
}
