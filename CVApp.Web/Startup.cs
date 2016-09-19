using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVApp.Web.Startup))]
namespace CVApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
