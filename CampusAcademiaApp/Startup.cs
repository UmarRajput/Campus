using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampusAcademiaApp.Startup))]
namespace CampusAcademiaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
