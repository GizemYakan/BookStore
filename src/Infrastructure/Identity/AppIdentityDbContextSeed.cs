using ApplicationCore.Constans;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{

    public static class AppIdentityDbContextSeed
    {

        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@example.com";
            if (!await roleManager.RoleExistsAsync(AuthorizationConstans.Roles.ADMIN))
            {
                await roleManager.CreateAsync(new IdentityRole(AuthorizationConstans.Roles.ADMIN));
            }
            if (!await userManager.Users.AnyAsync(x => x.UserName == adminEmail))
            {
                var adminUser = new ApplicationUser() { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, AuthorizationConstans.DEFAULT_PASSWORD);
                await userManager.AddToRoleAsync(adminUser, AuthorizationConstans.Roles.ADMIN);
            }
        }
    }
}
