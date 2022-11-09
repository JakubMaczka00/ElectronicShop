using MainBusiness;
using Microsoft.EntityFrameworkCore;
using System;


namespace DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Karta graficzna", Description = "Nvidia" }
                );
            modelBuilder.Entity<Product>().HasData(
                
                new Product { ProductId = 1, CategoryId = 1, Name = "Nvidia GTX 760", Quantity = 5, Price = 33.22 }
                );
        }
    }
}
