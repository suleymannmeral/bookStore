namespace BooklyBookStoreApp.Application.DTOs.OrderDtos
{
    public record CreateOrderBookDto(
        int BookId,
        int Quantity
    );
}
