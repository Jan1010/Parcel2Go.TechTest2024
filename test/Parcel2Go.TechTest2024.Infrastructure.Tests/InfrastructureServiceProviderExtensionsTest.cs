using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Moq.AutoMock;

namespace Parcel2Go.TechTest2024.Infrastructure
{
    [TestClass]
    public class InfrastructureServiceProviderExtensionsTest
    {
        [TestMethod]
        public void InitializeInfrastructure_EnsureCreated()
        {
            // Arrange
            var mocker = new AutoMocker();
            var creditsContextMock = new Mock<TechTest2024Context>(new DbContextOptions<TechTest2024Context>());
            var databaseFacadeMock = new Mock<DatabaseFacade>(creditsContextMock.Object);
            creditsContextMock
                .SetupGet(x => x.Database)
                .Returns(() => databaseFacadeMock.Object);
            var creditsContext = creditsContextMock.Object;
            mocker.Use<IServiceProvider>(x => x.GetService(typeof(TechTest2024Context)) == creditsContext);
            var serviceProvider = mocker.Get<IServiceProvider>();
            // Act
            InfrastructureServiceProviderExtensions.InitializeInfrastructure(serviceProvider);
            // Assert
            databaseFacadeMock.Verify(x => x.EnsureCreated(), Times.Once());
        }
    }
}
