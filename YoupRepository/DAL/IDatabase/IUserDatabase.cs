using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IUserDatabase
    {
        List<User> getUsers();

        User Create(User tpc);

        bool Delete(string id);

        bool Update(User tpc);

        User getUser(string id);
    }
}
