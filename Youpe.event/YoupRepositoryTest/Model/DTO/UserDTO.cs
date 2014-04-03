using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO.BaseDTO;


namespace YoupRepository.Model.DTO
{
    public class UserDTO : UserBaseDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GuidFacebook { get; set; }
        public Nullable<short> IsActive { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Adress { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<CardDTO> Card { get; set; }
        public virtual ICollection<EventDTO> Events { get; set; }
        public virtual ICollection<EventCommentDTO> EventComment { get; set; }
        public virtual RoleDTO Role { get; set; }
        public virtual ICollection<EventDTO> Events1 { get; set; }

    }
}
