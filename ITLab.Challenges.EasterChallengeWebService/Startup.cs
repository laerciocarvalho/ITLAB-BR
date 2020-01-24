using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITLab.Challenges.EasterChallengeWebService.Startup))]
namespace ITLab.Challenges.EasterChallengeWebService
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
