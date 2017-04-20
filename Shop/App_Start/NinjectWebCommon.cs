using Ninject;
using Ninject.Web.Common;
using System.Reflection;
using Businessmall.Application.Infrastracture.Contracts;
using System.Web.Mvc;
using Ninject.Web.Mvc;
using Businessmall.Application.Infrastracture.Dispatchers;
using Businessmall.Application.Infrastracture.Data;
using Businessmall.Application.Infrastracture.Helpers;
using Ninject.Extensions.Conventions;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Shop.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Shop.App_Start.NinjectWebCommon), "Stop")]

namespace Shop.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Reflection;
    using Businessmall.Application.Infrastracture.Contracts;
    using System.Web.Mvc;
    using Ninject.Web.Mvc;
    using Businessmall.Application.Infrastracture.Dispatchers;
    using Businessmall.Application.Infrastracture.Data;
    using Businessmall.Application.Infrastracture.Helpers;
    using Ninject.Extensions.Conventions;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
           
           
            kernel.Bind<HttpContext>().ToMethod(ctx => HttpContext.Current).InTransientScope();

            kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();

            kernel.Bind<IQueryDispatcher>().To<QueryDispatcher>().WithConstructorArgument("kernel", kernel);

            kernel.Bind<ICommandDispatcher>().To<CommandDispatcher>().WithConstructorArgument("kernel", kernel);

            kernel.Bind<IDataContext>().To<DataContext>();            

            kernel.Bind<IApplicationHelper>().To<ApplicationHelper>().InSingletonScope();

            kernel.Bind(x => x
               .FromAssembliesMatching("Businessmall.Application.dll")
               .SelectAllClasses().InheritedFrom(typeof(IQueryHandler<,>))
               .BindAllInterfaces());

            kernel.Bind(x => x
                .FromAssembliesMatching("Businessmall.Application.dll")
                .SelectAllClasses().InheritedFrom(typeof(ICommandHandler<>))
                .BindAllInterfaces());

            kernel.Bind(x => x
                .FromAssembliesMatching("Businessmall.Application.dll")
                .SelectAllClasses().InheritedFrom(typeof(ICommandHandlerWithReturn<,>))
                .BindAllInterfaces());

            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);

            DependencyResolver.SetResolver(resolver);

        }        
    }
}