

namespace BooklyBookStoreApp.Domain.Entitites;

public class Order
{
    public int Id { get; set; }

    //User ilişkisi
    public string UserId { get; set; }  // Foreign Key
    public User User { get; set; }

    // Order Details
    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }


}
