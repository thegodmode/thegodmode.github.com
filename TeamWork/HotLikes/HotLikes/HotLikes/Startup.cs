using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotLikes.Startup))]
namespace HotLikes
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
