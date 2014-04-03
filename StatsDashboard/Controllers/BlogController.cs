using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;

namespace StatsDashboard.Controllers
{
    public class BlogController : Controller
    {
        YoupEntities db = new YoupEntities();

        public ActionResult Index()
        {
            ViewData["count"] = db.Blogs.Count();
            ViewData["active"] = db.Blogs.Where(u => u.IsActive == 1).Count();
            ViewData["delete"] = db.Blogs.Where(u => u.DeletedAt != null).Count();

            DateTime currentDateTime = DateTime.Now;

            Dictionary<int, int> blogForMonths = new Dictionary<int, int>();
            Dictionary<int, int> blogDeletedForMonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.Blogs.Where(u => u.CreatedAt >= start && u.CreatedAt <= end).Count();
                blogForMonths.Add(i, count);

                count = db.Blogs.Where(u => u.DeletedAt >= start && u.DeletedAt <= end).Count();
                blogDeletedForMonths.Add(i, count);
            }

            ViewData["blogForMonths"] = blogForMonths;
            ViewData["blogDeletedForMonths"] = blogDeletedForMonths;

            return View();
        }
	}
}