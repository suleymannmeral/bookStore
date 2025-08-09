using Microsoft.AspNetCore.Mvc;


namespace BooklyBookStore.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TestController:ControllerBase
{
    [HttpGet]   
    public IActionResult Get()
    {
        return Ok("Test is working");
    }
        

}
