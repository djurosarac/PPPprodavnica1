using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPPprodavnica1.Startup))]
namespace PPPprodavnica1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
