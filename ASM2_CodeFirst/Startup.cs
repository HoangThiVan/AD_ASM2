using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASM2_CodeFirst.Startup))]
namespace ASM2_CodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
