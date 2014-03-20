using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YoupFO.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Le mail est requis")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))
	            ([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Le format de l'email est incorrect")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        public String Password { get; set; }

        public Guid GuidFacebook { get; set; }

        public short IsActive { get; set; }

        [Required(ErrorMessage = "Le sexe est requis")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "La date de naissance est requis")]
        public DateTime Birthday { get; set; }

        public String Address { get; set; }

        public int RankId { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}