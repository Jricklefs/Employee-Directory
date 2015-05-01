using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyDirectoryDF.Startup))]
namespace CompanyDirectoryDF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
