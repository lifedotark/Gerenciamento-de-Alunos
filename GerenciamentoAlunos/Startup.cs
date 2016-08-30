using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerenciamentoAlunos.Startup))]
namespace GerenciamentoAlunos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
