using Microsoft.Extensions.DependencyInjection;

namespace Parcel2Go.TechTest2024.Infrastructure
{
    public static class InfrastructureServiceProviderExtensions
    {
        public static IServiceProvider InitializeInfrastructure(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TechTest2024Context>();
            context.Database.EnsureCreated();
            return serviceProvider;
        }
    }
}
