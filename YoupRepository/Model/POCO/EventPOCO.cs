using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class EventPOCO
    {
        public EventDTO Data { get; set; }
        public EventPOCO() { this.Data = new EventDTO(); }
        public EventPOCO(EventDTO dto)
        {
            this.Data = dto;
        }
    }
}
