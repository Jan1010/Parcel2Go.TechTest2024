using Microsoft.EntityFrameworkCore;

namespace Parcel2Go.TechTest2024.Infrastructure.Repositories
{
    internal static class BdContextHelper
    {
        internal static TechTest2024Context Create()
        {
            var context = new TechTest2024Context(
                new DbContextOptionsBuilder<TechTest2024Context>()
                .UseInMemoryDatabase("TechTest2024").Options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
