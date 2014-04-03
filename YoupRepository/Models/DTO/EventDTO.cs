using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL;

namespace YoupRepository.Models.DTO
{
    public class EventDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Slots { get; set; }
        public double Cost { get; set; }
        public short Public { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int ThemeId { get; set; }
        public string Address { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public System.DateTime DeletedAt { get; set; }
    }
}
