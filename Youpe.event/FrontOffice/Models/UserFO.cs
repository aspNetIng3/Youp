using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Models
{
    public class UserFO
    {
        public UserFO()
        {
            this.Card = new HashSet<CardFO>();
            this.Event = new HashSet<EventFO>();
            this.EventComment = new HashSet<EventCommentModel>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GuidFacebook { get; set; }
        public Nullable<short> IsActive { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public int RankId { get; set; }
        public int RoleId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ICollection<CardFO> Card { get; set; }
        public virtual ICollection<EventFO> Event { get; set; }
        public virtual ICollection<EventCommentModel> EventComment { get; set; }
        public virtual RoleFO Role { get; set; }
    }
}