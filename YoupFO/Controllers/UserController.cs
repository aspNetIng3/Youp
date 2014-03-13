using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupFO.Models;

namespace YoupFO.Controllers
{
    public class UserController : ApiController
    {
        public User[] Get()
        {
            return new User[]
           {
               new User
               {
                   Id = Guid.NewGuid(),
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
