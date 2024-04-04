using Parcel2Go.TechTest2024.Application.Services.Abstractions;
using Parcel2Go.TechTest2024.Application.Services.Models;
using Parcel2Go.TechTest2024.Domain.ProductEntity;

namespace Parcel2Go.TechTest2024.Application.Services
{
    internal class Checkout : ICheckout
    {
        private readonly Dictionary<string, LineItem> _basket = [];
        private readonly IProductRepository _productRepository;
        private readonly IPromotionService _promotionService;

        public Checkout(
            IProductRepository productRepository,
            IPromotionService promotionService)
        {
            _productRepository = productRepository;
            _promotionService = promotionService;
        }

        public async Task Scan(string id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new InvalidOperationException($"{nameof(Product)} with ID '{id}' not found.");
            }
            if (_basket.TryGetValue(id, out LineItem? lineItem))
            {
                lineItem.Quantity++;
            }
            else
            {
                _basket[id] = new LineItem(product);
            }
            _basket[id].PromoptionTotalPrice = await _promotionService.GetPriceAsync(_basket[id], cancellationToken);
        }

        public int GetTotalPrice()
        {
            return _basket.Sum(x => x.Value.PromoptionTotalPrice ?? x.Value.TotalPrice);
        }
    }
}
