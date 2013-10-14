using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cph
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Project details",
                url: "Projects/{name}",
                defaults: new {controller = "Projects", action = "Details"}
            );
            routes.MapRoute(
                name: "Projects",
                url: "Projects/{action}/{name}",
                defaults: new {controller = "Projects", action = "Index", name = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}