

namespace BooklyBookStoreApp.Domain.Entitites;

public class Basket
{
    public int Id { get; set; }

    public string UserId { get; set; }  // Foreign Key
    public User User { get; set; }

    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

    public DateTime CreatedDate { get; set; } = DateTime.Now;

}
