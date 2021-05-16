using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RejestOsob.Startup))]
namespace RejestOsob
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
