using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoapServer.Startup))]
namespace SoapServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
