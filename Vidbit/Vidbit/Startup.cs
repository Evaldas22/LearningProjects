using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidbit.Startup))]
namespace Vidbit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
