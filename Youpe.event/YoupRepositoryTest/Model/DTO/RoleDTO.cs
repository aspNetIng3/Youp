using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO.BaseDTO;


namespace YoupRepository.Model.DTO
{
    public class RoleDTO : RoleBaseDTO
    {

        public int Id { get; set; }
        public string Label { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
