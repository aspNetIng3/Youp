using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SearchModuleAPI.Common;
using SearchModuleAPI.Enum;
using SearchModuleAPI.Service;

namespace SearchModuleAPI.ActionFilter
{
    public class TraceApiActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string msg = FunctionalCodeError.NoMatch.Value;
            if (actionExecutedContext.Exception != null)
            {
                ExceptionService es = actionExecutedContext.Exception as ExceptionService;
                if (es.DomainNameCode.Equals(DomainCodeError.SERVICES))
                {
                    //permet de déterminer la source de la méthode
                    if (es.CName.Contains(ClassError.ProductService.Value))
                        msg = FunctionalCodeError.ErrorOrGetProduct.Value;
                    if (es.CName.Contains(ClassError.CategorieService.Value))
                        msg = FunctionalCodeError.ErrorOrGetCategorie.Value;
                }

                int cnt = 0;
                StringBuilder sb = new StringBuilder("{");
                sb.AppendFormat("\"{0}\":\"{1}\",\"{2}\":{3}",
                    "message", msg,
                    "error_code", (int)es.DomainNameCode);
                sb.Append("}");

                if (actionExecutedContext.Response == null)
                {
                    actionExecutedContext.Response = new HttpResponseMessage
                    {
                        Content = new StringContent(sb.ToString()),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
                Log4NetProvider.Instance.WriteLog(es, sb.ToString());
            }
            else

            {
                var t = new System.Net.Http.ObjectContent(actionExecutedContext.Response.Content.GetType(),
                        actionExecutedContext.Response.Content,
                        GlobalConfiguration.Configuration.Formatters.JsonFormatter);
                dynamic e = Convert.ChangeType(((System.Net.Http.ObjectContent)(t.Value)).Value,
                    actionExecutedContext.Response.Content.GetType().GenericTypeArguments[0]);
                if (e == null)
                {
                    actionExecutedContext.Response = new HttpResponseMessage
                    {
                        Content = new StringContent("nocontent"),
                        StatusCode = System.Net.HttpStatusCode.NoContent
                    };
                }
            }
            actionExecutedContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            System.Diagnostics.Trace.WriteLine(actionContext.ToString());
        }

    }
}