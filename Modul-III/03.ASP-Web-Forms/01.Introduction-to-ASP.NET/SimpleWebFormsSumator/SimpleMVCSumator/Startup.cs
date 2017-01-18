using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleMVCSumator.Startup))]
namespace SimpleMVCSumator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
