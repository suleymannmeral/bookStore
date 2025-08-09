using BooklyBookStoreApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooklyBookStoreApp.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x=>x.Id);

       

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Author)
               .IsRequired()
               .HasMaxLength(150);


             // Cateogory (many to one)
             builder.HasOne(b=>b.Category)
                .WithMany(c=>c.Books)
                .HasForeignKey(b=>b.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // Favorite (one to many)
            builder.HasMany(b=>b.Favorites)
                .WithOne(f=>f.Book)
                .HasForeignKey(f=>f.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            //  Book - Order BOok

            builder.HasMany(b => b.OrderBooks)
       .WithOne(ob => ob.Book)
       .HasForeignKey(ob => ob.BookId)
       .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.BookComments)
          .WithOne(bc => bc.Book)
          .HasForeignKey(bc => bc.BookID)
          .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
