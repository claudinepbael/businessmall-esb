using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Infrastracture.Helpers;
using Businessmall.Application.Queries.Product;
using Businessmall.Application.QueryResults.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductsController : BaseController
    {
        //
        // GET: /Product/
         
        public ProductsController(IQueryDispatcher queryDispatcher,ICommandDispatcher commandDispatcher):base(queryDispatcher,commandDispatcher){
        }
        public ActionResult ProductLists()
        {
            List<AvailableProduct> availableProducts = _queryDispatcher.Dispatch<GetAvailableProductsQuery,SelectList<AvailableProduct>>(new GetAvailableProductsQuery()).Data;
            return View();
        }

    }
}
