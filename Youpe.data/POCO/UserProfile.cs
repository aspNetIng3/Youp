using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Youpe.data.Enums;

namespace Youpe.data.POCO
{
    public class UserProfile : APoco
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GuidFacebook { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public Int64? RankId { get; set; }
        public Int64? RoleId { get; set; }

        [ForeignKey("RankId")]
        public virtual Rank Rank { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public ICollection<BlogComment> BlogComments { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<EventComment> EventComments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Event> Events1 { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}

