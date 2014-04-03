using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Rating : APocoUser
    {
        public int? Rate { get; set; }
        public string Comment { get; set; }
        public Int64? EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
