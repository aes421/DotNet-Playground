using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningDotNet.Startup))]
namespace LearningDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
