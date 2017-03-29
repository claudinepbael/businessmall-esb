using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.ViewModels.Products;
using Businessmall.Application.Infrastracture.Contracts;

namespace Shop.Controllers
{
    public class HomeController : BaseController

    {
     
        //
        // GET: /Home/
        public HomeController (IQueryDispatcher queryDispatcher,ICommandDispatcher commandDispatcher) :base (queryDispatcher,commandDispatcher){
           
        }

        public ActionResult Index()
        {
            return View(new ShopListProductsViewModel());
        }

    }
}
