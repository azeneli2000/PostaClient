using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdexWebClient.Startup))]
namespace AdexWebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
