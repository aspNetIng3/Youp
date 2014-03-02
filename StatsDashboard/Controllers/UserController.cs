using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;

namespace StatsDashboard.Controllers
{
    public class UserController : Controller
    {
        YoupEntities db = new YoupEntities();

        public ActionResult Index()
        {
            DateTime currentDateTime = DateTime.Now;

            Dictionary<int, int> userRegisterFormonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.Users.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                userRegisterFormonths.Add(i, count);
            }

            ViewData["userRegisterForMonths"] = userRegisterFormonths;

            Dictionary<int, int> userRegisterFormonth = new Dictionary<int, int>();

            for (int i = 1; i <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month); i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 23, 59, 59);

                int count = db.Users.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                userRegisterFormonth.Add(i, count);
            }

            ViewData["userRegisterForMonth"] = userRegisterFormonth;

            //

            Dictionary<int, int> userDeletedFormonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.Users.Where(u => !u.DeletedAt.Equals(null) && u.DeletedAt > start && u.DeletedAt < end).Count();
                userDeletedFormonths.Add(i, count);
            }

            ViewData["userDeletedFormonths"] = userDeletedFormonths;

            Dictionary<int, int> userDeletedFormonth = new Dictionary<int, int>();

            for (int i = 1; i <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month); i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 23, 59, 59);

                int count = db.Users.Where(u => !u.DeletedAt.Equals(null) && u.DeletedAt > start && u.DeletedAt < end).Count();
                userDeletedFormonth.Add(i, count);
            }

            ViewData["userDeletedFormonth"] = userDeletedFormonth;

            //

            ViewData["countUser"] = db.Users.Count();
            ViewData["countUserDelete"] = db.Users.Where(u => !u.DeletedAt.Equals(null)).Count();
            ViewData["countUserActive"] = db.Users.Where(u => u.IsActive == 1 && u.DeletedAt.Equals(null)).Count();
            ViewData["countUserFacebook"] = db.Users.Where(u => !u.GuidFacebook.Equals(null)).Count();

            List<String> cities = db.Users.Select(u => u.Address).Distinct().ToList();
            Dictionary<String, int> citiesStats = new Dictionary<string, int>();

            foreach (string city in cities)
            {
                citiesStats.Add(city, db.Users.Distinct().Where(u => u.Address == city).Count());
            }

            ViewData["citiesStats"] = citiesStats;

            return View();
        }
	}
}