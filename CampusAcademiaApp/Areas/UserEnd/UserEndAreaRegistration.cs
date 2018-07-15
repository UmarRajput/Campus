using System.Web.Mvc;

namespace CampusAcademiaApp.Areas.UserEnd
{
    public class UserEndAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserEnd";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserEnd_default",
                "UserEnd/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}