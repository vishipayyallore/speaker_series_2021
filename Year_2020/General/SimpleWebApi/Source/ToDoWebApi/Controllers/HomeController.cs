using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoWebApi.Models;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var results = "Hello World";

            return Ok(results);
        }

        [HttpGet]
        [Route("/metadata")]
        public IActionResult GetApplicationMetadata()
        {
            return Ok(new ToDoApplication());
        }

    }
}
