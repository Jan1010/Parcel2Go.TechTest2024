using Microsoft.EntityFrameworkCore;
using Parcel2Go.TechTest2024.Domain.ProductEntity;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;
using Parcel2Go.TechTest2024.Infrastructure.Configurations;

namespace Parcel2Go.TechTest2024.Infrastructure
{
    internal class TechTest2024Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public TechTest2024Context(
            DbContextOptions<TechTest2024Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());

            // Seeds
            SeedProducts(modelBuilder);
            SeedPromotions(modelBuilder);
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product("A", "Service A", 1000));
            modelBuilder.Entity<Product>().HasData(new Product("B", "Service B", 1200));
            modelBuilder.Entity<Product>().HasData(new Product("C", "Service C", 1500));
            modelBuilder.Entity<Product>().HasData(new Product("D", "Service D", 2500));
            modelBuilder.Entity<Product>().HasData(new Product("F", "Service F", 800));
        }

        private void SeedPromotions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>().HasData(new Promotion(1, "A", 3, 2500));
            modelBuilder.Entity<Promotion>().HasData(new Promotion(2, "B", 2, 2000));
            modelBuilder.Entity<Promotion>().HasData(new Promotion(3, "F", 2, 1500));
        }
    }
}
