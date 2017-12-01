using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dietitian.Startup))]
namespace Dietitian
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
