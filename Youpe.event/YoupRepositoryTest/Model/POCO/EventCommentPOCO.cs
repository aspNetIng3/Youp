using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;

namespace YoupRepository.Model.POCO
{
    public class EventCommentPOCO
    {
        public EventCommentDTO data { get; set; }

        public EventCommentPOCO() { 
            this.data = new EventCommentDTO();
        }

        public EventCommentPOCO(EventCommentDTO eventCommentDTO)
        {
            this.data = eventCommentDTO;
        }
    }
}
