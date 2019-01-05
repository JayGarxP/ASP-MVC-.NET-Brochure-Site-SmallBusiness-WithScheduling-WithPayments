using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6.Data;
using Lab6.Services;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;


namespace Lab6.App_Start
{
    public static class DepedencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<DatabaseAccessI, DatabaseAccess>();
            container.Register<I_PetServices, PetServices>();

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}