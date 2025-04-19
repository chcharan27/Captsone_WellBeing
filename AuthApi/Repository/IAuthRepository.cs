using AuthApi.Models;

namespace AuthApi.Repository
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);

    }
}
