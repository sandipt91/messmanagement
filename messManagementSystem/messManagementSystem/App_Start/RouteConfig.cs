
using System.Web.Mvc;
using System.Web.Routing;

namespace messManagementSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "account", action = "login", id = UrlParameter.Optional }
            );
        }
    }
}