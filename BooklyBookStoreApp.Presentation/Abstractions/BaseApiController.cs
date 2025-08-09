using BooklyBookStoreApp.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace BooklyBookStoreApp.Presentation.Abstractions;
[ApiController]
[Route("api/[controller]")]
public  class BaseApiController:ControllerBase
{
    public readonly IServiceManager _manager;

    protected BaseApiController(IServiceManager manager)
    {
        _manager = manager;
    }

}
