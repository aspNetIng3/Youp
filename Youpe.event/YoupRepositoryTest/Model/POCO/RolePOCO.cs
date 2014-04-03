using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;

namespace YoupRepository.Model.POCO
{
    public class RolePOCO
    {
        public RoleDTO data { get; set; }

        public RolePOCO ()
        { this.data = new RoleDTO(); }

        public RolePOCO(RoleDTO roleDTO)
        {
            this.data = roleDTO;
        }
    }
}
