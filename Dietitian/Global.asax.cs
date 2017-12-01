﻿using Dietitian.Web.App_Start;
using Dietitian.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dietitian
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Log4net
            log4net.Config.XmlConfigurator.Configure();

            // Autofac and Automapper configurations
            Bootstrapper.Run();

            // AutoMapper
            AutoMapperConfiguration.Configure();

         
        }
    }
}
