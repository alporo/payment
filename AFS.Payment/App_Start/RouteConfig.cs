﻿using System.Web.Mvc;
using System.Web.Routing;

namespace AFS.Payment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Payment", action = "GenerateLink", id = UrlParameter.Optional }
            );
        }
    }
}
