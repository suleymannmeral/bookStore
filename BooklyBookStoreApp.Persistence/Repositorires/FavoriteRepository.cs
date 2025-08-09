using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using BooklyBookStoreApp.Persistence.Context;


namespace BooklyBookStoreApp.Persistence.Repositorires;

public class FavoriteRepository : RepositoryBase<Favorites>, IFavoriteRepository
{
    public FavoriteRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateFavorite(Favorites favorites) => Create(favorites);

    public IQueryable<Favorites> GetAll(bool trackChanges) => FindAll(trackChanges);

    public IQueryable<Favorites> GetOneFavoriteById(int id, bool trackChanges)=>
        FindByCondition(c => c.Id == id, trackChanges);

}
