using BooklyBookStoreApp.Application.DTOs.BookDtos;
using BooklyBookStoreApp.Application.DTOs.Favorites;
using BooklyBookStoreApp.Application.DTOs.FavoritesDtos;

namespace BooklyBookStoreApp.Application.Services;

public interface IFavoriteService
{
    Task<FavoriteDto> CreateFavoriteAsync(CreateFavoriteDto createFavoriteDto);
    Task DeleteFavoriteAsync(int id,bool trackChanges);
    FavoriteDto GetFavoriteByIdAsync(int id,bool trackChanges);
    Task<IEnumerable<GetAllFavoritesByUsernameWithBookDetailsDto>> GetAllFavoritesByUserIdWithBookDetailsAsync(string userid);


}
