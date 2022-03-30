using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeRobber.MVC.Startup))]
namespace RecipeRobber.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
