using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupFo.Models;
using YoupService.Services;

namespace YoupFo.Controllers
{
    public class ForumController : YoupController
    {
        private IThreadService threadService = new ThreadService();

        public ActionResult Index()
        {
            ViewBag.Favorites = threadService.getThreadsByFavorites(1, 1, 10);
            ViewBag.MostCommented = threadService.getThreadsMostCommented(1, 10);
            ViewBag.MostRecent = threadService.getThreadsMostRecent(1, 10);
            return View();
        }
    }
}
