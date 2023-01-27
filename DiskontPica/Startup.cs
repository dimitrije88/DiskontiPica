using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiskontPica.Startup))]
namespace DiskontPica
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
