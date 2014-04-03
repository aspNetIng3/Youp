using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Post : APoco
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Visibility { get; set; }
        public Int64? ThemeId { get; set; }
        public Int64? BlogId { get; set; }

        public virtual ICollection<BlogComment> BlogComments { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }

        [ForeignKey("ThemeId")]
        public Theme Theme { get; set; }
    }
}
