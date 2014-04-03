using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Models
{
    public class EventFO
    {
         public EventFO()
        {
            this.Card = new HashSet<CardFO>();
            this.EventComment = new HashSet<EventCommentModel>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public int Slots { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<short> Public { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int ThemeId { get; set; }
        public string Address { get; set; }
        public Nullable<float> Lattitude { get; set; }
        public Nullable<float> Longitude { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual ICollection<CardFO> Card { get; set; }
        public virtual UserFO User { get; set; }
        public virtual ICollection<EventCommentModel> EventComment { get; set; }
        
    }
}