using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnasBimble.Startup))]
namespace AnasBimble
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
