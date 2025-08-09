

namespace BooklyBookStoreApp.Application.Services
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        ICategoryService CategoryService { get; }
        IUserService UserService { get; }
        IFavoriteService FavoriteService { get; }
        IBasketService BasketService { get; }
        IRoleService RoleService { get; }
        IOrderService OrderService { get; }

    }
}
