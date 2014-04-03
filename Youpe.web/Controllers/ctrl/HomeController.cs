using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Youpe.data.POCO;
using Youpe.Models.Repo;

namespace Youpe.web.Controllers.ctrl
{
    public class HomeController : MasterController
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Angular()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
    }
}
