namespace BooklyBookStoreApp.Application.DTOs.OrderDtos
{
    public record OrderBookDto(
      int BookId,
      string Title,
      decimal Price,
      string CategoryName,
      int Quantity
  );

}
