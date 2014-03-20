using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupService.Models;

namespace YoupService
{
    class ConvertService
    {
        internal static UserS ToService(User user)
        {
            UserS _user = new UserS
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                GuidFacebook = user.GuidFacebook,
                IsActive = user.IsActive.GetValueOrDefault(),
                Gender = user.Gender,
                Birthday = user.Birthday.GetValueOrDefault(),
                Address = user.Address,
                RankId = user.RankId,
                RoleId = user.RoleId,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                DeletedAt = user.DeletedAt.GetValueOrDefault()
            };

            return _user;
        }

        internal static List<UserS> ToService(List<User> users)
        {
            List<UserS> _users = new List<UserS>();

            foreach (User u in users)
            {
                _users.Add(new UserS()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Password = u.Password,
                    GuidFacebook = u.GuidFacebook,
                    IsActive = u.IsActive.GetValueOrDefault(),
                    Gender = u.Gender,
                    Birthday = u.Birthday.GetValueOrDefault(),
                    Address = u.Address,
                    RankId = u.RankId,
                    RoleId = u.RoleId,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt,
                    DeletedAt = u.DeletedAt.GetValueOrDefault()
                });
            }

            return _users;
        }

        internal static User FromService(UserS user)
        {
            User _user = new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                GuidFacebook = user.GuidFacebook,
                IsActive = user.IsActive,
                Gender = user.Gender,
                Birthday = user.Birthday,
                Address = user.Address,
                RankId = user.RankId,
                RoleId = user.RoleId,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                DeletedAt = user.DeletedAt
            };

            return _user;
        }
    }
}
