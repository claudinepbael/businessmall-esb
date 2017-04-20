using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Shuttle.Core.Ninject;
using Shuttle.Core.Host;
using Shuttle.Esb.Sql.Subscription;
using Ninject;
using Businessmall.Application.Events;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Infrastracture.Dispatchers;



namespace Businessmall.SB.Subscriber.Order
{
    public class Host : IHost, IDisposable
    {
        private IServiceBus _bus;
        private StandardKernel _kernel;

        public void Dispose()
        {
            _bus.Dispose();
        }

        public void Start()
        {
          /*
            var structureMapRegistry = new Registry();
            var registry = new StructureMapComponentRegistry(structureMapRegistry);

            ServiceBus.Register(registry);

            var resolver = new StructureMapComponentResolver(new Container(structureMapRegistry));

            resolver.Resolve<ISubscriptionManager>().Subscribe<MemberRegisteredEvent>();

            _bus = ServiceBus.Create(resolver).Start();
          */


            _kernel = new StandardKernel();
            _kernel.Bind<ICommandDispatcher>().To<CommandDispatcher>().WithConstructorArgument("kernel", _kernel);

            var container = new NinjectComponentContainer(_kernel);

            ServiceBus.Register(container);

            //_kernel.Bind<ISubscriptionManager>().To<SubscriptionManager>();

            var subscriptionManager = _kernel.Get<ISubscriptionManager>();
            subscriptionManager.Subscribe<OrderPlacedEvent>();
            subscriptionManager.Subscribe<OrderSavedEvent>();

            
            _bus = ServiceBus.Create(container).Start();
            
        }
    }
}
