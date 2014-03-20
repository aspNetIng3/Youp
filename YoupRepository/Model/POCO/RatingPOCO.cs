using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class RatingPOCO
    {
        public RatingDTO Data { get; set; }
        public RatingPOCO() { this.Data = new RatingDTO(); }
        public RatingPOCO(RatingDTO dto)
        {
            this.Data = dto;
        }
    }
}
