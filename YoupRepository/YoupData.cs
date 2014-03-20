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
            return db.Users.SingleOrDefault(u => u.Id == id && u.IsActive == 1);
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void EditUser(Guid id, User user)
        {
            User _user = db.Users.SingleOrDefault(u => u.Id == id);
            _user.UserName = user.UserName;
            _user.Email = user.Email;
            _user.Password = user.Password;
            _user.GuidFacebook = user.GuidFacebook;
            _user.IsActive = user.IsActive;
            _user.Gender = user.Gender;
            _user.Birthday = user.Birthday;
            _user.Address = user.Address;
            _user.RankId = user.RankId;
            _user.RoleId = user.RoleId;
            _user.CreatedAt = user.CreatedAt;
            _user.UpdatedAt = DateTime.Now;
            _user.DeletedAt = user.DeletedAt;
            db.SaveChanges();

        }

        public void DeleteUser(Guid id)
        {
            User user = db.Users.SingleOrDefault(u => u.Id == id);
            user.DeletedAt = DateTime.Now;
            user.IsActive = 0;
            db.SaveChanges();
        }
    }
}
