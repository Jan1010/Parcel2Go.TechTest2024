using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Parcel2Go.TechTest2024.Application.Services.Abstractions;
using Parcel2Go.TechTest2024.Application.Services.Models;
using Parcel2Go.TechTest2024.Domain.ProductEntity;

namespace Parcel2Go.TechTest2024.Application.Services
{
    [TestClass]
    public class CheckoutTest
    {
        [TestMethod]
        public async Task Scan_ProductNotFound_ThrowException()
        {
            // Arrange
            var mocker = new AutoMocker();
            var checkout = mocker.CreateInstance<Checkout>();
            // Act
            var act = async () => await checkout.Scan("X");
            // Assert
            await act.Should().ThrowExactlyAsync<InvalidOperationException>()
                .WithMessage("Product with ID 'X' not found.");
        }

        [TestMethod]
        public async Task Scan_ProductA900_TotalPrice900()
        {
            // Arrange
            var mocker = new AutoMocker();
            mocker.Use<IProductRepository>(x =>
                x.GetByIdAsync("A", default) == Task.FromResult(new Product("A", "Service A", 900)));
            var checkout = mocker.CreateInstance<Checkout>();
            // Act
            await checkout.Scan("A");
            // Assert
            checkout.GetTotalPrice().Should().Be(900);
            mocker.VerifyAll();
        }

        [TestMethod]
        public async Task Scan_TwoProductB1000_TotalPriceWithPromotion1600()
        {
            // Arrange
            var product = new Product("B", "Service B", 1000);
            var mocker = new AutoMocker();
            mocker.Use<IProductRepository>(x =>
                x.GetByIdAsync("B", default) == Task.FromResult(product));
            mocker.Use<IPromotionService>(x =>
                x.GetPriceAsync(It.Is<LineItem>(x => x.Product == product && x.Quantity == 2), default)
                    == Task.FromResult<int?>(1600));
            var checkout = mocker.CreateInstance<Checkout>();
            // Act
            await checkout.Scan("B");
            await checkout.Scan("B");
            // Assert
            checkout.GetTotalPrice().Should().Be(1600);
            mocker.VerifyAll();
        }
    }
}