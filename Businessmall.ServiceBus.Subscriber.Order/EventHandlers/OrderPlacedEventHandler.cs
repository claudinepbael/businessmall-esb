using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuttle.Esb;
using Businessmall.Application.Events;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Infrastracture.Constants;
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

            GetProductDetailsQuery query = new GetProductDetailsQuery {productId = context.Message._productId};

            ProductDetails product = _queryHandler.RetriveProductDetails(query);

            OrderSavedEvent orderSavedEvent = addOrder(context.Message,product);

            if (orderSavedEvent._status == Constants.OrderStatus.CONFIRMED) {
                updateInventory(context.Message._productId, context.Message._quantity);
            }

            context.Publish(orderSavedEvent);
        }

        private OrderSavedEvent addOrder(OrderPlacedEvent message, ProductDetails product) { 
           
            Constants.OrderStatus status;
            bool isConfirmed;

            if (product.avaialableQty < message._quantity)
            {
                isConfirmed = false;
                status = Constants.OrderStatus.OUT_OF_STOCK;
            }
            else
            {
                SaveOrderCommand command = new SaveOrderCommand
                {
                    _orderGUID = message._orderGUID,
                    _productId = message._productId,
                    _userId = message._userId,
                    _quantity = message._quantity
                };

                try
                {
                    bool result = _commandHandler.SaveOrder(command);
                    isConfirmed = result;
                    if (result)
                    {
                        status = Constants.OrderStatus.CONFIRMED;
                    }
                    else {
                        status = Constants.OrderStatus.FAILED;
                    }
                    
                }
                catch (Exception ex)
                {
                    status = Constants.OrderStatus.FAILED;
                    isConfirmed = false;
                }
                
            }

            return new OrderSavedEvent{
                _orderGUID = message._orderGUID,
                _isConfirmed = isConfirmed,
                _status = status
            };
        }

        private bool updateInventory(int productId, int qtyPurchased)
        {
            UpdatePurchasedQtyCommand command = new UpdatePurchasedQtyCommand{
                productId = productId,
                additionalPurchasedQty = qtyPurchased
            };

            bool result = _commandHandler.updatePurchasedQty(command);

            return true;
        }

    }
}
