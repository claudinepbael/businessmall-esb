using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Shuttle.Esb;
using Shuttle.Core.Ninject;
using Ninject;


namespace Shop
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

        public static IServiceBus _serviceBus;
        public static StandardKernel _kernel;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SetUpShuttle();
        }

        private void SetUpShuttle() {
            _kernel = new StandardKernel();
            var container = new NinjectComponentContainer(_kernel);
            ServiceBus.Register(container);
            _serviceBus = ServiceBus.Create(container).Start();
        }

    }
}