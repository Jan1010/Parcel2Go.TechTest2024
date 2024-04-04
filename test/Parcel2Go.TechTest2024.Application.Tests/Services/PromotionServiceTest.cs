using FluentAssertions;
using Moq.AutoMock;
using Parcel2Go.TechTest2024.Application.Services.Models;
using Parcel2Go.TechTest2024.Domain.ProductEntity;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;

namespace Parcel2Go.TechTest2024.Application.Services
{
    [TestClass]
    public class PromotionServiceTest
    {
        [TestMethod]
        public async Task GetPriceAsync_PromotionNotFound_ReturnNull()
        {
            // Arrange
            var lineItem = new LineItem(new Product("A", "Service A", 900));
            var mocker = new AutoMocker();
            var checkout = mocker.CreateInstance<PromotionService>();
            // Act
            var result = await checkout.GetPriceAsync(lineItem);
            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task GetPriceAsync_PromotionNotApplicable_ReturnNull()
        {
            // Arrange
            var lineItem = new LineItem(new Product("A", "Service A", 900));
            var mocker = new AutoMocker();
            mocker.Use<IPromotionRepository>(x =>
                x.GetByProductIdAsync("A", default) == Task.FromResult<Promotion?>(new Promotion(1, "A", 2, 1500)));
            var checkout = mocker.CreateInstance<PromotionService>();
            // Act
            var result = await checkout.GetPriceAsync(lineItem);
            // Assert
            result.Should().BeNull();
            mocker.VerifyAll();
        }

        [TestMethod]
        public async Task GetPriceAsync_TwoProductA_Return1500()
        {
            // Arrange
            var lineItem = new LineItem(new Product("A", "Service A", 900)) { Quantity = 2 };
            var mocker = new AutoMocker();
            mocker.Use<IPromotionRepository>(x =>
                x.GetByProductIdAsync("A", default) == Task.FromResult<Promotion?>(new Promotion(1, "A", 2, 1500)));
            var checkout = mocker.CreateInstance<PromotionService>();
            // Act
            var result = await checkout.GetPriceAsync(lineItem);
            // Assert
            result.Should().Be(1500);
            mocker.VerifyAll();
        }

        [TestMethod]
        public async Task GetPriceAsync_ThreeProductA_Return2400()
        {
            // Arrange
            var lineItem = new LineItem(new Product("A", "Service A", 900)) { Quantity = 3 };
            var mocker = new AutoMocker();
            mocker.Use<IPromotionRepository>(x =>
                x.GetByProductIdAsync("A", default) == Task.FromResult<Promotion?>(new Promotion(1, "A", 2, 1500)));
            var checkout = mocker.CreateInstance<PromotionService>();
            // Act
            var result = await checkout.GetPriceAsync(lineItem);
            // Assert
            result.Should().Be(2400);
            mocker.VerifyAll();
        }
    }
}