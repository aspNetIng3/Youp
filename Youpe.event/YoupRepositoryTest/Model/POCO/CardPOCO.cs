using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;

namespace YoupRepository.Model.POCO
{
    public class CardPOCO
    {
        public CardDTO data {get; set;}

        public CardPOCO()
        {
            this.data = new CardDTO();
        }
        public CardPOCO(CardDTO cardDTO)
        {
            this.data = cardDTO;
        }
    }
}
