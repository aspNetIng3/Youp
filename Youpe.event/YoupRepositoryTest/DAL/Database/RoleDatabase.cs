using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class RoleDatabase : IRoleDatabase
    {

        public List<Role> getRoles()
        {
            YoupEntities context = new YoupEntities();
            return context.Roles.ToList();
        }
        public Role getRole(int roleID)
        {
            YoupEntities context = new YoupEntities();
            return context.Roles.Where(c => c.Id == roleID).SingleOrDefault();

        }
        public Role CreateRole(Role role)
        {
            YoupEntities context = new YoupEntities();
            context.Roles.Add(role);
            if (context.SaveChanges() == 1)
                return role;
            return null;

        }
        public Boolean UpdateRole(Role roleUpc)
        {
            YoupEntities context = new YoupEntities();
            context.Entry(roleUpc).State = System.Data.Entity.EntityState.Modified;
            if (context.SaveChanges() == 1)
                return true;
            return false;
        }
    }
}
