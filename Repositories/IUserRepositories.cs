using Entities;

namespace Repositories
{
    public interface IUserRepositories
    {
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<bool> UpdateUserAsync(int id, User userToUpdate);
        Task<User?> GetUserByIdAsync(int id);
    }
}