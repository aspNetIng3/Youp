using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupService;
using YoupFO.Models;
using YoupService.Models;

namespace YoupFO.Controllers
{
    public class ApiUserController : ApiController
    {
        // GET api/apiuser
        public List<User> Get()
        {
            List<User> user = new List<User>();
            UserService userService = new UserService();
            user = ConvertFO.ToFO(userService.GetUsers());

            return user;
        }

        // GET api/apiuser/5
        public User GetUser(Guid id)
        {
            User user = new User();
            UserService userService = new UserService();
            user = ConvertFO.ToFO(userService.GetUser(id));
            
            return user;
        }

        // POST api/apiuser
        public void Post(User user)
        {
            UserS _user = ConvertFO.FromFO(user);
            UserService userService = new UserService();
            userService.CreateUser(_user);   
        }

        // PUT api/apiuser/5
        public void Put(Guid id, User user)
        {

        }

        // DELETE api/apiuser/5
        public void Delete(int id)
        {
        }
    }
}
