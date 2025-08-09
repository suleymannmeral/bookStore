using BooklyBookStoreApp.Domain.Repositories;
using BooklyBookStoreApp.Persistence.Context;

namespace BooklyBookStoreApp.Persistence.Repositorires;

public class RepositoryManager : IRepositoryManager         //unit of work pattern  RepositoryManager, birden fazla repository'yi yöneten bir sınıf
{
    private readonly AppDbContext _context;
    private readonly Lazy<IBookRepository> _bookRepository;          // 
    private readonly Lazy<ICategoryRepository> _categoryRepository;          // 
    private readonly Lazy<IFavoriteRepository> _favoriteRepository;          // 
    private readonly Lazy<IBasketRepository> _basketRepository;          // 
    private readonly Lazy<IUserRoleRepository> _userRoleRepository;          // 
    private readonly Lazy<IOrderRepository> _orderRepository;          // 

    public RepositoryManager(AppDbContext context)
    {
        _context = context;
        _bookRepository= new Lazy<IBookRepository>(() => new BookRepository(context)); 
        _categoryRepository= new Lazy<ICategoryRepository>(() => new CategoryRepository(context)); 
        _favoriteRepository= new Lazy<IFavoriteRepository>(() => new FavoriteRepository(context)); 
        _basketRepository= new Lazy<IBasketRepository>(() => new BasketRepository(context)); 
        _userRoleRepository= new Lazy<IUserRoleRepository>(() => new UserRoleRepository(context)); 
        _orderRepository= new Lazy<IOrderRepository>(() => new OrderRepository(context)); 
    }

    public IBookRepository Book => _bookRepository.Value;          // newlenmis hali donuelcek nesne kullanıldıgı anda ilgili ifade newlenir
    public ICategoryRepository Category => _categoryRepository.Value;      
    public IFavoriteRepository Favorite => _favoriteRepository.Value;      
    public IBasketRepository Basket => _basketRepository.Value;      
    public IUserRoleRepository UserRole => _userRoleRepository.Value;      
    public IOrderRepository Order => _orderRepository.Value;      

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
