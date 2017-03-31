using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Commands;

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

        public ActionResult PlaceOrder(PlaceOrderCommand command) 
        {
            return View();
        }


    }
}
