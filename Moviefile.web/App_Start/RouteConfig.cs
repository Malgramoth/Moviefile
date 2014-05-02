using System.Web.Mvc;
using System.Web.Routing;

namespace Moviefile.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Movie",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Views", action = "MovieDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Actor",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Views", action = "ActorDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Views", action = "MovieList", id = UrlParameter.Optional }
            );
        }
    }
}
