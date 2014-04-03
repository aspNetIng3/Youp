using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SearchModuleAPI.App_Start.UnityWebActivator), "Start")]

namespace SearchModuleAPI.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            UnityDependencyResolver resolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container); //change the default dependency resolver

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            //Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }
    }
}