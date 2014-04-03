using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupFO.Models;
using YoupService;
using YoupService.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;

namespace YoupFO.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            UserService service = new UserService();
            
            if (!service.isAuthenticate(Session["User"]))
                return Redirect("/");
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
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //hash du password
                    user.Password = HashPassword(user.Password);
                    UserService service = new UserService();
                    UserS userS = YoupFO.Models.ConvertFO.FromFO(user);
                    service.CreateUser(userS);

                    return RedirectToAction("Index");

                }
                catch(Exception e)
                {
                    ModelState.AddModelError("try again", e);
                }
            }

            return View(user);
        }

        public ActionResult Edit(string id)
        {
            UserService service = new UserService();
            UserS userS = service.GetUser(id);
            Models.User user = Models.ConvertFO.ToFO(userS);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                user.UpdatedAt = DateTime.Now;
                UserService service = new UserService();
                UserS userS = YoupFO.Models.ConvertFO.FromFO(user);
                service.EditUser(userS);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(string id)
        {
            try
            {
                UserService service = new UserService();
                service.DeleteUser(id);
            }
            catch (Exception e)
            {
            }
            return RedirectToAction("Index");
        }

        // POST
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

        public ActionResult Login()
        {
            return View();
        }

        // POST Auth
        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                UserService service = new UserService();
                login.Password = HashPassword(login.Password);
                LoginS loginS = YoupFO.Models.ConvertFO.FromFO(login);
                UserS result = service.Auth(loginS);
                if (result != null)
                {
                    Session["User"] = ConvertFO.ToFO(result);
                    return RedirectToAction("/");
                }
                else
                    return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("/login");
        }

        public string HashPassword(string password)
        {
            string hash;
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = System.Text.Encoding.Default.GetBytes(password);
                byte[] hashbuffer = md5.ComputeHash(buffer, 0, buffer.Length);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashbuffer)
                {
                    sb.Append(b.ToString("X2"));
                }
                hash = sb.ToString();

                return hash;
            }
        }
    }
}
