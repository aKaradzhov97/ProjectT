namespace ProjectT.Services.Data.UserServices
{
    using System.Threading.Tasks;

    using ProjectT.Web.ViewModels.Users;

    public interface IUsersServices
    {
        Task<bool> UsernameExists(string username);

        Task<bool> EmailExists(string email);

        Task<UserViewModel> GetInfo(string username);
    }
}