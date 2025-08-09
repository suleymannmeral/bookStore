
namespace BooklyBookStoreApp.Application.DTOs.BookDtos;

public record CreateBookDto(

    string Title,
    string? Description,
    decimal Price,
    string PictureURl,
    string? Author,
    int CategoryID
    );
