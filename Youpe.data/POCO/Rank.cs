using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Rank : APoco
    {
        public string LevelRank { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; }
    }
}
