using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DAL.IDatabase
{
    public interface IUserDatabase
    {
        List<Users> GetUsers();
        List<Events> GetUserEvents(string id);
    }
}
