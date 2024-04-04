using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using Parcel2Go.TechTest2024.Application.Services;
using Parcel2Go.TechTest2024.Application.Services.Abstractions;

namespace Parcel2Go.TechTest2024.Application
{
    [TestClass]
    public class ApplicationServiceCollectionExtensionsTest
    {
        [TestMethod]
        public void AddApplication_AddTwoServices()
        {
            // Arrange
            var mocker = new AutoMocker();
            var services = mocker.Get<IServiceCollection>();
            // Act
            services.AddApplication();
            // Assert
            mocker.Verify<IServiceCollection>(x => x.Add(It.IsAny<ServiceDescriptor>()), Times.Exactly(2));
        }

        [TestMethod]
        [DataRow(typeof(ICheckout), typeof(Checkout))]
        [DataRow(typeof(IPromotionService), typeof(PromotionService))]
        public void AddApplication_RegisterService(Type serviceType, Type implementationType)
        {
            // Arrange
            var mocker = new AutoMocker();
            var serviceCollection = mocker.Get<IServiceCollection>();
            // Act
            serviceCollection = serviceCollection.AddApplication();
            // Assert
            mocker.Verify<IServiceCollection>(x => x.Add(It.Is<ServiceDescriptor>(y =>
                y.ServiceType == serviceType
                && y.ImplementationType == implementationType
                && y.Lifetime == ServiceLifetime.Transient)), Times.Once());
        }
    }
}
