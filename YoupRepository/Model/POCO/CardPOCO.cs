using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class CardPOCO
    {
        public CardDTO Data { get; set; }
        public CardPOCO() { this.Data = new CardDTO(); }
        public CardPOCO(CardDTO dto)
        {
            this.Data = dto;
        }
    }
}
