//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YoupRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rank
    {
        public Rank()
        {
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string LevelRank { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
