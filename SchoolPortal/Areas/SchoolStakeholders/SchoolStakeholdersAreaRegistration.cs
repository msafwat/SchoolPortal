using System.Web.Mvc;

namespace SchoolPortal.Areas.SchoolStakeholders
{
    public class SchoolStakeholdersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SchoolStakeholders";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SchoolStakeholders_default",
                "Stakeholders/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}