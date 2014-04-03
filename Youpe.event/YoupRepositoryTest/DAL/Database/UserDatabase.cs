using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;

namespace YoupRepository.DAL
{
    public class UserDatabase : IUserDatabase
    {
        public List<User> GetUsers()
        {
            YoupEntities context = new YoupEntities();
            return context.Users.ToList();
        }
        public User GetUser(String userID)
        {
            YoupEntities context = new YoupEntities();
            return context.Users.Where(c => c.Id == userID).SingleOrDefault();

        }
        public User Create(User user)
        {
            YoupEntities context = new YoupEntities();
            context.Users.Add(user);
            if(context.SaveChanges() == 1)
            {
                return user;
            }
            return null;
        }
        public Boolean Delete(String userID)
        {
            YoupEntities context = new YoupEntities();
            User userToRemove = this.GetUser(userID);
            if(userToRemove != null)
            {
                context.Users.Remove(userToRemove);
                if(context.SaveChanges() == 1)
                    return true;
            }
            return false;
        }
        public Boolean Update(User userUpc)
        {
            YoupEntities context = new YoupEntities();
            context.Entry(userUpc).State = System.Data.Entity.EntityState.Modified;
            if(context.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
