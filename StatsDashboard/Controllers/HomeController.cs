using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;

namespace StatsDashboard.Controllers
{
    public class HomeController : Controller
    {
        YoupEntities db = new YoupEntities();

        public ActionResult Index()
        {
            ViewData["countUser"] = db.Users.Count();
            ViewData["countUserDelete"] = db.Users.Where(u => !u.DeletedAt.Equals(null)).Count();
            ViewData["countUserActive"] = db.Users.Where(u => u.IsActive == 1 && u.DeletedAt.Equals(null)).Count();
            ViewData["countUserFacebook"] = db.Users.Where(u => !u.GuidFacebook.Equals(null)).Count();

            return View();
        }
    }
}