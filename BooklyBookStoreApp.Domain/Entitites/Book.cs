

namespace BooklyBookStoreApp.Domain.Entitites
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureURl { get; set; }
        public string? Author { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<BookComment> BookComments { get; set; } = new List<BookComment>();

        public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();


    }
}
