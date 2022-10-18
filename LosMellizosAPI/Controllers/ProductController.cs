using LosMellizosAPI.Models;
using LosMellizosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            return Ok(_productService.GetProduct(id));
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(_productService.CreateProduct(product));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Product product)
        {
            return Ok(_productService.UpdateProduct(product));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
