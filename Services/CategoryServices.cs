using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepositories CategoryRepository;

        public CategoryServices(ICategoryRepositories _categoryRepositories)
        {
            CategoryRepository = _categoryRepositories;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await CategoryRepository.GetCategoriesAsync();
        }

      
    }
}
