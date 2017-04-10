using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessmall.Application.Queries.ShopUser;
using Businessmall.Application.QueryHandlers;
using Businessmall.Application.Commands;
using System.Web.Security;
using Shuttle.Esb;
using Ninject;
using Ninject.Components;
using Businessmall.Application.QueryResults.ShopUsers;
using Businessmall.Application.Infrastracture.Contracts;

namespace Shop.Controllers
{
    public class SecurityController : BaseController
    {
    

        public SecurityController (IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher,commandDispatcher) {
            
        }

        //
        // GET: /Security/

        public ActionResult Index()
        {
            return View(new UserLoginQuery());
        }

        [HttpPost]
        public ActionResult Login(UserLoginQuery query)
        {

           var result = _queryDispatcher.Dispatch<UserLoginQuery,LoggedInUser>(query);

           if (result != null) { 
                //call UserLoggedInEvent
               FormsAuthentication.SetAuthCookie(result.userID.ToString(), false);
           }
            
           return RedirectToAction("ProductLists","Products");

        }
    }
}
