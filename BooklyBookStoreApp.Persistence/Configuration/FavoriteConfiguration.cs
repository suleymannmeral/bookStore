using BooklyBookStoreApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Persistence.Configuration
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorites>
    {
        public void Configure(EntityTypeBuilder<Favorites> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f=>f.Book)
                .WithMany(b=>b.Favorites)
                .HasForeignKey(f=>f.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.User)
             .WithMany(u => u.Favorites)
             .HasForeignKey(f => f.UserId)
             .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
