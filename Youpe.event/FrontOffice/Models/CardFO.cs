using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Models
{
    public class CardFO
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual EventFO Event { get; set; }
        public virtual UserFO User { get; set; }
    }
}