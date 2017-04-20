using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
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

        public string RenderToString (string viewName, object model){

            ViewData.Model = model;

            using (var sw = new StringWriter()){

                var viewResult =  ViewEngines.Engines.FindPartialView(ControllerContext, viewName);

                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                viewResult.View.Render(viewContext ,sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return sw.GetStringBuilder().ToString();


            }


        }
    }
}
