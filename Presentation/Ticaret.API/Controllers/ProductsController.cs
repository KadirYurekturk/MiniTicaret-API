using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticaret.Application.Repositories.ModelRepositories;
using Ticaret.Domain.Entities;

namespace Ticaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productReadRepository.GetAll();
            return Ok(products);
        }
        //get Single product
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPut]
        public async Task<IActionResult> Put(string id, string name)
        {
            var product = await _productReadRepository.GetByIdAsync(id , false);
            if (product == null)            
                return NotFound();
            
            product.Name = name;
            await _productWriteRepository.SaveAsync();

            return NoContent();
        }
        //[HttpPost]
        //public async Task<IActionResult> Post()
        //{
        //    await _productWriteRepository.AddRangeAsync(new()
        //    {
        //        new() { Id = Guid.NewGuid(), Name = "Ürün 1", Price = 100, CreatedAt = DateTime.UtcNow, Description = "Açıklama 1" },
        //        new() { Id = Guid.NewGuid(), Name = "Ürün 2", Price = 200, CreatedAt = DateTime.UtcNow, Description = "Açıklama 2" },
        //        new() { Id = Guid.NewGuid(), Name = "Ürün 3", Price = 300, CreatedAt = DateTime.UtcNow, Description = "Açıklama 3" },
        //    });
        //    return Ok( await _productWriteRepository.SaveAsync());
        //}

        //insert product from users
        [HttpPost()]
        public async Task<IActionResult> Post( string name, string desc , int price)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = desc,
                Price = price
            };
            await _productWriteRepository.AddAsync(product);
            return Ok(await _productWriteRepository.SaveAsync());
        }
    }
}
