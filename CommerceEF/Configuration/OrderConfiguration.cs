using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ord.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEF.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.OrderDate)
                .IsRequired();

            builder
                .Property(o => o.OrderCode)
                .IsRequired();

            builder
                .Property(o => o.ProductCode)
                .IsRequired();

            builder
               .Property(o => o.Cost)
               .IsRequired();

            builder
                .HasOne(o => o.Customer)
                .WithMany(C => C.Orders);

            builder.HasData(
               new Order
               {
                   Id = 1,
                   OrderDate =new DateTime(12/10/12),
                   OrderCode = "82299",
                   ProductCode = "400239",
                   Cost= 7,
                   

               },
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(12 / 02 / 21),
                    OrderCode = "8913j9",
                    ProductCode = "40008539",
                    Cost = 5,


                },
                new Order
                {
                    Id = 3,
                    OrderDate = new DateTime(11/ 10/ 18),
                    OrderCode = "890009",
                    ProductCode = "4118679",
                    Cost = 3,


                },
                new Order
                {
                    Id = 4,
                    OrderDate = new DateTime(01 / 10 / 20),
                    OrderCode = "89ft434",
                    ProductCode = "474yuh539",
                    Cost = 9,


                }
           );
        }
    }
}
