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

            //

            ViewData["countUser"] = db.UserYoups.Count();
            ViewData["countUserDelete"] = db.UserYoups.Where(u => !u.DeletedAt.Equals(null)).Count();
            ViewData["countUserActive"] = db.UserYoups.Where(u => u.IsActive == 1 && u.DeletedAt.Equals(null)).Count();
            ViewData["countUserFacebook"] = db.UserYoups.Where(u => !u.GuidFacebook.Equals(null)).Count();

            List<String> cities = db.UserYoups.Select(u => u.Address).Distinct().ToList();
            Dictionary<String, int> citiesStats = new Dictionary<string, int>();

            foreach (string city in cities)
            {
                citiesStats.Add(city, db.UserYoups.Distinct().Where(u => u.Address == city).Count());
            }

            ViewData["citiesStats"] = citiesStats;

            ViewData["topTenCities"] = citiesStats.OrderByDescending(x => x.Value).Take(10).ToDictionary(x => x.Key, x => x.Value);

            List<Rank> ranks = db.Ranks.ToList();
            Dictionary<String, int> rankUser = new Dictionary<String, int>();

            foreach (var rank in ranks)
            {
                int count = db.UserYoups.Where(u => u.RankId == rank.Id).Count();
                rankUser.Add(rank.LevelRank, count);
            }

            ViewData["rankUser"] = rankUser;

            //
            /*
            List<UserYoup> participants = db.UserYoups.OrderByDescending(u => u.Events.Count).Take(10).ToList();
            Dictionary<String, int> participations = new Dictionary<string, int>();

            foreach (UserYoup u in participants)
            {
                participations.Add(u.UserName, u.Events.Count);
            }

            ViewData["topTenParticipants"] = participations.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            List<UserYoup> creators = db.UserYoups.OrderByDescending(u => u.Events1.Count).Take(10).ToList();
            Dictionary<String, int> creations = new Dictionary<string, int>();

            foreach (UserYoup u in creators)
            {
                creations.Add(u.UserName, u.Events1.Count);
            }

            ViewData["topTenCreators"] = creations.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            */

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