
namespace BooklyBookStoreApp.Domain.Entitites;

public class BasketItem
{
   
    public int Id { get; set; }

    public int BasketId { get; set; }
    public Basket Basket { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int Quantity { get; set; }
    
}
