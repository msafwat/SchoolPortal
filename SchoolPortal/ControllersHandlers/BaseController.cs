﻿using BusinessLogicLayer;
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
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected BusinessLogicFacade facade = new BusinessLogicFacade();

        protected override void OnException(ExceptionContext filterContext)
        {
            logger.Log(LogLevel.Error, "\r\nError Code: {0}\r\nMessage: {1}\r\nStack Trace: {2}\r\nInner Exception: {3}\r\n{4}",
                Guid.NewGuid().ToString(),
                filterContext.Exception.Message,
                filterContext.Exception.StackTrace,
                filterContext.Exception.InnerException,
                "##################################################");

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
                return Session["culture"].ToString() == "ar-EG";
            }
        }
    }
}