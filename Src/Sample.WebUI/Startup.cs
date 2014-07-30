using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sample.WebUI.Startup))]
namespace Sample.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
