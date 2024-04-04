using Parcel2Go.TechTest2024.Application.Services.Models;

namespace Parcel2Go.TechTest2024.Application.Services.Abstractions
{
    internal interface IPromotionService
    {
        Task<int?> GetPriceAsync(LineItem lineItem, CancellationToken cancellationToken = default);
    }
}