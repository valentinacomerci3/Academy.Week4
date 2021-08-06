using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ord.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEF.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CustomerCode)
                
                .IsRequired();

            builder
                .Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder
               .HasMany(c => c.Orders)
               .WithOne(o => o.Customer);


            builder.HasData(
               new Customer
               {
                   Id = 1,
                   Name = "Mario",
                   LastName = "Rossi",
                   CustomerCode = "4738539",
                  
               },
               new Customer
               {
                   Id = 2,
                   Name = "Luca",
                   LastName = "Verdi",
                   CustomerCode = "4758954",

               }
           );
        }
    }
}
