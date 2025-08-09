using BooklyBookStoreApp.Domain.Entitites;


namespace BooklyBookStoreApp.Domain.Repositories;

public interface IBasketRepository:IRepositoryBase<Basket>
{
    Basket GetBasketByUserIdAsync(string userId);
    void AddBasket(Basket basket);
    void CreateBasket(string userid);
    void UpdateBasket(Basket basket);
    void DeleteBasket(Basket basket);

}
