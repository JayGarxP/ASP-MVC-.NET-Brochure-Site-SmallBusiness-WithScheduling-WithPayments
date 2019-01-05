using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Lab6.App_Start; //DEPENDENCY INJECTION CONFIG

namespace Lab6
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //DON'T FORGET TO REGISTER YOUR DEPENDENCY INJECTION https://simpleinjector.readthedocs.io/en/latest/mvcintegration.html
            //to solve 'parameterless-constructor' problems with stuff you want to injectify
            DepedencyInjectionConfig.Register();
        }
    }
}
