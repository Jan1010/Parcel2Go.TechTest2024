namespace Parcel2Go.TechTest2024.Domain.PromotionEntity
{
    public interface IPromotionRepository
    {
        Task<Promotion?> GetByProductIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
