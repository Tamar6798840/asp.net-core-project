using Entities;

namespace Repositories
{
    public interface IProductRepositories
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}