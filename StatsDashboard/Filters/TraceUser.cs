using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository;

namespace StatsDashboard.Filters
{
    public class TraceUser : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO : enregistrement en bdd, referet, user_id si existant, heure, ...
            this.OnActionExecuting(filterContext);
        }
    }
}