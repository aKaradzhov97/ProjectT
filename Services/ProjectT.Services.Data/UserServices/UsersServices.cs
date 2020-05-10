using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectT.Data.Common.Repositories;
using ProjectT.Data.Models;

namespace ProjectT.Services.Data.UserServices
{
    public class UsersServices:IUsersServices
    {
        private readonly IRepository<ApplicationUser> repositoryUser;

        public UsersServices(IRepository<ApplicationUser> repositoryUser)
        {
            this.repositoryUser = repositoryUser;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await this.repositoryUser.All().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await this.repositoryUser.All().AnyAsync(x => x.UserName == username);
        }
    }
}