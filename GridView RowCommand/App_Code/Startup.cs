using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GridView_RowCommand.Startup))]
namespace GridView_RowCommand
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
