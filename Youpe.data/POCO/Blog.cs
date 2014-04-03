using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Blog : APocoUser
    {
        public Blog()
            : base()
        {
            this.IsActive = false;
        }

        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
