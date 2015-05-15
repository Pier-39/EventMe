using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventMe.WebApplication.Startup))]
namespace EventMe.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
