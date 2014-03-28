using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class UserDatabase : IUserDatabase
    {
        public List<User> getUsers()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Users.ToList();
        }

        public User Create(User tpc)
        {
            YoupEntities ye = new YoupEntities();
            //ye.Set<User>().Attach(tpc);
            ye.Users.Add(tpc);
            //ye.Entry(tpc).State = System.Data.EntityState.Added;
            

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(string id)
        {
            YoupEntities ye = new YoupEntities();

            User notDisplay = ye.Users.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                notDisplay.IsActive = 0;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(User tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<User>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public User getUser(string id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Users.Where(c => c.Id == id).SingleOrDefault();
        }

    }
}
