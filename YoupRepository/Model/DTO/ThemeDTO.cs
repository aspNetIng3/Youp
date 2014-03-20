using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class ThemeDTO
    {
        public ThemeDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ThemeId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ICollection<EventDTO> Event { get; set; }
        public virtual ICollection<PostDTO> Posts { get; set; }
        public virtual ThemeDTO Theme1 { get; set; }
        public virtual ThemeDTO Theme2 { get; set; }
        public virtual ICollection<ThreadDTO> Threads{ get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
