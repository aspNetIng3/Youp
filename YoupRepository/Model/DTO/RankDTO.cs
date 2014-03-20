using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.Model
{
    public class RankDTO
    {
        public RankDTO()
        {
        }

        public int Id { get; set; }
        public string LevelRank { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
