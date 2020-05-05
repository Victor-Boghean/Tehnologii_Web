using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Signin",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "Signin" }
            );
            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}",
                defaults: new { controller = "Register", action = "Register" }
            );
            routes.MapRoute(
                name: "AdminProducts",
                url: "{controller}/{action}",
                defaults: new { controller = "Produs", action = "AdminProducts" }
            );
            routes.MapRoute(
                name: "UserProducts",
                url: "{controller}/{action}",
                defaults: new { controller = "Produs", action = "UserProducts" }
            );
        }
    }
}
