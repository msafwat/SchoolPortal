using Entities;
using SchoolPortal.ControllersHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SchoolPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));

            var questionType = new List<QuestionType>();
            questionType.Add(new QuestionType() { Id = 0, NameEn = "Choose Question Type", NameAr="اختر نوع السؤال" });
            questionType.Add(new QuestionType() { Id = 1, NameEn = "Multi Choose" , NameAr ="اختيار من متعدد" });
            questionType.Add(new QuestionType() { Id = 2, NameEn = "Essay", NameAr = "مقال" });
            MemoryCache.Default.Add("QuestionTypelList", questionType, null);

            var questionLevel = new List<QuestionLevel>();
            questionLevel.Add(new QuestionLevel() { Id = 1, NameEn = "Choose Question Level", NameAr="اختر مستوي السؤال"  });
            questionLevel.Add(new QuestionLevel() { Id = 1, NameEn = "Easy", NameAr="سهل" });
            questionLevel.Add(new QuestionLevel() { Id = 2, NameEn = "Medium", NameAr = "متوسط" });
            questionLevel.Add(new QuestionLevel() { Id = 3, NameEn = "Hard", NameAr = "صعب" });
            MemoryCache.Default.Add("QuestionLevelList", questionLevel, null);

        }
    }
}
