using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parcel2Go.TechTest2024.Domain.ProductEntity;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;

namespace Parcel2Go.TechTest2024.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne<Promotion>()
                .WithOne()
                .HasForeignKey<Promotion>(x => x.ProductId);
        }
    }
}