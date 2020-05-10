namespace ProjectT.Services.Data.UserServices
{
    using System.Threading.Tasks;

    public interface IUsersServices
    {
        Task<bool> UsernameExists(string username);

        Task<bool> EmailExists(string email);
    }
}