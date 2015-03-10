using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcExamApplication.Startup))]
namespace MvcExamApplication
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
