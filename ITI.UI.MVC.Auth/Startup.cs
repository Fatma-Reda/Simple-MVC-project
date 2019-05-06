using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.UI.MVC.Auth.Startup))]
namespace ITI.UI.MVC.Auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
