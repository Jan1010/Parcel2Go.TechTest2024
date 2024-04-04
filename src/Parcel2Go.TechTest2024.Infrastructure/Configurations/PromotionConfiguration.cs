using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parcel2Go.TechTest2024.Domain.ProductEntity;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;

namespace Parcel2Go.TechTest2024.Infrastructure.Configurations
{
    internal class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasOne<Product>()
                .WithOne()
                .HasForeignKey<Promotion>(x => x.ProductId);
        }
    }
}