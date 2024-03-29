﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using TrabzonToplulugu.Repositories;

namespace TrabzonToplulugu
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile")
                                                             {
                                                                 ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
                                                             });

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile")
                                                             {
                                                                 ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("android", StringComparison.OrdinalIgnoreCase) >= 0)
                                                             });
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            InMemoryMemberRepository.FillExampleData();
        }
    }
}