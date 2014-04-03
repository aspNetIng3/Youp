using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;

namespace YoupRepository.Model.POCO
{
    public class EventPOCO
    {
        public EventDTO data { get; set; }

        public EventPOCO ()
        { this.data = new EventDTO(); }

        public EventPOCO (EventDTO eventDTO)
        {
            this.data = eventDTO;
        }
    }
}
