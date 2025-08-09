namespace BooklyBookStoreApp.Domain.Repositories;

public interface IRepositoryManager                          // Repoları Buradan Yöneteceğiz
{
    IBookRepository Book { get; }
    ICategoryRepository Category { get; }
    IFavoriteRepository Favorite { get; }
    IBasketRepository Basket { get; }
    IUserRoleRepository UserRole { get; }
    IOrderRepository Order { get; }
    
    Task Save();


}
