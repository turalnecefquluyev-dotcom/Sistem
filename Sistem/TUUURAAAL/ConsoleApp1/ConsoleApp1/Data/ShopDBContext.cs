using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ConsoleApp1.Data
{
    public class ShopDBContext : DbContext
    {

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Ticket> tickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(e =>
            {
                e.Property(p => p.Name).HasMaxLength(100).IsRequired();
                e.Property(p => p.Price).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.Property(o => o.CustomerName).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<OrderItem>(e =>
            {
                e.Property(oi => oi.Price).HasPrecision(18, 2);

                // Product 1 → Many OrderItem
                e.HasOne(oi => oi.Product)
                 .WithMany(p => p.OrderItems)
                 .HasForeignKey(oi => oi.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);   // satılmış məhsulu silmək olmaz

                // Order 1 → Many OrderItem
                e.HasOne(oi => oi.Order)
                 .WithMany(o => o.Items)
                 .HasForeignKey(oi => oi.OrderId)
                 .OnDelete(DeleteBehavior.Cascade);    // order silinəndə item-ləri də silinir
            });

            // Seed data
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Name = "T-Shirt", Price = 25m, Stock = 1 },
                new Ticket { Id = 2, Name = "Jeans", Price = 60m, Stock = 10 },
                new Ticket { Id = 3, Name = "Sneakers", Price = 120m, Stock = 5 });
        }



    }
}
