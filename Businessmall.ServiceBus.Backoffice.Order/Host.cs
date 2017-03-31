using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Shuttle.Core.Ninject;
using Shuttle.Core.Host;
using Ninject;

namespace Businessmall.Application.Backoffice.Order
{
    public class Host : IHost, IDisposable
    {
        private IServiceBus _bus;
        private StandardKernel _kernel;

        public void Start()
        {
            _kernel = new StandardKernel();
            var container = new NinjectComponentContainer(_kernel);
            ServiceBus.Register(container);
            _bus = ServiceBus.Create(container).Start();

        }

        public void Dispose()
        {
            _bus.Dispose();
        }
    }
}
