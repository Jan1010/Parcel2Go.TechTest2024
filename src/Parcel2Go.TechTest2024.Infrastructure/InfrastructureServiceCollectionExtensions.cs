using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parcel2Go.TechTest2024.Domain.ProductEntity;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;
using Parcel2Go.TechTest2024.Infrastructure.Repositories;

namespace Parcel2Go.TechTest2024.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<TechTest2024Context>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseInMemoryDatabase("TechTest2024");
            }, ServiceLifetime.Scoped);
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPromotionRepository, PromotionRepository>();
            return services;
        }
    }
}
