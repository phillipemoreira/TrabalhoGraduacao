using Plan5W2HPlusPlus.Application.Controllers;
using Plan5W2HPlusPlus.Application.Models;
using Plan5W2HPlusPlus.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plan5W2HPlusPlus.Application.ActionFilter
{
    public class AuthorizationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionController = filterContext.Controller as LoggedController;

            if (sessionController == null)
                return;

            UserModel u = sessionController.GetUserModel();
            filterContext.Controller.ViewBag.UserModel = u;
        }
    }
}
