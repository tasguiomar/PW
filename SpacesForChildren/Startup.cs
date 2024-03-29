﻿using Microsoft.AspNet.Identity;
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
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login  
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup I am creating first Admin Role and creating a default Admin User   
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                 

                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.EmailConfirmed = true;

                string userPWD = "As#123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role   
            if (!roleManager.RoleExists("Instituição"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Instituição";
                roleManager.Create(role);

            }

            // creating Creating Employee role   
            if (!roleManager.RoleExists("Pais"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Pais";
                roleManager.Create(role);

            }
        }

    }
}
