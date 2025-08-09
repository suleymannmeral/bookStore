

namespace BooklyBookStoreApp.Application.DTOs.Favorites;

public record CreateFavoriteDto(
    int BookID,
    string UserId
    );

