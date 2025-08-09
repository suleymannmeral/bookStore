
namespace BooklyBookStoreApp.Domain.Entitites
{
    public class BookComment
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        // User Rel
        public string UserId { get; set; }
        public User User { get; set; }   //navigation property 

        public int BookID { get; set; }
        public Book Book { get; set; }
        public DateTime CreatedAt { get; set; } =DateTime.Now;



    }
}
