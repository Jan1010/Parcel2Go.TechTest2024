using FluentAssertions;

namespace Parcel2Go.TechTest2024.Domain.PromotionEntity
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void Constructor_SetProperties()
        {
            // Arrange
            var id = 1;
            var productId = "A";
            var quantity = 3;
            var price = 2200;
            // Act
            var product = new Promotion(id, productId, quantity, price);
            // Assert
            product.Id.Should().Be(id);
            product.ProductId.Should().Be(productId);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
        }
    }
}
