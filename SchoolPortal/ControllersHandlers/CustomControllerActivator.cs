using GlobalizationResources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace SchoolPortal.ControllersHandlers
{
    public class CustomControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            string culture = "en-US";
            if (requestContext.HttpContext.Request.Cookies["culture"] == null)
            {
                requestContext.HttpContext.Response.Cookies.Add(
                    new HttpCookie("culture", culture)
                    { Path = "/", Expires = DateTime.Now.AddDays(1) }
                    );
            }
            else
            {
                culture = requestContext.HttpContext.Request.Cookies["culture"].Value;
            }

            requestContext.HttpContext.Session["culture"] = culture;

            ResourcesHelper.SetCulutre(culture);

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}