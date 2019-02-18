using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SubletMe.WebUI.Startup))]
namespace SubletMe.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
