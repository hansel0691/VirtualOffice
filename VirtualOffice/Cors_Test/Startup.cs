using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cors_Test.Startup))]
namespace Cors_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
