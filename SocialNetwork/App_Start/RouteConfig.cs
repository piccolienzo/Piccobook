using System.Web.Mvc;
using System.Web.Routing;

namespace SocialNetwork
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //PROFILE
            routes.MapRoute(
                name: "Profile",
                url: "Profile/{username}",
                defaults: new { controller = "Profile", action = "Username", username = UrlParameter.Optional }
            );

            //SETTINGS
            routes.MapRoute(
                name: "Settings",
                url: "Settings",
                defaults: new { controller = "Profile", action = "Settings" }
            );
            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "Register", action = "Register" }
            );

            routes.MapRoute(
               name: "Login",
               url: "Login",
               defaults: new { controller = "Home", action = "Login" }
           );
            

            routes.MapRoute(
                name: "Publish",
                url: "Publish",
                defaults: new { controller = "Posts", action = "Publish" }
            );

            routes.MapRoute(
                name: "Posts",
                url: "Posts",
                defaults: new { controller = "Posts", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
