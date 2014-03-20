using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository
{
    public class YoupData
    {
        private YoupEntities db;

        public YoupData()
        {
            db = new YoupEntities();
        }

        public User GetUser(Guid id)
        {
            return db.Users.Where(u => u.Id == id).Single();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
    }
}
