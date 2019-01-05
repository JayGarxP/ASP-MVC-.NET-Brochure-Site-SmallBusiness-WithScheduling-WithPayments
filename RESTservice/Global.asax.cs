using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RESTservice
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\JP\Desktop\WebDevREDEMPTION\Lab7_CST356\Lab6\Lab6\App_Data");
        }
    }
}
