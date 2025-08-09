using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class TestController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API test working..");
        }
    }
}
