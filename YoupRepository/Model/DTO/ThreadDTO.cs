using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.DAL;

namespace YoupRepository.Model
{
    public class ThreadDTO : ThreadBaseDTO
    {
        public ThreadDTO()
        {
            this.Favorites = new HashSet<FavoriteDTO>();
            this.Messages = new HashSet<MessageDTO>();
        }

        public ThreadDTO(string title, int themeId, string eventId) {
            Title = title;
            ThemeId = themeId;
            EventId = eventId;
        }

        public ThreadDTO(string title, int themeId, string eventId, ICollection<MessageDTO> messages) 
        {
            Title = title;
            ThemeId = themeId;
            EventId = eventId;
        }
            
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<short> IsSharable { get; set; }
        public int ThemeId { get; set; }
        public string EventId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual EventDTO Event { get; set; }
        public virtual ICollection<FavoriteDTO> Favorites { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
        public virtual ThemeDTO Theme { get; set; }
    }
}
