using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StatsDashboard.Startup))]
namespace StatsDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
