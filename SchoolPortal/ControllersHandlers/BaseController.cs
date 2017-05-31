using BusinessLogicLayer;
using NLog;
using SchoolPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.ControllersHandlers
{
    public class BaseController : Controller
    {
        protected BusinessLogicFacade facade = new BusinessLogicFacade();

        protected override void OnException(ExceptionContext filterContext)
        {
            SystemLogger.SystemLogger.LogException(filterContext.Exception);

            //if (filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    filterContext.ExceptionHandled = true;
            //    this.View("Error").ExecuteResult(filterContext);
            //}

            base.OnException(filterContext);
        }

        public bool IsArabic
        {
            get
            {
                return Session["culture"] == null ? false : Session["culture"].ToString() == "ar-EG";
            }
        }
    }
}