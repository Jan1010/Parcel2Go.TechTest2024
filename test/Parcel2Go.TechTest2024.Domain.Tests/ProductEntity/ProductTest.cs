using FluentAssertions;

namespace Parcel2Go.TechTest2024.Domain.ProductEntity
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Constructor_SetProperties()
        {
            // Arrange
            var id = "A";
            var name = "Service A";
            var price = 900;
            // Act
            var product = new Product(id, name, price);
            // Assert
            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Price.Should().Be(price);
        }
    }
}