using Oblig1WebApp.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrackerEnabledDbContext.Common.Configuration;

namespace Oblig1WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalTrackingConfig.DisconnectedContext = true;
        }
    }
}
