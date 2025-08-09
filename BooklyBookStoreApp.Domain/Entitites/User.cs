using Microsoft.AspNetCore.Identity;

namespace BooklyBookStoreApp.Domain.Entitites
{
    public class User:IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string? Adress {  get; set; } 
        public string? City {  get; set; } 
        public string? District {  get; set; } 
        public string? NameSurname {  get; set; } 
        public string? RefreshToken {  get; set; } 
        public DateTime RefreshTokenExpires {  get; set; } 
        
        public ICollection<Order> Orders { get; set; }= new List<Order>();
        public ICollection<Favorites> Favorites { get; set; }= new List<Favorites>();
        public ICollection<BookComment> BookComments { get; set; } = new List<BookComment>();


    }
}
