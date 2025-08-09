using BooklyBookStoreApp.Domain.Entitites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BooklyBookStoreApp.Persistence.Context
{
    public sealed class AppDbContext : IdentityDbContext<User,Role,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

            modelBuilder.Ignore <IdentityUserLogin<string>>();
            modelBuilder.Ignore <IdentityUserRole<string>>();
            modelBuilder.Ignore <IdentityUserClaim<string>>();
            modelBuilder.Ignore <IdentityUserToken<string>>();
            modelBuilder.Ignore <IdentityRoleClaim<string>>();
            modelBuilder.Ignore <IdentityRole<string>>();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        // diğer DbSet'ler
    }
}
