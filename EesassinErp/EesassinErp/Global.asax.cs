using EesassinErp.App_Start;
using HactheryErp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EesassinErp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();

            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register); // NEW way
                                                                  //WebApiConfig.Register(GlobalConfiguration.Configuration); // DEPRECATED

            // Default stuff
          
            RouteConfig.RegisterRoutes(RouteTable.Routes);
         
        }
    }
}
