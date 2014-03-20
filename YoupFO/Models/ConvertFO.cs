using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupService.Models;

namespace YoupFO.Models
{
    public class ConvertFO
    {
        internal static User ToFO(UserS user)
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

        internal static List<User> ToFO(List<UserS> users)
        {
            List<User> _users = new List<User>();

            foreach (UserS u in users)
            {
                _users.Add(new User()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Password = u.Password,
                    GuidFacebook = u.GuidFacebook,
                    IsActive = u.IsActive,
                    Gender = u.Gender,
                    Birthday = u.Birthday,
                    Address = u.Address,
                    RankId = u.RankId,
                    RoleId = u.RoleId,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt,
                    DeletedAt = u.DeletedAt
                });
            }

            return _users;
        }
    }
}

