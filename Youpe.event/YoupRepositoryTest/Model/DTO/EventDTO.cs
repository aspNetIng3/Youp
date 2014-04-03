using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO.BaseDTO;

namespace YoupRepository.Model.DTO
{
    public class EventDTO : EventBaseDTO
    {
        public EventDTO ()
        {

        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Slots { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<short> Public { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public Nullable<float> Latitude { get; set; }
        public Nullable<float> Longitude { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public System.DateTime DeleteAt { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<CardDTO> Cards { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual ICollection<EventCommentDTO> EventComments { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }

    }
}
