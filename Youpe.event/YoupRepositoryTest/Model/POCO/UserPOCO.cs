using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;

namespace YoupRepository.Model.POCO
{
    public class UserPOCO
    {
        public UserDTO data { get; set; }

        public UserPOCO() { this.data = new UserDTO(); }

        public UserPOCO(UserDTO userDTO)
        {
            this.data = userDTO;
        }
    }
}
