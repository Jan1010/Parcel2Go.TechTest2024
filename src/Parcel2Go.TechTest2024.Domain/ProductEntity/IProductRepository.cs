namespace Parcel2Go.TechTest2024.Domain.ProductEntity
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
