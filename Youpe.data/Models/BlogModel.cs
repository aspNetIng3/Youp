using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.Models
{
    public class BlogModel
    {
        public BlogModel()
        {
            this.IsActive = false;
        }

        public long? Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
