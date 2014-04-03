using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupFo.Models;
using YoupService.Services;
using YoupRepository.Model;

namespace YoupFo.Controllers
{
    public class ForumController : YoupController
    {
        private IThreadService threadService = new ThreadService();
        private IThemeService themeService = new ThemeService();

        public ActionResult Index()
        {
            ViewBag.Favorites = threadService.getThreadsByFavorites(1, 1, 10);
            ViewBag.MostCommented = threadService.getThreadsMostCommented(1, 10);
            ViewBag.MostRecent = threadService.getThreadsMostRecent(1, 10);
            return View();
        }

        public ActionResult ThemeThreads(int id)
        {
            Console.WriteLine("Theme id : " + id);
            ViewBag.ThemeThreads = threadService.getThreadsByTheme(id, 1, 20);
            ViewBag.ThemeTitle = themeService.GetTheme(id).Data.Name;
            return View("ThemeThreads");
        }
    }
}
