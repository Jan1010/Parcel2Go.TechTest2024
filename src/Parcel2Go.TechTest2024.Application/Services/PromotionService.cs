using Parcel2Go.TechTest2024.Application.Services.Abstractions;
using Parcel2Go.TechTest2024.Application.Services.Models;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;

namespace Parcel2Go.TechTest2024.Application.Services
{
    internal class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<int?> GetPriceAsync(LineItem lineItem, CancellationToken cancellationToken = default)
        {
            var promotion = await _promotionRepository.GetByProductIdAsync(lineItem.Product.Id, cancellationToken);
            if (promotion is null || promotion.Quantity > lineItem.Quantity)
            {
                return null;
            }
            var promotionPrice = lineItem.Quantity / promotion.Quantity * promotion.Price;
            var regularPrice = lineItem.Quantity % promotion.Quantity * lineItem.Product.Price;
            return promotionPrice + regularPrice;
        }
    }
}
