using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessmall.Application.Queries.ShopUser;
using Businessmall.Application.QueryHandlers;

namespace Shop.Controllers
{
    public class SecurityController : Controller
    {
        //
        // GET: /Security/

        public ActionResult Index()
        {
            return View(new UserLogin());
        }


    }
}
