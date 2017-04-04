using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlesEnsalamento.Startup))]
namespace ControlesEnsalamento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
