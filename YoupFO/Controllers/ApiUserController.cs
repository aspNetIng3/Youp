using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupService;
using YoupFO.Models;
using YoupService.Models;
using WebMatrix.WebData;

namespace YoupFO.Controllers
{
    public class ApiUserController : ApiController
    {
        // GET api/apiuser
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public List<User> Get()
        {
            List<User> user = new List<User>();
            UserService userService = new UserService();
            user = ConvertFO.ToFO(userService.GetUsers());

            return user;
        }

        // GET api/apiuser/{id}
        /// <summary>
        /// Get one user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(string id)
        {
            User user = new User();
            UserService userService = new UserService();
            user = ConvertFO.ToFO(userService.GetUser(id));
            
            return user;
        }

        // POST api/apiuser
        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        public void Post(User user)
        {
            UserS _user = ConvertFO.FromFO(user);
            UserService userService = new UserService();
            userService.CreateUser(_user);   
        }

        // PUT api/apiuser/5
        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        public void Put(Guid id, User user)
        {
            UserS _user = ConvertFO.FromFO(user);
            UserService userService = new UserService();

            userService.EditUser(_user);
        }

        // DELETE api/apiuser/5
        /// <summary>
        /// Delte a User
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            UserService userService = new UserService();
            userService.DeleteUser(id);
        }

        public void Auth(String username, String password)
        {            
        }
    }
}
