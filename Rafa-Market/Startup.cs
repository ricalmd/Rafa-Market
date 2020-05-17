using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rafa_Market.Startup))]
namespace Rafa_Market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
