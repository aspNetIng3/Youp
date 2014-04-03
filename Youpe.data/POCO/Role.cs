using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Role : APoco
    {
        public string Label { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; }
    }
}
