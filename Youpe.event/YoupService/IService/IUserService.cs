using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.POCO;

namespace YoupService
{
    public interface IUserService
    {
        List<UserPOCO> getAllUsers();
        UserPOCO getUser(string userID);
        bool updateUser(UserPOCO userUPC);
    }
}
