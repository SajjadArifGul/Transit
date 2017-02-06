using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transit.Web.Startup))]
namespace Transit.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
