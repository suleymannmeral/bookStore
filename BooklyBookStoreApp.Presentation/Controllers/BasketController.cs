using BooklyBookStoreApp.Application.DTOs.BasketDtos;
using BooklyBookStoreApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace BooklyBookStoreApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize(AuthenticationSchemes = "Bearer")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet("basket-items/{userId}")]
    public async Task<IActionResult> GetBasketItems(string userId)
    {
        var basket = await _basketService.GetBasketAsync(userId);
        return Ok(basket);
             
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddToBasket([FromBody] AddBasketItemDto dto)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Unauthorized("Token doğrulanamadı.");
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // userId null olmamalı
        await _basketService.AddItemToBasketAsync(userId, dto);
        return Ok("Sepete eklendi");
    }

    [HttpDelete("clear-basket/{userid}")]
    public async Task<IActionResult>ClearBasket(string userid)
    {
         await _basketService.ClearBasketAsync(userid);
        return Ok("Delete Successfully");

    }


}
