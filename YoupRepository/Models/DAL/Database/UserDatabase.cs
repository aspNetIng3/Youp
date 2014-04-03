using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;

namespace YoupRepository.Models.DAL.Database
{
    public class UserDatabase : IUserDatabase
    {
        public List<Users> GetUsers()
        {
            var sle = new YoupEntities();
            return sle.Users.ToList();
        }

        public List<Events> GetUserEvents(string id)
        {
            var sle = new YoupEntities();
            var user = sle.Users.Where(u => u.Id.Equals(id)).SingleOrDefault();
            if (user == null)
            {
                return new List<Events>();
            }
            return user.Events.ToList();
        }
    }
}
