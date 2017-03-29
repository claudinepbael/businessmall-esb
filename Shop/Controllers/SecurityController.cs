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
            
           return RedirectToAction("ProductLists","Products");

            //using (var bus = ServiceBus
            //    .Create(
            //      //  c => c.MessageHandlerFactory(new NinjectMessageHandlerFactory(new StandardKernel()))
            //    )
            //    .Start())
            //    {
            //        string userName;

            //        while (!string.IsNullOrEmpty(userName = Console.ReadLine()))
            //        {
            //            bus.Send(new LoginShopUserCommand
            //            {
            //                _username = "username",
            //                _password = "password"
            //            }, c => c.WillExpire(DateTime.Now.AddSeconds(5)));
            //        }
            //    }
            //FormsAuthentication.SetAuthCookie("shopUser_username", false);
            //return RedirectToAction("Index", "Home");

        }
    }
}
