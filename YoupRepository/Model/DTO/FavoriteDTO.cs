using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class FavoriteDTO
    {
        public FavoriteDTO()
        {
        }

        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ThreadDTO Thread { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
