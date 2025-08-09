using AutoMapper;
using BooklyBookStoreApp.Application.DTOs.BasketDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;


namespace BooklyBookStoreApp.Persistence.Services;

public sealed class BasketService : IBasketService
{
    private readonly IRepositoryManager _repositoryManager;

    private readonly IMapper _mapper;

    public BasketService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<BasketDto> GetBasketAsync(string userId)
    {
        var basket =  _repositoryManager.Basket.GetBasketByUserIdAsync(userId);
        return _mapper.Map<BasketDto>(basket);
    }

    public async Task AddItemToBasketAsync(string userId, AddBasketItemDto dto)
    {
        var basket =  _repositoryManager.Basket.GetBasketByUserIdAsync(userId);

        if (basket == null)
        {
            basket = new Basket
            {
                UserId = userId,
                BasketItems = new List<BasketItem>
            {
                new BasketItem { BookId = dto.BookId, Quantity = dto.Quantity }
            }
            };

            _repositoryManager.Basket.AddBasket(basket);
            await _repositoryManager.Save();
        }
        else
        {
            var existingItem = basket.BasketItems.FirstOrDefault(i => i.BookId == dto.BookId);
            if (existingItem != null)
                existingItem.Quantity += dto.Quantity;
            else
                basket.BasketItems.Add(new BasketItem { BookId = dto.BookId, Quantity = dto.Quantity });

            _repositoryManager.Basket.UpdateBasket(basket);
            await _repositoryManager.Save();
        }
    }

 

    public async Task ClearBasketAsync(string userId)
    {
        var basket = _repositoryManager.Basket.GetBasketByUserIdAsync(userId);
        if (basket != null)
        {
            _repositoryManager.Basket.DeleteBasket(basket);
            await _repositoryManager.Save();
        }
    }

    public async Task RemoveItemFromBasketAsync(string userId, int bookId)
    {
        var basket = _repositoryManager.Basket.GetBasketByUserIdAsync(userId);
        var item = basket?.BasketItems.FirstOrDefault(i => i.BookId == bookId);
        if (item != null)
        {
            basket.BasketItems.Remove(item);
            _repositoryManager.Basket.UpdateBasket(basket);
            await _repositoryManager.Save();
        }

    }

    public async Task CreateUserBasket(string userId)
    {
        _repositoryManager.Basket.CreateBasket(userId);
        await _repositoryManager.Save();

    }
}
