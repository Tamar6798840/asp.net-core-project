using Entities;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace Repositories;

public class UserRepositories : IUserRepositories
{

    StshopContext _StshopContext;

    public UserRepositories(StshopContext stshopContext)
    {
        _StshopContext = stshopContext;
    }

    public async Task <User> AddUserAsync(User user)
    {      
        await _StshopContext.Users.AddAsync(user);
        await _StshopContext.SaveChangesAsync();
        return user;
    }
    public async Task<User?> GetUserByEmailAndPasswordAsync(string userName, string password)
    {
        return  await _StshopContext.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefaultAsync();           
    }
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _StshopContext.Users.FindAsync(id);
    }
    public async Task<bool> UpdateUserAsync(int id, User user)
    {
        user.UserId = id;
        var res=  _StshopContext.Users.Update(user) ;
        await _StshopContext.SaveChangesAsync();
        return res!=null;
    }
}
