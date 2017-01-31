using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnException(ExceptionContext filterContext)
        {
            logger.Log(LogLevel.Error, "Error Code: {0}\n{1}\n{2}", Guid.NewGuid().ToString(), filterContext.Exception.StackTrace, "##################################################");

            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                filterContext.ExceptionHandled = true;
                this.View("Error").ExecuteResult(filterContext);
            }
        }
    }
}