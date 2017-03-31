using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Businessmall.Application.Events;
namespace Businessmall.Application.Shop.Order.EventHandlers
{
    public class OrderSavedEventHandler : IMessageHandler<OrderPlacedEvent>
    {

        public void ProcessMessage(IHandlerContext<OrderPlacedEvent> context)
        {

            //send command to update shop data is_confirmed property
            //send command to inform users that the order has been successfuly placed or not
                //-> this will stop the polling after the order has been placed
            
        }

    }
}
