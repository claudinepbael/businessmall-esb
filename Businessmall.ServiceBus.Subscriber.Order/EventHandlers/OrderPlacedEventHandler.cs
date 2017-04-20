using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Businessmall.Application.Events;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.SB.Subscriber.Order.QueryHandlers;
using Businessmall.SB.Subscriber.Order.Queries;
using Businessmall.SB.Subscriber.Order.QueryResults;
using Businessmall.SB.Subscriber.Order.Commands;
using Businessmall.SB.Subscriber.Order.CommandHandlers;

namespace Businessmall.SB.Subscriber.Order
{
    public class OrderPlacedEventHandler : IMessageHandler<OrderPlacedEvent>
    {

        private QueryHandler _queryHandler;
        private CommandHandler _commandHandler;

        public OrderPlacedEventHandler()
        {
            _queryHandler = new QueryHandler();
            _commandHandler = new CommandHandler();
        }


        public void ProcessMessage(IHandlerContext<OrderPlacedEvent> context) { 
        
            bool isOrderConfirmed = true;
            string message = "";

            GetProductDetailsQuery query = new GetProductDetailsQuery {productId = context.Message._productId};

            ProductDetails product = _queryHandler.RetriveProductDetails(query);

            bool breakpoint = true;
            if (product.avaialableQty > context.Message._quantity)
            {
                SaveOrderCommand command = new SaveOrderCommand
                {
                    _orderGUID = context.Message._orderGUID,
                    _productId = context.Message._productId,
                    _userId = context.Message._userId,
                    _quantity = context.Message._quantity
                };

                try
                {
                    bool result = _commandHandler.SaveOrder(command);
                    isOrderConfirmed = result;
                    message = "Order was placed successfully.";
                }
                catch (Exception ex)
                {
                    isOrderConfirmed = false;
                    message = ex.Message;
                }
                
               
            }
            else
            {
                isOrderConfirmed = false;
                message = "The available quantity is not enough";
            }

            //send OrderSavedEvent back to ServiceBus.Shop.Order
            context.Publish(
                new OrderSavedEvent { 
                    _orderGUID = context.Message._orderGUID,
                    _isConfirmed = isOrderConfirmed,
                    _message = message
                }
            );
        }

    }
}
