using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Visibility { get; set; }
        public Int64? ThemeId { get; set; }
        public Int64? BlogId { get; set; }
    }
}
