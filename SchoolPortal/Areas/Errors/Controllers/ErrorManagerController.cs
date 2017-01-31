using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.Areas.Errors.Controllers
{
    public class ErrorManagerController : Controller
    {
        // GET: Errors/ErrorManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Status404()
        {
            return View();
        }
    }
}