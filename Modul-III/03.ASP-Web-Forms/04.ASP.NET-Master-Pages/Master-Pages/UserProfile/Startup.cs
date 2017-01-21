using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserProfile.Startup))]
namespace UserProfile
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
