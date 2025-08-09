using BooklyBookStoreApp.Application.DTOs.OrderDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Persistence.Services;
using BooklyBookStoreApp.Presentation.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace BooklyBookStoreApp.Presentation.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]

public class OrdersController : BaseApiController
{
    public OrdersController(IServiceManager manager) : base(manager)
    {
       

    }
    [HttpPost("from-basket")]
    public async Task<IActionResult> CreateOrderFromBasket()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var orderDto = await _manager.OrderService.CreateOrderAsync(userId);
        return Ok(orderDto);
    }

}
