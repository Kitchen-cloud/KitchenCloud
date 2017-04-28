using System.Web.Mvc;
using System.Web.Routing;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Recipes;
namespace KitchenCloud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
