using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MyApp.Functions;
using MyApp.Models;
using Owin;
using System.Data.Entity.Migrations;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(MyApp.Startup))]
namespace MyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //SeedRoleAndPermission();
            CodeGenerate.UserCode();
        }

        private void SeedRoleAndPermission()
        {
            ///////////////Check Role
            ApplicationDbContext context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == Role.Admin))
            {
                var user = new ApplicationUser();
                user.UserName = Role.Admin;
                user.Email = "admin@email.com";

                userManager.Create(user, "Password$01");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = Role.Admin });
                context.SaveChanges();
                userManager.AddToRole(user.Id, Role.Admin);
            }

        }
    }
}
