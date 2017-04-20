using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Businessmall.Application.Events;
using Businessmall.SB.Subscriber.Order.QueryHandlers;
using Businessmall.SB.Subscriber.Order.CommandHandlers;
using Businessmall.SB.Subscriber.Order.Commands;

namespace Businessmall.SB.Subscriber.Order
{
    public class OrderSavedEventHandler : IMessageHandler<OrderSavedEvent>
    {

        private QueryHandler _queryHandler;
        private CommandHandler _commandHandler;

        public OrderSavedEventHandler()
        {
            _queryHandler = new QueryHandler();
            _commandHandler = new CommandHandler();
        }

        public void ProcessMessage(IHandlerContext<OrderSavedEvent> context)
        {

            UpdateOrderConfirmationCommand command = new UpdateOrderConfirmationCommand { 
                _isConfirmed    = context.Message._isConfirmed,
                _orderGUID      = context.Message._orderGUID,
                _status         = context.Message._status
            };

            bool result = _commandHandler.UpdateOrder(command);
            
        }

    }
}
