using Entities;

namespace Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
      
    }
}