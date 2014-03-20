using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IRoleDatabase
    {
        List<Role> getRoles();

        Role Create(Role tpc);

        bool Delete(int id);

        bool Update(Role tpc);

        Role getRole(int id);
    }
}
