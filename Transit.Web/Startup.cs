using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Transit.Web.Models;

[assembly: OwinStartupAttribute(typeof(Transit.Web.Startup))]
namespace Transit.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                var AdminRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                AdminRole.Name = "Admin";
                roleManager.Create(AdminRole);

                var user = new ApplicationUser();
                user.Name = "Sajjad Arif Gul";
                user.UserName = "sajjadarifgul@gmail.com";
                user.Email = "sajjadarifgul@gmail.com";
                string userPWD = "Sajjad12345;"; //this password is useless. Dont try to hack. -gul

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var ManagerRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                ManagerRole.Name = "Manager";
                roleManager.Create(ManagerRole);
            }
        }
    }
}