using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BallooningMelbourne.Startup))]
namespace BallooningMelbourne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
