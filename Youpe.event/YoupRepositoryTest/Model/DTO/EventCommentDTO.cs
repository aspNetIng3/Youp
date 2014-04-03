using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO.BaseDTO;


namespace YoupRepository.Model.DTO
{
    public class EventCommentDTO : EventCommentBaseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public Nullable<System.DateTime> deletedAt { get; set; }
        public string EventId { get; set; }
        public string UserId { get; set; }

        public virtual EventDTO Event { get; set; }
        public virtual UserDTO user { get; set; }
    }
}
