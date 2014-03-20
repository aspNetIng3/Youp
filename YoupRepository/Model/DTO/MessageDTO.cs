using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class MessageDTO
    {
        public MessageDTO()
        {
        }
        public MessageDTO(string title, string content, int threadId)
        {
            Title = title;
            Content = content;
            ThreadId = threadId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ThreadDTO Thread { get; set; }
        public virtual UserDTO User { get; set; }
        
    }
}
