using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServices categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            _mapper = mapper;
        }



        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await categoryService.GetCategoriesAsync();
            IEnumerable<CategoryDTO> allCategories = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return allCategories;

        }
      

     
    }
}
