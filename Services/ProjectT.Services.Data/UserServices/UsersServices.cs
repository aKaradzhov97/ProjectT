﻿using ProjectT.Common;

namespace ProjectT.Services.Data.UserServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;

    public class UsersServices : IUsersServices
    {
        private readonly IRepository<ApplicationUser> repositoryUser;
        private readonly IRepository<IdentityUserRole<string>> repositoryUserRole;
        private readonly IRepository<ApplicationRole> repositoryRole;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersServices(
            IRepository<ApplicationUser> repositoryUser,
            IRepository<IdentityUserRole<string>> repositoryUserRole,
            IRepository<ApplicationRole> repositoryRole,
            UserManager<ApplicationUser> userManager)
        {
            this.repositoryUser = repositoryUser;
            this.repositoryUserRole = repositoryUserRole;
            this.repositoryRole = repositoryRole;
            this.userManager = userManager;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await this.repositoryUser.All().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await this.repositoryUser.All().AnyAsync(x => x.UserName == username);
        }

        public async Task<User> GetInfo(string username)
        {
            var currentUser = await this.repositoryUser.All()
                .FirstOrDefaultAsync(x => x.UserName == username);
            var userRoleId = await this.repositoryUserRole.All()
                .FirstOrDefaultAsync(x => x.UserId == currentUser.Id);
            var role = await this.repositoryRole.All().FirstOrDefaultAsync(x => x.Id == userRoleId.RoleId);

            var info = new User
            {
                Username = currentUser.UserName,
                Email = currentUser.Email,
                Phone = currentUser.PhoneNumber,
            };

            if (role.Name == GlobalConstants.AdministratorRoleName)
            {
                info.IsAdmin = true;
            }
            else
            {
                info.IsAdmin = false;
            }

            return info;
        }


        public class User
        {
            public string Username { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

            public bool IsAdmin { get; set; }
        }
    }
}