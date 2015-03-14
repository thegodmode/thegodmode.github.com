using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicMenu.Startup))]
namespace DynamicMenu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
