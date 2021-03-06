﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventMe.WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EventIndex",
                url: "Events/{page}",
                defaults: new { controller = "Events", action = "Index" },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "EventActions",
                url: "Events/{id}/{action}",
                defaults: new { controller = "Events", action = "Index" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            // handle non-existing urls
            routes.MapRoute(
                name: "404-PageNotFound",
                url: "{*url}",
                defaults: new { controller = "Home", action = "NotFound" }
            );
        }
    }
}
