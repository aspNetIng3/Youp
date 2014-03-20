using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoupFO.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public String UserName { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public Guid GuidFacebook { get; set; }

        public bool IsActive { get; set; }

        public Char Gender { get; set; }

        public DateTime Birthday { get; set; }

        public String Address { get; set; }

        public int RankId { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}