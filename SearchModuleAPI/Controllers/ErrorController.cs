using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchModuleAPI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Request.Headers["X-Requested-With"] != null && this.HttpContext.Request.Headers["X-Requested-With"].Equals("XMLHttpRequest"))
            {
                return PartialView("AjaxError", ViewData.Model);
            }
            return View(ViewData.Model);
        }


        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            Response.ContentType = "text/html";
            Response.TrySkipIisCustomErrors = true;
            return View("Error404", ViewData.Model);
        }
    }
}