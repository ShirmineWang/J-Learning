using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(J_LearningSystem.Startup))]
namespace J_LearningSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
