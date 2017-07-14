using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shoppingCart.Startup))]
namespace shoppingCart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
