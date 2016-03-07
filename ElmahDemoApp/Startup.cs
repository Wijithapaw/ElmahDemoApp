using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElmahDemoApp.Startup))]
namespace ElmahDemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
