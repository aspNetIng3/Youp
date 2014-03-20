using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.DAL;

namespace YoupRepository
{
    public class YoupData
    {
        private UserDatabase db;

        public YoupData()
        {
            db = new UserDatabase();
        }

        public User GetUser(string id)
        {
            return db.getUser(id);
        }

        public List<User> GetUsers()
        {
            return db.getUsers();
        }

        public void CreateUser(User user)
        {
            db.Create(user);
        }

        public void EditUser(User user)
        {
            db.Update(user);
        }

        public void DeleteUser(string id)
        {
            db.Delete(id);
        }
    }
}
