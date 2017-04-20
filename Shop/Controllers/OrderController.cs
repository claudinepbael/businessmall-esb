using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Commands.Orders;
using Businessmall.Application.CommandResults;
using Businessmall.Application.Queries.Product;
using Businessmall.Application.QueryResults.Products;
using Businessmall.Application.Events;
using Businessmall.Application.Queries.Order;
using Businessmall.Application.QueryResults.Orders;
namespace Shop.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/
        public OrderController (IQueryDispatcher queryDispatcher,ICommandDispatcher commandDispatcher) :base (queryDispatcher,commandDispatcher){

        }

        public ActionResult Index(int orderId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult PlaceOrder(GetOrderCheckoutDetailsQuery query) 
        {
            
            CheckoutProduct orderCheckoutDetails = _queryDispatcher.Dispatch<GetOrderCheckoutDetailsQuery, CheckoutProduct>(query);
            return View(orderCheckoutDetails);
            
        }

        [HttpPost]
        public ActionResult CheckoutOrder(CheckoutOrderCommand command) 
        {
            command.userId = Convert.ToInt16(HttpContext.User.Identity.Name);
            CheckoutShopOrderCommandResult result = _commandDispatcher.DispatchWithResult<CheckoutOrderCommand,CheckoutShopOrderCommandResult>(command);

            //TODO: check result and error handling 

            //If result is successful, publish an event
            MvcApplication._serviceBus.Publish(
                new OrderPlacedEvent {
                    _orderGUID = result.order_id,
                    _productId = command.productId,
                    _quantity = command.quantity,
                    _userId = command.userId
                }
            );

            return View(result);
        }

        [HttpPost]
        public ActionResult GetOrderStatus (GetOrderStatusQuery query){

            OrderStatusQueryResult status = _queryDispatcher.Dispatch<GetOrderStatusQuery,OrderStatusQueryResult>(query);


            return Json(new  {
                    is_confirmed = status.status,
                   
                }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult OrderConfirmation (GetOrderDetailsQuery query){

            OrderDetailsQueryResult orderDetailsModel = _queryDispatcher.Dispatch<GetOrderDetailsQuery,OrderDetailsQueryResult>(query);

            return Json(new {
                html = RenderToString("OrderConfirmation",orderDetailsModel)
            });
        }


    }
}
