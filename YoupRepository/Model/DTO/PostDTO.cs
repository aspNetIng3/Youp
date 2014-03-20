using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class PostDTO
    {
        public PostDTO()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Visibility { get; set; }
        public int ThemeId { get; set; }
        public int BlogId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual BlogDTO Blog { get; set; }
        public virtual ICollection<BlogCommentDTO> BlogComments { get; set; }
        public virtual ThemeDTO Theme { get; set; }
    }
}
