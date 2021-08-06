using CommerceEF.Configuration;
using Microsoft.EntityFrameworkCore;
using Ord.Core.Models;
using System;

namespace CommerceEF
{
    public class CommerceContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CommerceContext() : base()
        {

        }

        public CommerceContext(DbContextOptions<CommerceContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = Commerce; Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}