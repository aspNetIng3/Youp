//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YoupRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Card
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
