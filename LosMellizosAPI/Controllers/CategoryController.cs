using LosMellizosAPI.Models;
using LosMellizosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_categoryService.GetCategory(id));
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            return Ok(_categoryService.CreateCategory(category));
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            return Ok(_categoryService.UpdateCategory(category));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
