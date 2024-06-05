using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductServices productServices;
        private readonly IMapper _mapper;

        public ProductsController(IProductServices productServices, IMapper mapper)
        {
            this.productServices = productServices;
            _mapper = mapper;
        }

       

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = (List<Product>) await productServices.GetProductsAsync( position,  skip,   desc,   minPrice,   maxPrice,  categoryIds);
            List <ProductDTO> productsDto=_mapper.Map<List<Product>,List< ProductDTO >>(products);
            if (productsDto == null)
                return BadRequest();
            return Ok(productsDto);
        }

       
      

    }
}
