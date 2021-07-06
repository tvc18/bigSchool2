using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bigSchool2.Startup))]
namespace bigSchool2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
