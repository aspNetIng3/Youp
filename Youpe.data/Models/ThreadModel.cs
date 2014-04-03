using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.Models
{
    public class ThreadModel
    {
        public string Title { get; set; }
        public bool? IsSharable { get; set; }
        public Int64? ThemeId { get; set; }
        public Int64? EventId { get; set; }
    }
}
