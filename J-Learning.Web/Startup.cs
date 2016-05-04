using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(J_Learning.Web.Startup))]
namespace J_Learning.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
