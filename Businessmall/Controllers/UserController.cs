using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Businessmall.ViewModels.Users;
using Businessmall.DTOs.Users;
using Businessmall.Repositories;
using Businessmall.Exceptions;

namespace Businessmall.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(new ListUsersViewModel());
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View(new AddOrUpdateUserViewModel());
        }

        [HttpPost]
        public JsonResult AddUser(AddUserCommand addUserCommand)
        {
           User newUser;
            using (var _bmService = new BusinessmallService())
            {
                newUser = _bmService.AddUser(addUserCommand);
            }
            return Json(newUser);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginCommand loginCommand)
        {
            bool isAuthorized = true;
            string errorMessage = "";
            using (var _bmService = new BusinessmallService())
            {
                try
                {
                    _bmService.Login(loginCommand);
                }
                catch (Exception e)
                {
                    isAuthorized = false;
                    errorMessage = e.Message;
                }
            }
            if (isAuthorized)
            {
                return RedirectToAction("Index", "Product");
            }
            else {
                return View(new LoginViewModel { Username = loginCommand.Username, ErrorMessage = errorMessage });
            }
            
        }
    }
}
