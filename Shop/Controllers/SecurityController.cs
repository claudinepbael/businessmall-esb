using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessmall.Shop.Infrastructure.Queries.ShopUser;
using Businessmall.Shop.Infrastructure.QueryHandlers;
using Businessmall.Shop.Infrastructure.Commands;
using System.Web.Security;
using Shuttle.Esb;
using Ninject;
using Ninject.Components;

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

        [HttpPost]
        public ActionResult Login()
        {


            using (var bus = ServiceBus
                .Create(
                    c => c.MessageHandlerFactory(new NinjectMessageHandlerFactory(new StandardKernel()))
                )
                .Start())
                {
                    string userName;

                    while (!string.IsNullOrEmpty(userName = Console.ReadLine()))
                    {
                        bus.Send(new LoginShopUserCommand
                        {
                            _username = "username",
                            _password = "password"
                        }, c => c.WillExpire(DateTime.Now.AddSeconds(5)));
                    }
                }
            FormsAuthentication.SetAuthCookie("shopUser_username", false);
            return RedirectToAction("Index", "Home");

        }
    }
}
