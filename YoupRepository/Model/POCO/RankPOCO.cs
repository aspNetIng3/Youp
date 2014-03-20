using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class RankPOCO
    {
        public RankDTO Data { get; set; }
        public RankPOCO() { this.Data = new RankDTO(); }
        public RankPOCO(RankDTO dto)
        {
            this.Data = dto;
        }
    }
}
