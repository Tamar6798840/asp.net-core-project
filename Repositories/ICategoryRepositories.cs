using Entities;

namespace Repositories
{
    public interface ICategoryRepositories
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
       
    }
}