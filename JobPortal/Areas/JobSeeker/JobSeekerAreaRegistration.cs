using System.Web.Mvc;

namespace JobPortal.Areas.JobSeeker
{
    public class JobSeekerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JobSeeker";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JobSeeker_default",
                "JobSeeker/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}