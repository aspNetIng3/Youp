using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public interface IRoleDatabase
    {
        List<Role> getRoles();
        Role getRole(int roleID);
        Role CreateRole(Role role);
        Boolean UpdateRole(Role roleUpc);
    }
}
