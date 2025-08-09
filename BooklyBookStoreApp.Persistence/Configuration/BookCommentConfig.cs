using BooklyBookStoreApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BooklyBookStoreApp.Persistence.Configuration
{
    public class BookCommentConfig : IEntityTypeConfiguration<BookComment>
    {
        public void Configure(EntityTypeBuilder<BookComment> builder)
        {
           builder.HasKey(c=>c.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(c => c.Book)
                .WithMany(b => b.BookComments)
                .HasForeignKey(c => c.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.User)
                .WithMany(u => u.BookComments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
