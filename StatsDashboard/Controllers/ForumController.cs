using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;

namespace StatsDashboard.Controllers
{
    public class ForumController : Controller
    {
        YoupEntities db = new YoupEntities();

        public ActionResult Index()
        {
            DateTime currentDateTime = DateTime.Now;

            Dictionary<int, int> threadCreateFormonths = new Dictionary<int, int>();
            Dictionary<int, int> postCreateFormonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.Threads.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                threadCreateFormonths.Add(i, count);

                count = db.Posts.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                postCreateFormonths.Add(i, count);
            }

            ViewData["threadCreateFormonths"] = threadCreateFormonths;
            ViewData["postCreateFormonths"] = postCreateFormonths;
            
            Dictionary<int, int> threadCreateFormonth = new Dictionary<int, int>();
            Dictionary<int, int> postCreateFormonth = new Dictionary<int, int>();

            for (int i = 1; i <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month); i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 23, 59, 59);

                int count = db.Threads.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                threadCreateFormonth.Add(i, count);

                count = db.Posts.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                postCreateFormonth.Add(i, count);
            }

            ViewData["threadCreateFormonth"] = threadCreateFormonth;
            ViewData["postCreateFormonth"] = postCreateFormonth;
            
            ViewData["countThread"] = db.Threads.Count();
            ViewData["countPost"] = db.Posts.Count();
            ViewData["countTheme"] = db.Threads.Select(t => t.ThemeId).Distinct().Count();

            /*
            // Impossible : ThemeId NOT NULL dans Theme ...
            List<Theme> themes = db.Themes.ToList();
            Dictionary<string, int> themeThread = new Dictionary<string, int>();

            foreach (Theme theme in themes)
            {
                themeThread.Add(theme.Name, db.Threads.Where(t => t.ThemeId == theme.Id).Count());
            }

            ViewData["themeThread"] = themeThread.OrderByDescending(x => x.Value).Take(20).ToDictionary(x => x.Key, x => x.Value); ;
            */

            return View();
        }
	}
}