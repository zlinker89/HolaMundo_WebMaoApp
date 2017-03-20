using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMaoApp_MVC.Models;

namespace WebMaoApp_MVC.Security
{
    public class Role_Usuario
    {
        internal void SetUsuarioRol()
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(userscontext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            // Create Role
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Normal"))
            {
                roleManager.Create(new IdentityRole("Normal"));
            }

            if (!userscontext.Users.Any(x => x.UserName == "ospi89@hotmail.com"))
            {
                // Create User
                var user = new ApplicationUser { UserName = "ospi89@hotmail.com", Email = "ospi89@hotmail.com" };
                userManager.Create(user, "Franklin89.");

                // Add User To Role
                if (!userManager.IsInRole(user.Id, "Admin"))
                {
                    userManager.AddToRole(user.Id, "Admin");
                }


            }else
            {
                if (!userManager.IsInRole(userscontext.Users.Where(x => x.UserName == "ospi89@hotmail.com").FirstOrDefault().Id, "Admin"))
                {
                    userManager.AddToRole(userscontext.Users.Where(x => x.UserName == "ospi89@hotmail.com").FirstOrDefault().Id, "Admin");
                }
            }
        }
    }
}