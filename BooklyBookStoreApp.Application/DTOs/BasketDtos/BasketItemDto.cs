
namespace BooklyBookStoreApp.Application.DTOs.BasketDtos;

public class BasketItemDto
{
    public int BookId { get; set; }
    public int Quantity { get; set; }

    public string BookTitle { get; set; } = default!;
    public decimal BookPrice { get; set; }
}
