using System;
using System.Net;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class LocalOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var ip = filterContext.HttpContext.Request.UserHostAddress;

            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}