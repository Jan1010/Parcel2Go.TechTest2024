using Microsoft.Extensions.DependencyInjection;
using Parcel2Go.TechTest2024.Application.Services;
using Parcel2Go.TechTest2024.Application.Services.Abstractions;

namespace Parcel2Go.TechTest2024.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICheckout, Checkout>();
            services.AddTransient<IPromotionService, PromotionService>();
            return services;
        }
    }
}
