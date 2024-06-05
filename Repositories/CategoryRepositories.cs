using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        StshopContext _StshopContext;

        public CategoryRepositories(StshopContext stshopContext)
        {
            _StshopContext = stshopContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _StshopContext.Categories.ToListAsync();
        }
       

    }
}
