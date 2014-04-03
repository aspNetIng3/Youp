using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupFO.Models;

namespace YoupFO.Controllers
{
    public class CreateIndexesController : Controller
    {
        //
        // GET: /CreateIndexes/
        public ActionResult Index()
        {
            return View(new List<string>());
        }

        [HttpPost]
        public ActionResult Launch()
        {
            return View(IndexCreator.LaunchIndexCreation());
        }
	}
}