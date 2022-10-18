using LosMellizosAPI.Models;
using LosMellizosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerClassController : Controller
    {
        private readonly ICustomerClassService _customerClassService;

        public CustomerClassController(ICustomerClassService customerClassService)
        {
            _customerClassService = customerClassService;
        }

        [HttpGet]
        public IActionResult GetCustomerClasses()
        {
            return Ok(_customerClassService.GetCustomerClasses());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerClass(int id)
        {
            return Ok(_customerClassService.GetCustomerClass(id));
        }

        [HttpPost]
        public IActionResult CreateCustomerClass(CustomerClass customerClass)
        {
            return Ok(_customerClassService.CreateCustomerClass(customerClass));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomerClass(int id, CustomerClass customerClass)
        {
            return Ok(_customerClassService.UpdateCustomerClass(id, customerClass));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerClass(int id)
        {
            _customerClassService.DeleteCustomerClass(id);
            return Ok();
        }
    }
}
