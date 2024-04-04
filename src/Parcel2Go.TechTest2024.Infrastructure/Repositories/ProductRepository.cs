using Microsoft.EntityFrameworkCore;
using Parcel2Go.TechTest2024.Domain.ProductEntity;

namespace Parcel2Go.TechTest2024.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly TechTest2024Context _context;

        public ProductRepository(TechTest2024Context context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
