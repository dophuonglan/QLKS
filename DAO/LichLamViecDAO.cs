using KS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DAO
{
    public class LichLamViecDAO
    {
        private LichLamViecDTO lichLamViecDTO;
        public LichLamViecDAO()
        {
            lichLamViecDTO = new LichLamViecDTO();
        }
        public List<LichLamViec> GetLichLamViec()
        {
            return lichLamViecDTO.GetLichLamViec();
        }
        public LichLamViec GetLichLamViec(String id)
        {
            return lichLamViecDTO.GetLichLamViec(id);
        }
    }
}
