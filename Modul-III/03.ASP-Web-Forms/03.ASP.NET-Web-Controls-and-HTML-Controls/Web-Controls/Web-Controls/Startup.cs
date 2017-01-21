using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Controls.Startup))]
namespace Web_Controls
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
