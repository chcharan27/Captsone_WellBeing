using AuthApi.Models;

namespace AuthApi.Repository
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);

    }
}
