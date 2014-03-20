using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class UserDTO
    {
        public UserDTO()
        {

        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GuidFacebook { get; set; }
        public int IsActive { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int RankId { get; set; }
        public int RoleId { get; set; }
        public string Adress { get; set; }

        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ICollection<BlogDTO> Blogs { get; set; }
        public virtual ICollection<BlogCommentDTO> BlogsComments { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
        public virtual ICollection<EventDTO> Events { get; set; }
        public virtual ICollection<EventCommentDTO> EventComments { get; set; }
        public virtual ICollection<FavoriteDTO> Favorites { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
        public virtual ICollection<PhotoDTO> Photos { get; set; }
        public virtual RankDTO Rank { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
        public virtual RoleDTO Role { get; set; }
        public virtual ICollection<EventDTO> Events1 { get; set; }
        public virtual ICollection<ThemeDTO> Themes { get; set; }
    }
}
