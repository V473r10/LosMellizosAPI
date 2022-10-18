using LosMellizosAPI.Models;
using LosMellizosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userService.GetUser(id));
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            return Ok(_userService.CreateUser(user));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_userService.UpdateUser(user));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
