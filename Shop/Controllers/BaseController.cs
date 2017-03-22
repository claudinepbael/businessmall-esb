using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public abstract class BaseController : Controller
    {
       protected readonly IQueryDispatcher _queryDispatcher;

       protected readonly ICommandDispatcher _commandDispatcher;
        
    

        public BaseController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;

        }
    }
}
