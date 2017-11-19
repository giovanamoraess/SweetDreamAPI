using UnityConfiguration;
using SweetDream.Infrastructure.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Practices.Unity;

namespace SweetDream.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            UnityConfig.Initialise();
            var container = new UnityContainer();
            container = UnityConfigInitialise();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        private static UnityContainer UnityConfigInitialise()
        {
            string[] assemblyNameParts = Assembly.GetExecutingAssembly().GetName().Name.Split('.');
            string assemblyPrefix = string.Join(".", assemblyNameParts, 0, 1);

            var container = UnityConfig.Container;

            Predicate<Assembly> includeAssembly = (a) =>
            {
                var assemblyName = a.GetName().Name;
                return (assemblyName.StartsWith(assemblyPrefix)) && (assemblyName.Contains("Business") || assemblyName.Contains("Data") || assemblyName.Contains("API"));
            };

            container.Configure(c =>
            {
                c.Scan(scan =>
                {
                    scan.AssembliesInBaseDirectory(a => includeAssembly(a));
                    scan.WithNamingConvention();
                });
            });

            return container;
        }

    }
}
