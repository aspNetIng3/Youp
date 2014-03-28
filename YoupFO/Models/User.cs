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

        [Display(Name = "Nom d'utilisateur")]
        [Required(ErrorMessage = "Le nom est requis")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Le mail est requis")]
        [Display(Name = "Email")]
        [RegularExpression("[a-zA-Z0-9\\.\\-_]+@[a-zA-Z0-9\\.\\-_]+\\.[a-zA-Z]+", ErrorMessage = "Le format de l'email est incorrect")]
        public String Email { get; set; }

        [Display(Name = "Vérification de l'email")]
        [Compare("Email", ErrorMessage = "Les deux mots de mails doivent être les mêmes.")]
        public String EmailVerif { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est requis")]
        public String Password { get; set; }

        [Display(Name = "vérification mot de passe")]
        [Compare("Password", ErrorMessage = "Les deux mots de passe doivent être les mêmes.")]
        public String PasswordVerif { get; set; }

        public Guid GuidFacebook { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Sexe")]
        [Required(ErrorMessage = "Le sexe est requis")]
        public String Gender { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est requis")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Adresse")]
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