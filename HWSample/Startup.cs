using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWSample.Startup))]
namespace HWSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
