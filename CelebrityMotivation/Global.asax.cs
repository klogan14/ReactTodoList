using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace CelebrityMotivation
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            //RouteTable.Routes.MapMvcAttributeRoutes();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
