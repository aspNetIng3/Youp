using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DTO;

namespace YoupRepository.Models.POCO
{
    public class EventPOCO
    {
        private EventDTO Data {get;set;}

        public EventPOCO()
        {
            Data = new EventDTO();
        }
    }
}
