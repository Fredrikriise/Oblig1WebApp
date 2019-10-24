using Model;
using System.Web.Mvc;
using System.Web.Routing;
using TrackerEnabledDbContext.Common.Configuration;

namespace Oblig1WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bestilling", action = "Bestilling", id = UrlParameter.Optional }
            );

            EntityTracker.TrackAllProperties<Bestilling>();
            EntityTracker.TrackAllProperties<Avgang>();
            EntityTracker.TrackAllProperties<visAvgang>();
            EntityTracker.TrackAllProperties<adminBruker>();
            EntityTracker.TrackAllProperties<alleavgangstid>();
        }
    }
}
