using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropdownMD.Startup))]
namespace DropdownMD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
