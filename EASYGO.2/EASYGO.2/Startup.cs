using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EASYGO._2.Startup))]
namespace EASYGO._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
