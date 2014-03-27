using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using YoupFo.Models;

namespace YoupFo.Controllers
{
    public class YoupController : Controller
    {
        public List<ForumModels> ListForum = ForumModels.getForumsAndSubforums();
        
        public YoupController()
        {
            ViewBag.ListForum = ListForum;
        }
        public ActionResult Nav()
        {
            ViewBag.ListForum = ListForum;  
            return this.PartialView();
        }
    }

}
