using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupFO.Models;
using YoupService;
using YoupService.Models;

namespace YoupFO.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            UserService service = new UserService();
            IEnumerable<UserS> userSs = service.GetUsers();
            List<User> users = new List<User>();
            foreach (UserS userS in userSs)
            {
                users.Add(ConvertFO.ToFO(userS));
            }
            return View(users);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(string id)
        {
            UserService service = new UserService();
            UserS userS = service.GetUser(id);
            User user = ConvertFO.ToFO(userS);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                User user = new User()
                {
                    UserName = collection["UserName"],
                    Password = collection["Password"],
                    Email = collection["Email"],
                    Address = collection["Address"],
                    Birthday = DateTime.Parse(collection["Birthday"]),
                    Gender = collection["Gender"]
                };
                UserService service = new UserService();
                UserS userS = YoupFO.Models.ConvertFO.FromFO(user);
                service.CreateUser(userS);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(string id)
        {
            UserService service = new UserService();
            UserS userS = service.GetUser(id);
            Models.User user = Models.ConvertFO.ToFO(userS);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                User user = new User()
                {
                    UserName = collection["UserName"],
                    Password = collection["Password"],
                    Email = collection["Email"],
                    Address = collection["Address"],
                    Birthday = DateTime.Parse(collection["Birthday"]),
                    Gender = collection["Gender"]
                };
                UserService service = new UserService();
                UserS userS = YoupFO.Models.ConvertFO.FromFO(user);
                service.EditUser(userS);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(Guid id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                UserService service = new UserService();
                service.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
