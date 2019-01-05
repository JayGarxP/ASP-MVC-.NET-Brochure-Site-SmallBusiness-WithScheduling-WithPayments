using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab6.Startup))]
namespace Lab6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
