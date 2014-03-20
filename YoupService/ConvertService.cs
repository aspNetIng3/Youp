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
    }
}
