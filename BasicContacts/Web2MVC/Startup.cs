using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web2MVC.Startup))]
namespace Web2MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
