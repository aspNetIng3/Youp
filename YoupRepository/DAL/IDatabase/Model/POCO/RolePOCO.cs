using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class RolePOCO
    {
        public RoleDTO Data { get; set; }
        public RolePOCO() { this.Data = new RoleDTO(); }
        public RolePOCO(RoleDTO dto)
        {
            this.Data = dto;
        }
    }
}
