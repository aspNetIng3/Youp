using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class EventCommentPOCO
    {
        public EventCommentDTO Data { get; set; }
        public EventCommentPOCO() { this.Data = new EventCommentDTO(); }
        public EventCommentPOCO(EventCommentDTO dto)
        {
            this.Data = dto;
        }
    }
}
