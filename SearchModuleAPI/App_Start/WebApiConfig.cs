using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using SearchModuleAPI.Tracer;
using System.Web.Http.Tracing;

namespace SearchModuleAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /*IHttpRoute mapHttpRoute = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action="GetAll"}
                );*/
            IHttpRoute mapHttpRoute = config.Routes.MapHttpRoute(
                name: "DefaultApiRoute",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "ElasticSearch", action = "GetAll" }
                );
            config.Services.Replace(typeof(ITraceWriter), new SampleTracer());
        }
    }
}
