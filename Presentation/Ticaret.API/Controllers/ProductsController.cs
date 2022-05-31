using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticaret.Application.Repositories.ModelRepositories;
using Ticaret.Application.RequestParameters;
using Ticaret.Application.ViewModels.Products;
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

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var products = _productReadRepository.GetAll(false);
        //    return Ok(products);
        //}
        //Get products page and page size
        [HttpGet]
        public IActionResult Get([FromQuery]Pagination pagination)
        {
            
            var products = _productReadRepository.GetAll(false);
            var totalCount = products.Count();
            var pageProducts = products
                .Skip((pagination.Page)* pagination.ItemsPerPage)
                .Take(pagination.ItemsPerPage);
            
            return Ok(new { pageProducts , totalCount } );
        }


        //get Single product
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var product = await _productReadRepository.GetByIdAsync(id,false);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}
        //[HttpPut]
        //public async Task<IActionResult> Put(string id, string name)
        //{
        //    var product = await _productReadRepository.GetByIdAsync(id , true);
        //    if (product == null)            
        //        return NotFound();

        //    product.Name = name;
        //    await _productWriteRepository.SaveAsync();

        //    return NoContent();
        //}
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

        //update product
        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateViewModel product)
        {
            var productToUpdate = await _productReadRepository.GetByIdAsync(product.Id);
            if (productToUpdate == null)            
                return NotFound();
            
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Stock = product.Stock;
            
            return Ok(await _productWriteRepository.SaveAsync());
        }

        //insert product from users
        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateViewModel productvm)
        {
            if (!ModelState.IsValid)            
                return ValidationProblem("Product parameters are not valid"); 
            
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = productvm.Name,
                Stock = productvm.Stock,
                Price = productvm.Price
            };
            await _productWriteRepository.AddAsync(product);
            return Ok(await _productWriteRepository.SaveAsync());
        }

        //delete product
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var productToUpdate = await _productReadRepository.GetByIdAsync(id);
            if (productToUpdate == null)
                return NotFound();
            await _productWriteRepository.DeleteAsync(id);
            return Ok(await _productWriteRepository.SaveAsync());
        }
    }
}
