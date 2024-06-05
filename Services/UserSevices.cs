
using Entities;
using Repositories;

namespace Services;

public class UserSevices : IUserSevices
{
    private IUserRepositories UserRepository;
    public UserSevices(IUserRepositories _userRepositories)
    {
        UserRepository = _userRepositories;
    }

    public  async Task<User> AddUserAsync(User user)
    {
        return   await UserRepository.AddUserAsync(user);
    }

    public async  Task<User> GetUserByUserNameAndPasswordAsync(string email, string password)
    {
        return await UserRepository.GetUserByEmailAndPasswordAsync(email, password);
    }
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await UserRepository.GetUserByIdAsync(id);
    }
    public async Task<bool> UpdateUserAsync(int id, User userToUpdate)
    {
        return await UserRepository.UpdateUserAsync(id, userToUpdate);
    }
    public int Checkpassword(string pwd)
    {
        var result = Zxcvbn.Core.EvaluatePassword(pwd);
        return result.Score;
    }

}
