using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public interface IUserDatabase
    {
        List<User> GetUsers();
        User GetUser(String userID);
        User Create(User user);
        Boolean Delete(String userID);
        Boolean Update(User userUpc);
    }
}