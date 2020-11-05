
using System.Threading.Tasks;
using ACM.API.Data;
using ACM.API.DTO;
using ACM.BL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ACM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductController(ProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> getAllProducts()
        {
            var products = await _repo.GetAllProducts();
            if (products.Count > 0)
                return Ok(products);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProduct(int id)
        {
            var product = await _repo.GetProduct(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> createProduct(ProductToCreateDTO productToCreateDTO)
        {
            var productToSave = _mapper.Map<Product>(productToCreateDTO);

            _repo.add(productToSave);

            if( await _repo.SaveAll())
            {
                return Ok(productToSave);
            }

            return BadRequest("Something went wrong");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // get product 
            var product = await _repo.GetProduct(id);
            
            if(product != null)
            {
                _repo.Delete(product);
                if(await _repo.SaveAll())
                {
                    return NoContent();
                }
            }

            return BadRequest();
        }
    }
}