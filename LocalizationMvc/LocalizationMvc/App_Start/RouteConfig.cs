using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocalizationMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new
                    {
                        culture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName, 
                        controller = "Home", action = "Index", 
                        id = UrlParameter.Optional
                    }
            );
        }
    }
}