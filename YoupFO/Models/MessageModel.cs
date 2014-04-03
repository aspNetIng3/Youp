using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoupFo.Models
{
    public class MessageModel
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public int Thread { get; set; }
        public int User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}