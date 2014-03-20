using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class EventCommentDTO
    {
        public EventCommentDTO()
        {

        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual EventDTO Event { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
