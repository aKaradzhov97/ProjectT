﻿namespace ProjectT.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using ProjectT.Common;
    using ProjectT.Data.Models;

    public class UsersWithRolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedAdminInRoleAsync(userManager, GlobalConstants.AdministratorUsername,
                GlobalConstants.AdministratorPassword, GlobalConstants.AdministratorRoleName);

            await SeedUserInRoleAsync(userManager, GlobalConstants.UserUsername,
                GlobalConstants.UserPassword, GlobalConstants.UserRoleName);
        }

        private static async Task SeedAdminInRoleAsync(UserManager<ApplicationUser> userManager, string userName,
            string password, string role)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userName,
                    Email = "admin@admin.com",
                    PhoneNumber = "08888888888",
                    CreatedOn = DateTime.UtcNow,
                };

                var newUser = await userManager.CreateAsync(user, password);
                var userRole = await userManager.AddToRoleAsync(user, role);

                if (!newUser.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, newUser.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedUserInRoleAsync(UserManager<ApplicationUser> userManager, string userName,
            string password, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userName,
                    Email = "admina@admina.com",
                    PhoneNumber = "0888999999",
                    CreatedOn = DateTime.UtcNow,
                };

                var newUser = await userManager.CreateAsync(user, password);
                var userRole = await userManager.AddToRoleAsync(user, role);

                if (!newUser.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, newUser.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}