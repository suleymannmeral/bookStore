namespace BooklyBookStoreApp.Application.DTOs.BookDtos;

public record UpdateBookDto(
 
 string Title,
 string? Description,
 decimal Price,
 string PictureURl,
 string? Author,
 int CategoryID
 );
