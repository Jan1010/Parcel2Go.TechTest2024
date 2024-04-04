using FluentAssertions;
using Parcel2Go.TechTest2024.Domain.ProductEntity;

namespace Parcel2Go.TechTest2024.Application.Services.Models
{
    [TestClass]
    public class LineItemTest
    {
        [TestMethod]
        public void Constructor_SetProperties()
        {
            // Arrange
            var product = new Product("A", "Service A", 900);
            // Act
            var lineItem = new LineItem(product);
            // Assert
            lineItem.Product.Should().Be(product);
            lineItem.Quantity.Should().Be(1);
            lineItem.TotalPrice.Should().Be(900);
            lineItem.PromoptionTotalPrice.Should().BeNull();
        }

        [TestMethod]
        public void Quantity_SetTo3_TotalPrice2700()
        {
            // Arrange
            var product = new Product("A", "Service A", 900);
            var lineItem = new LineItem(product);
            // Act
            lineItem.Quantity = 3;
            // Assert
            lineItem.TotalPrice.Should().Be(2700);
        }
    }
}