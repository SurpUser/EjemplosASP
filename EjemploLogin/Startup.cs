using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EjemploLogin.Startup))]
namespace EjemploLogin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
