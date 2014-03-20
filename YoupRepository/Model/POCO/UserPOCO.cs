using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class UserPOCO
    {
        public UserDTO Data { get; set; }
        public UserPOCO() { this.Data = new UserDTO(); }
        public UserPOCO(UserDTO dto)
        {
            this.Data = dto;
        }
    }
}
