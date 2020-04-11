using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DR.Escolaridade.Web.Startup))]
namespace DR.Escolaridade.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
