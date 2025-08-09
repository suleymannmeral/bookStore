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
    public class OrderBookConfiguration : IEntityTypeConfiguration<OrderBook>
    {
        public void Configure(EntityTypeBuilder<OrderBook> builder)
        {
            builder.HasKey(ob => new { ob.OrderId, ob.BookId });

            // Order İlişkisi

            builder.HasOne(ob => ob.Order)
                .WithMany(o => o.OrderBooks)
                .HasForeignKey(ob => ob.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ob => ob.Book)
              .WithMany(b => b.OrderBooks)
              .HasForeignKey(ob => ob.BookId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ob => ob.Quantity)
                .IsRequired();

        }
    }
}
