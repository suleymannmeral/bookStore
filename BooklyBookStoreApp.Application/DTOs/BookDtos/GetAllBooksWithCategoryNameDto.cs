namespace BooklyBookStoreApp.Application.DTOs.BookDtos;

public record GetAllBooksWithCategoryNameDto
   (int Id,
string Title,
string? Description,
decimal Price,
string PictureURl,
string? Author,
string CategoryName
);
