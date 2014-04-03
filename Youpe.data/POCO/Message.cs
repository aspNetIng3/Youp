using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Message : APocoUser
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Int64? ThreadId { get; set; }

        [ForeignKey("ThreadId")]
        public Thread Thread { get; set; }
    }
}
