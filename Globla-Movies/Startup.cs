using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Globla_Movies.Startup))]
namespace Globla_Movies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
