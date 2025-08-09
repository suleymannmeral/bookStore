using AutoMapper;
using BooklyBookStoreApp.Application.DTOs.Favorites;
using BooklyBookStoreApp.Application.DTOs.FavoritesDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooklyBookStoreApp.Persistence.Services;

public sealed class FavoriteService(IRepositoryManager manager, IMapper mapper) : IFavoriteService
{


    public async Task<FavoriteDto> CreateFavoriteAsync(CreateFavoriteDto createFavoriteDto)
    {
        var favorite = mapper.Map<Favorites>(createFavoriteDto);
        manager.Favorite.Create(favorite);
        await manager.Save();
        return  mapper.Map<FavoriteDto>(favorite);

    }

  

    public async Task<IEnumerable<GetAllFavoritesByUsernameWithBookDetailsDto>> GetAllFavoritesByUserIdWithBookDetailsAsync(string userid)
    {
        var favorites = await manager.Favorite.GetAll(false)
      .Include(f => f.Book)
      .Include(f => f.User)
      .Where(f => f.User.Id == userid)
      .ToListAsync();

        var result = mapper.Map<List<GetAllFavoritesByUsernameWithBookDetailsDto>>(favorites);
        return result;

    }

    public FavoriteDto GetFavoriteByIdAsync(int id, bool trackChanges)
    {
        var favorite= manager.Favorite.GetOneFavoriteById(id,trackChanges).FirstOrDefault();
        return  mapper.Map<FavoriteDto>(favorite);
    }

    public async Task DeleteFavoriteAsync(int id, bool trackChanges)
    {
       var favorite=  GetFavoriteByIdAsync(id,trackChanges);
       var result= mapper.Map<Favorites>(favorite);
        manager.Favorite.Delete(result);
       await  manager.Save();
    }
}
