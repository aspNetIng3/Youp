using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;
using StatsDashboard.Filters;

namespace StatsDashboard.Controllers
{
    public class HomeController : Controller
    {
        YoupEntities db = new YoupEntities();

        public ActionResult Index()
        {
            DateTime currentDateTime = DateTime.Now;

            Dictionary<int, int> userRegisterFormonths = new Dictionary<int, int>();
            Dictionary<int, int> userDeletedFormonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.UserYoups.Where(u => u.CreatedAt >= start && u.CreatedAt <= end).Count();
                userRegisterFormonths.Add(i, count);

                count = db.UserYoups.Where(u => !u.DeletedAt.Equals(null) && u.DeletedAt >= start && u.DeletedAt <= end).Count();
                userDeletedFormonths.Add(i, count);
            }

            ViewData["userRegisterForMonths"] = userRegisterFormonths;
            ViewData["userDeletedFormonths"] = userDeletedFormonths;

            Dictionary<int, int> userRegisterFormonth = new Dictionary<int, int>();
            Dictionary<int, int> userDeletedFormonth = new Dictionary<int, int>();

            for (int i = 1; i <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month); i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 23, 59, 59);

                int count = db.UserYoups.Where(u => u.CreatedAt >= start && u.CreatedAt <= end).Count();
                userRegisterFormonth.Add(i, count);

                count = db.UserYoups.Where(u => !u.DeletedAt.Equals(null) && u.DeletedAt >= start && u.DeletedAt <= end).Count();
                userDeletedFormonth.Add(i, count);
            }

            ViewData["userRegisterForMonth"] = userRegisterFormonth;
            ViewData["userDeletedFormonth"] = userDeletedFormonth;

            Dictionary<int, int> eventCreateFormonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.Events.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                eventCreateFormonths.Add(i, count);
            }

            ViewData["eventCreateForMonths"] = eventCreateFormonths;

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

            ViewData["countUser"] = db.UserYoups.Count();
            ViewData["countUserActive"] = db.UserYoups.Where(u => u.IsActive == 1 && u.DeletedAt.Equals(null)).Count();
            ViewData["countUserDelete"] = db.UserYoups.Where(u => !u.DeletedAt.Equals(null)).Count();

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


            Dictionary<int, int> connectionForMonth = new Dictionary<int, int>();

            for (int i = 1; i <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month); i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 23, 59, 59);

                int count = db.Connections.Where(u => u.DateConnection >= start && u.DateConnection <= end).Count();
                connectionForMonth.Add(i, count);
            }

            ViewData["connectionForMonth"] = connectionForMonth;

            return View();
        }
    }
}