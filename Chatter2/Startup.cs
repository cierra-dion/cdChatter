using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chatter2.Startup))]
namespace Chatter2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
