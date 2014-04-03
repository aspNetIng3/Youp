using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO.BaseDTO;

namespace YoupRepository.Model.DTO
{
    public class CardDTO : CardBaseDTO
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }

        public virtual EventDTO Event { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
