using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupService.Models
{
    public class UserS
    {
        public Guid Id { get; set; }

        public String UserName { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public Guid GuidFacebook { get; set; }

        public bool IsActive { get; set; }

        public String Gender { get; set; }

        public DateTime Birthday { get; set; }

        public String Address { get; set; }

        public int RankId { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public String ResetPasswordToken { get; set; }
        public DateTime ResetTokenSentAt { get; set; }
    }
}
