using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class EventDTO : EventBaseDTO
    {
        public EventDTO()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Slots { get; set; }
        public double Cost { get; set; }
        public int Public { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int ThemeId { get; set; }
        public string Address { get; set; }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public string City { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
        public virtual ThemeDTO Theme { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual ICollection<EventCommentDTO> EventComments { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
        public virtual ICollection<ThreadDTO> Threads { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
