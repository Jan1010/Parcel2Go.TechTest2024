using Microsoft.EntityFrameworkCore;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;

namespace Parcel2Go.TechTest2024.Infrastructure.Repositories
{
    internal class PromotionRepository : IPromotionRepository
    {
        private readonly TechTest2024Context _context;

        public PromotionRepository(TechTest2024Context context)
        {
            _context = context;
        }

        public async Task<Promotion?> GetByProductIdAsync(string productId, CancellationToken cancellationToken = default)
        {
            return await _context.Promotions.SingleOrDefaultAsync(x => x.ProductId == productId, cancellationToken);
        }
    }
}
