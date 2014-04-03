using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Thread : APoco
    {

        public string Title { get; set; }
        public bool? IsSharable { get; set; }
        public Int64? ThemeId { get; set; }
        public Int64? EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        [ForeignKey("ThemeId")]
        public virtual Theme Theme { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        
    }
}
