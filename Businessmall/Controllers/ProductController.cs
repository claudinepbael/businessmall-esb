using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessmall.Controllers;
using Businessmall.ViewModels.Products;
using Businessmall.DTOs.Products;
using Businessmall.Repositories;

namespace Businessmall.Controllers
{
    public class ProductController : BaseController
    {
        //
        // GET: /Products/

        public new ActionResult Index()
        {
            return View(new ListProductsViewModel());
        }

        [HttpPost]
        public JsonResult AddProduct(AddProductCommand AddProductCommand)
        {
            using (var _bmService = new BusinessmallService())
            {
                return Json(_bmService.AddProduct(AddProductCommand));
            }
        }

        [HttpGet]
        public new ActionResult Update(string id)
        {
            return View(new UpdateProductViewModel( Convert.ToInt32(id)));
        }

        [HttpPost]
        public ActionResult Update(UpdateProductCommand UpdateProductCommand)
        {
            using (var _bmService = new BusinessmallService())
            {
                if (_bmService.UpdateProduct(UpdateProductCommand))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


    }
}
