using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Businessmall.Application.Events;

namespace Businessmall.Application.Backoffice.Order.EventHandlers
{
    class OrderPlacedEventHandler : IMessageHandler<OrderPlacedEvent>
    {

        public void ProcessMessage(IHandlerContext<OrderPlacedEvent> context) { 
        
            //dispatch command to save order in backoffice (SaveOrderCommand) save bool resultin isOrderConfirmed
            bool isOrderConfirmed = true;

            string errorMessage = "Just in case there are error saving order  (ie. out of stock)";

            //send OrderSavedEvent back to ServiceBus.Shop.Order
            context.Publish(
                new OrderSavedEvent { 
                    _orderGUID = context.Message._orderGUID,
                    _isConfirmed = isOrderConfirmed,
                    _message = errorMessage
                }
            );
        }

    }
}
