using FluentAssertions;

namespace Parcel2Go.TechTest2024.Infrastructure.Repositories
{
    [TestClass]
    public class PromotionRepositoryTest
    {
        [TestMethod]
        public async Task GetByProductIdAsync_ProductIdB_ReturnPromotionWithProductId()
        {
            // Arrange
            var repository = new PromotionRepository(BdContextHelper.Create());
            // Act
            var productB = await repository.GetByProductIdAsync("B");
            // Assert
            productB.Should().NotBeNull();
            productB!.ProductId.Should().Be("B");
        }
    }
}
