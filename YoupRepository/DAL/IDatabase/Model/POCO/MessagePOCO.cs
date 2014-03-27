using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class MessagePOCO
    {
        public MessageDTO Data { get; set; }
        public MessagePOCO() { this.Data = new MessageDTO(); }
        public MessagePOCO(MessageDTO dto)
        {
            this.Data = dto;
        }
    }
}
