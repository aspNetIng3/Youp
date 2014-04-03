using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youpe.data.POCO;
using Youpe.web.Controllers.api;

namespace Youpe.web.Controllers.ctrl
{
    public class ForumController : MasterController
    {
        private ThreadsController _threadApi = new ThreadsController();

        public ActionResult Index()
        {
            ViewBag.Favorites = _threadApi.getThreadsByFavorites(1, 1, 10);
            ViewBag.MostCommented = _threadApi.getThreadsMostCommented(1, 10);
            ViewBag.MostRecent = _threadApi.getThreadsMostRecent(1, 10);
            return View();
        }

        public ActionResult ThemeThreads(long id)
        {
            ThemesController _thApi = new ThemesController();

            ViewBag.ThemeTitle = "";

           // ViewBag.ThemeThreads = _thApi.getThreadsByTheme(id, 1, 20);

            Theme _myTheme = _thApi.Get(id);
            if (_myTheme != null)
            {
                ViewBag.ThemeTitle = _myTheme.Name;
            }
            
            return View("ThemeThreads");
        }

    }
}
