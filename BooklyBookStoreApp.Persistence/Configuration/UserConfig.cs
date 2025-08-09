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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x=>x.Adress)
                .HasMaxLength(400);
            builder.Property(x => x.City)
               .HasMaxLength(50);
            builder.Property(x => x.District)
               .HasMaxLength(50);

            builder.HasMany(u=>u.Orders)
                .WithOne(o=>o.User)
                .HasForeignKey(o=>o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Favorites)
              .WithOne(f => f.User)
              .HasForeignKey(f => f.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u=>u.BookComments)
                .WithOne(bc=>bc.User)
                .HasForeignKey(bc=>bc.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
