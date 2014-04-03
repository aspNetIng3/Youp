using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youpe.web.Controllers.api;

namespace Youpe.web.Controllers.ctrl
{
    public class EventController : Controller
    {
        private EventsController _eventApi = new EventsController();

        public ActionResult Index()
        {


            var events = _eventApi.Get();
            ViewBag.allEvents = events;


            return View();
        }

    }
}
