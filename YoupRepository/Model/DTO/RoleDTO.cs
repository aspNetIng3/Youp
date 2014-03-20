using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class RoleDTO
    {
        public RoleDTO()
        {

        }

        public int Id { get; set; }
        public string Label { get; set; }

        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
