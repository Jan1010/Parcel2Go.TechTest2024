using FluentAssertions;

namespace Parcel2Go.TechTest2024.Infrastructure.Repositories
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public async Task GetByIdAsync_IdB_ReturnProductWithId()
        {
            // Arrange
            var repository = new ProductRepository(BdContextHelper.Create());
            // Act
            var productB = await repository.GetByIdAsync("B");
            // Assert
            productB.Should().NotBeNull();
            productB!.Id.Should().Be("B");
        }
    }
}
