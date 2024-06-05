using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProductsAsync(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}