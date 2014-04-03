using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Theme : APoco
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Int64? ThemeId { get; set; }

        [ForeignKey("ThemeId")]
        public virtual Theme ThemeMy { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
        public virtual ICollection<UserProfile> Users { get; set; }
    }
}
