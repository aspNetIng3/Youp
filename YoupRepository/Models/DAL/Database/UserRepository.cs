using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DAL.Database
{
    class UserRepository
    {
        public User[] GetAllUsers()
        {
            return new User[]
           {
               new User
               {
                   Id = (int) Guid.NewGuid(),
                   UserName = "Test"
               },
               new User
               {
                   Id = Guid.NewGuid(),
                   UserName = "Toto"
               }
           };
        }
    }
}
