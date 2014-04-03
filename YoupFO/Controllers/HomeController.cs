using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository.Models.DAL.Database;
using YoupRepository.Models.POCO;
using YoupService.Blog;

namespace YoupFO.Controllers
{
    public class HomeController : Controller
    {
      
       
        public ActionResult Index()
        {
           
            return View();
        }
    }
}
