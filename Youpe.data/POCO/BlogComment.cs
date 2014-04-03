using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class BlogComment : APocoUser
    {
        public string Content { get; set; }
        public Int64? PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
