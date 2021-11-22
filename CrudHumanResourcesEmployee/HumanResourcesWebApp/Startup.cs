using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HumanResourcesWebApp.Startup))]
namespace HumanResourcesWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
