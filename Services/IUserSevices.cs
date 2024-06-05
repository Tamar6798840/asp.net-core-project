using Entities;

namespace Services
{
    public interface IUserSevices
    {
        Task<User> AddUserAsync(User user);
        int Checkpassword(string pwd);
        Task<User> GetUserByUserNameAndPasswordAsync(string email, string password);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, User userToUpdate);
    }
}