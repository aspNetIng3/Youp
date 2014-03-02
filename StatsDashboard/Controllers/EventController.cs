using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;

namespace StatsDashboard.Controllers
{
    public class EventController : Controller
    {
        YoupEntities db = new YoupEntities();

        public ActionResult Index()
        {
            DateTime currentDateTime = DateTime.Now;

            Dictionary<int, int> eventCreateFormonths = new Dictionary<int, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, i, 1, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, i, DateTime.DaysInMonth(currentDateTime.Year, i), 23, 59, 59);

                int count = db.Events.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                eventCreateFormonths.Add(i, count);
            }

            ViewData["eventCreateForMonths"] = eventCreateFormonths;

            Dictionary<int, int> eventCreateFormonth = new Dictionary<int, int>();

            for (int i = 1; i <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month); i++)
            {
                DateTime start = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 0, 0, 0);
                DateTime end = new DateTime(currentDateTime.Year, currentDateTime.Month, i, 23, 59, 59);

                int count = db.Events.Where(u => u.CreatedAt > start && u.CreatedAt < end).Count();
                eventCreateFormonth.Add(i, count);
            }

            ViewData["eventCreateForMonth"] = eventCreateFormonth;

            ViewData["countEvent"] = db.Events.Count();
            ViewData["countEventPending"] = 0;
            ViewData["countEventClose"] = 0;
            ViewData["countEventDelete"] = db.Events.Where(e => !e.DeletedAt.Equals(null)).Count();

            return View();
        }
	}
}