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
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(o => o.OrderBooks)
       .WithOne(ob => ob.Order)
       .HasForeignKey(ob => ob.OrderId)
       .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o=>o.User)
                .WithMany(u=>u.Orders)
                .HasForeignKey(o=>o.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.OrderDate)
                .IsRequired();

        }

       
    }
}
