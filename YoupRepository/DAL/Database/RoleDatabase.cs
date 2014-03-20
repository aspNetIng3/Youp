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
            YoupEntities ye = new YoupEntities();

            return ye.Roles.ToList();
        }

        public Role Create(Role tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Roles.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Role notDisplay = ye.Roles.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Role tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Role>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Role getRole(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Roles.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
