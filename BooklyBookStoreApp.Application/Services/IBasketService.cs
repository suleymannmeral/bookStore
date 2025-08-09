using BooklyBookStoreApp.Application.DTOs.BasketDtos;

namespace BooklyBookStoreApp.Application.Services;

public interface IBasketService
{
    Task<BasketDto> GetBasketAsync(string userId);
    Task AddItemToBasketAsync(string userId, AddBasketItemDto dto);
    Task RemoveItemFromBasketAsync(string userId, int bookId);
    Task ClearBasketAsync(string userId);
    Task CreateUserBasket(string userId);
}
