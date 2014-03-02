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

            ViewData["countEvent"] = db.Events.Count();
            ViewData["countEventPending"] = 0;
            ViewData["countEventClose"] = 0;
            ViewData["countEventDelete"] = db.Events.Where(e => !e.DeletedAt.Equals(null)).Count();

            ViewData["countThread"] = db.Threads.Count();
            ViewData["countPost"] = db.Posts.Count();
            ViewData["countTheme"] = db.Threads.Select(t => t.ThemeId).Distinct().Count();

            return View();
        }
    }
}