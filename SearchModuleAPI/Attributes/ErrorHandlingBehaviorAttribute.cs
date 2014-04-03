using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using SearchModuleAPI.Common;

namespace SearchModuleAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class ErrorHandlingBehaviorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by Customer Web API controller."),
                ReasonPhrase = "An unhandled exception was thrown by Customer Web API controller."
            };
            Log4NetProvider.Instance.WriteLog(context.Exception, msg.ReasonPhrase);
            context.Response = msg;
        }
    }
}