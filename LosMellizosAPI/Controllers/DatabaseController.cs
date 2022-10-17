using LosMellizosAPI.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        private readonly Database _database;


        public DatabaseController(Database database)
        {
            _database = database;
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return Ok(_database.Database.EnsureCreated());
        }
    }
}
