using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobCardV14.Startup))]
namespace JobCardV14
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
