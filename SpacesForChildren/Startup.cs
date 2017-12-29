using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SpacesForChildren.Models;

[assembly: OwinStartupAttribute(typeof(SpacesForChildren.Startup))]
namespace SpacesForChildren
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
