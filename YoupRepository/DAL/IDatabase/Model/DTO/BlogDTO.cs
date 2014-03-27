using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class BlogDTO
    {
        public BlogDTO()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int IsActive { get; set; }

        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual UserDTO User { get; set; }
        public virtual ICollection<PostDTO> Posts { get; set; }
    }
}
