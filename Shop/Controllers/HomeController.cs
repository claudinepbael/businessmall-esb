using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.ViewModels.Products;
using Businessmall.Application.Infrastracture.Contracts;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IQueryDispatcher _queryDispatcher;
        private ICommandDispatcher _commandDispatcher;
        //
        // GET: /Home/
        public HomeController (IQueryDispatcher queryDispatcher,ICommandDispatcher commandDispatcher) {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
        public ActionResult Index()
        {
            return View(new ShopListProductsViewModel());
        }

    }
}
