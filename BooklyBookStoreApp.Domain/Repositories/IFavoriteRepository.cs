using BooklyBookStoreApp.Domain.Entitites;

namespace BooklyBookStoreApp.Domain.Repositories;

public interface IFavoriteRepository:IRepositoryBase<Favorites>
{
    void CreateFavorite(Favorites favorites);
    IQueryable<Favorites> GetAll(bool trackChanges);

    IQueryable<Favorites> GetOneFavoriteById(int id, bool trackChanges);



}
