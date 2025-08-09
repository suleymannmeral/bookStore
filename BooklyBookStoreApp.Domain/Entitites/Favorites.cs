
namespace BooklyBookStoreApp.Domain.Entitites
{
    public class Favorites
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // Foreign Key
        public User User { get; set; }

        // Kitap İlişkisi
        public int BookID { get; set; }
        public Book Book { get; set; }
        public DateTime CreatedAt  { get; set; }= DateTime.Now;
    }
}
