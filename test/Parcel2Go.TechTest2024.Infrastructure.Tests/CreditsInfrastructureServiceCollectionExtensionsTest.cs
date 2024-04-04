using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using Parcel2Go.TechTest2024.Domain.ProductEntity;
using Parcel2Go.TechTest2024.Domain.PromotionEntity;
using Parcel2Go.TechTest2024.Infrastructure.Repositories;

namespace Parcel2Go.TechTest2024.Infrastructure
{

    [TestClass]
    public class InfrastructureServiceCollectionExtensionsTest
    {
        [TestMethod]
        public void AddInfrastructure_RegisterSpecificNumberOfServices()
        {
            // Arrange
            var mocker = new AutoMocker();
            mocker.Use<IServiceCollection>(x => x.GetEnumerator() == new List<ServiceDescriptor>().AsEnumerable().GetEnumerator());
            var serviceCollection = mocker.Get<IServiceCollection>();
            // Act
            var serviceCollectionResult = serviceCollection.AddInfrastructure();
            // Assert
            mocker.Verify<IServiceCollection>(x => x.Add(It.IsAny<ServiceDescriptor>()), Times.Exactly(6));
        }

        [TestMethod]
        [DataRow(typeof(TechTest2024Context), typeof(TechTest2024Context), ServiceLifetime.Scoped)]
        [DataRow(typeof(IProductRepository), typeof(ProductRepository), ServiceLifetime.Transient)]
        [DataRow(typeof(IPromotionRepository), typeof(PromotionRepository), ServiceLifetime.Transient)]
        public void AddInfrastructure_RegisterService(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            // Arrange
            var mocker = new AutoMocker();
            mocker.Use<IServiceCollection>(x => x.GetEnumerator() == new List<ServiceDescriptor>().AsEnumerable().GetEnumerator());
            var serviceCollection = mocker.Get<IServiceCollection>();
            // Act
            var serviceCollectionResult = serviceCollection.AddInfrastructure();
            // Assert
            serviceCollectionResult.Should().BeSameAs(serviceCollection);
            mocker.Verify<IServiceCollection>(x => x.Add(It.Is<ServiceDescriptor>(y =>
                  y.ServiceType == serviceType
                  && y.ImplementationType == implementationType
                  && y.Lifetime == lifetime)), Times.Once());
        }
    }
}
