using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Models
{
    public class RoleFO
    {
        public RoleFO()
        {
            this.User = new HashSet<UserFO>();
        }
    
        public int Id { get; set; }
        public string Label { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual ICollection<UserFO> User { get; set; }
    }
    
}