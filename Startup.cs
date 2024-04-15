using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bodh.Startup))]
namespace Bodh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
