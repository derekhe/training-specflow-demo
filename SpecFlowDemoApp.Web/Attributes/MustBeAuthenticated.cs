using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpecFlowDemoApp.Web.Attributes
{
    public class MustBeAuthenticated : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isNotAuthenticated = !filterContext.HttpContext.User.Identity.IsAuthenticated;
            var isNotAuthController = !(filterContext.Controller is SpecFlowDemoApp.Web.Controllers.AuthenticationController);

            if (isNotAuthenticated && isNotAuthController)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Authentication", action = "Login" }));
            }
        }
    }
}