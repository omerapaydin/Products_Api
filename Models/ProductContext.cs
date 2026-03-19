using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product()
        {
            ProductId = 1,
            ProductName = "Iphone 14",
            Price = 60000,
            IsActive = true
        },

        new Product()
        {
            ProductId = 2,
            ProductName = "Samsung S23",
            Price = 50000,
            IsActive = true
        },

        new Product()
        {
            ProductId = 3,
            ProductName = "Xiaomi 13",
            Price = 30000,
            IsActive = true
        },

        new Product()
        {
            ProductId = 4,
            ProductName = "Macbook Pro",
            Price = 90000,
            IsActive = true
        },

        new Product()
        {
            ProductId = 5,
            ProductName = "Airpods",
            Price = 8000,
            IsActive = true
        }
                );


        }

        public DbSet<Product> Products { get; set; }
    }
}