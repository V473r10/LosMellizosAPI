using LosMellizosAPI.Models;
using LosMellizosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_orderService.GetOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            return Ok(_orderService.GetOrder(id));
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            return Ok(_orderService.CreateOrder(order));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Order order)
        {
            return Ok(_orderService.UpdateOrder(order));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
