using LosMellizosAPI.Models;
using LosMellizosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            return Ok(_customerService.GetCustomer(id));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            return Ok(_customerService.CreateCustomer(customer));
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            return Ok(_customerService.UpdateCustomer(customer));
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteCustomer(Guid id)
        //{
        //    _customerService.DeleteCustomer(id);
        //    return Ok();
        //}

    }
}
