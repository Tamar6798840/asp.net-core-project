using Entities;
using Repositories;
using System.Collections;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private IProductRepositories ProductRepository;
        public ProductServices(IProductRepositories _productRepositories)
        {
            ProductRepository = _productRepositories;
        }
        public async  Task<IEnumerable<Product>> GetProductsAsync(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await ProductRepository.GetProductsAsync( position,  skip,  desc,  minPrice, maxPrice, categoryIds);
        }

    }
}
