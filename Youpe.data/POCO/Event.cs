using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    public class Event : APocoUser
    {
        public string Name { get; set; }
        public int Slots { get; set; }
        public Nullable<double> Cost { get; set; }
        public bool? Public { get; set; }
        public string Description { get; set; }
        public Int64? ThemeId { get; set; }
        public string Address { get; set; }
        public float? Lattitude { get; set; }
        public float? Longitude { get; set; }

        
        [ForeignKey("ThemeId")]
        public Theme Themes { get; set; }

        public ICollection<Card> Cards { get; set; }
        public ICollection<EventComment> EventComments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Thread> Threads { get; set; }
        //public ICollection<UserProfile> Users1 { get; set; }
    }
}
