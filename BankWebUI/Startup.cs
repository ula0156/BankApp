using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankWebUI.Startup))]
namespace BankWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
