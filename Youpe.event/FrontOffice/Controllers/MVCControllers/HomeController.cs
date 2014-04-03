using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository.Model.POCO;
using YoupRepository.Model.DTO;
using YoupService;
using FrontOffice.Controllers.APIControllers;


namespace FrontOffice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            EventAPIController Api = new EventAPIController();
            IEnumerable<EventPOCO> events = Api.AllEvents();
            ViewBag.allEvents = events;

            ThemeAPIController themeApi = new ThemeAPIController();
            IEnumerable<ThemePOCO> themes = themeApi.allThemes();
            ViewBag.allThemes = themes;
           

            //if API query is done in the view, we give it only the uri of the API to call
           // string myApiUri = Url.HttpRouteUrl("DefaultApi", new { Controller = "EventAPIController" });
           // ViewBag.myApiUrl = new Uri(Request.Url, myApiUri).AbsoluteUri.ToString();

            return View();
        }
    }
}
