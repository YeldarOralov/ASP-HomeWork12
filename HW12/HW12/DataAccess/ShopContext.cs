using HW12.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW12.DataAccess
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product { Name = "Pepsi", Cost = 250 },
                new Product { Name = "Cola", Cost = 150 },
                new Product { Name = "Snickers", Cost = 200 }
                ); 
            builder.Entity<Basket>().HasData(
                new Basket { Products = new List<Product>()}
                );
        }
    }
}
