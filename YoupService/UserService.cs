using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupService.Models;

namespace YoupService
{
    public class UserService
    {
        public UserS GetUser(string id)
        {
            UserS user = new UserS();
            YoupData dataContext = new YoupData();

            user = ConvertService.ToService(dataContext.GetUser(id));

            return user;
        }

        public List<UserS> GetUsers()
        {
            List<UserS> users = new List<UserS>();
            YoupData dataContext = new YoupData();

            users = ConvertService.ToService(dataContext.GetUsers());

            return users;
        }

        public void CreateUser(UserS user)
        {
            YoupData dataContext = new YoupData();
            User _user = ConvertService.FromService(user);
            _user.Id = Guid.NewGuid().ToString();
            _user.GuidFacebook = _user.Id;
            _user.CreatedAt = DateTime.Now;
            _user.UpdatedAt = DateTime.Now;
            _user.RankId = 1;
            _user.RoleId = 1;
            _user.IsActive = 1;
            _user.DeletedAt = null;
            dataContext.CreateUser(_user);
        }

        public void EditUser(UserS user)
        {
            YoupData dataContext = new YoupData();
            User _user = ConvertService.FromService(user);

            dataContext.EditUser(_user);
        }

        public void DeleteUser(string id)
        {
            YoupData dataContext = new YoupData();
            dataContext.DeleteUser(id);
        }
    }
}

