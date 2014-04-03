using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchModuleAPI.Controllers
{
    public class HomeController :  Controller
    {
        public ActionResult Index()
        {
            //throw new Exception("une erreur s'est produite lors du chargement de la home Page");
            ViewBag.Title = "Home Page";
            //throw new HttpException(404, "Erreur produite de type 404");
            //throw new Exception("une erreur s'est produite lors du chargement de la home Page");
            return View();
        }
    }
}
