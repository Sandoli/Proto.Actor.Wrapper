using System;
using System.Threading.Tasks;
using Xunit;

namespace Wrapper.Test
{
    internal class FooService : IService
    {
        public Task ReceiveAsync(IContext context)
        {
            throw new NotImplementedException();
        }
    }

    internal class BarService : IService
    {
        public Task ReceiveAsync(IContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceTest
    {
        [Fact]
        public void CreateThenAskAnotherConfigReturnsNull()
        {
            // Arrange
            // Act
            ServiceFactory.CreateConfig<FooService>("ServiceTest2");

            // Assert
            Assert.Null(ServiceFactory.GetConfig("UnknownServiceTest"));
        }

        [Fact]
        public void CreateThenAskConfigReturnsRightConfig()
        {
            // Arrange
            var createdConfig = ServiceFactory.CreateConfig<FooService>("ServiceTest1");

            // Act
            var retrievedConfig = ServiceFactory.GetConfig("ServiceTest1");

            // Assert
            Assert.NotNull(retrievedConfig);
            Assert.Equal("ServiceTest1", retrievedConfig.Name);
            Assert.Equal(retrievedConfig, createdConfig);
        }

        [Fact]
        public void CreateTwiceConfigWithTheSameNameRaisesException()
        {
            // Arrange
            ServiceFactory.CreateConfig<FooService>("ServiceTest3");

            try
            {
                // Act
                ServiceFactory.CreateConfig<BarService>("ServiceTest3");

                // Assert
                Assert.True(false, "Exception should have been raised");
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.True(true);
            }
        }
    }
}