using Businessmall.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Businessmall.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View(new ListOrdersViewModel());
        }

    }
}
