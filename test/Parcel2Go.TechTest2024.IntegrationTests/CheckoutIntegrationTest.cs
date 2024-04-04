using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parcel2Go.TechTest2024.Application;
using Parcel2Go.TechTest2024.Application.Services.Abstractions;
using Parcel2Go.TechTest2024.Infrastructure;

namespace Parcel2Go.TechTest2024.IntegrationTests
{
    [TestClass]
    public class CheckoutIntegrationTest
    {
        [TestMethod]
        public async Task Example1()
        {
            // Arrange
            ICheckout checkout = Initialize();
            // Act
            await checkout.Scan("B");
            await checkout.Scan("B");
            var result = checkout.GetTotalPrice();
            // Assert
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public async Task Example2()
        {
            // Arrange
            ICheckout checkout = Initialize();
            // Act
            await checkout.Scan("F");
            await checkout.Scan("C");
            var result = checkout.GetTotalPrice();
            // Assert
            Assert.AreEqual(2300, result);
        }

        [TestMethod]
        public async Task Example3()
        {
            // Arrange
            ICheckout checkout = Initialize();
            // Act
            await checkout.Scan("F");
            await checkout.Scan("F");
            await checkout.Scan("B");
            var result = checkout.GetTotalPrice();
            // Assert
            Assert.AreEqual(2700, result);
        }

        private static ICheckout Initialize()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            var host = builder.Build();
            host.Services.InitializeInfrastructure();
            var checkout = host.Services.GetRequiredService<ICheckout>();
            return checkout;
        }
    }
}