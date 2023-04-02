using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PresentationApplication.Startup))]
namespace PresentationApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
