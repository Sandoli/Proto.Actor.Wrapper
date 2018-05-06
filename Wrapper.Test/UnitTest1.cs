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
        public void CreateThenAskConfigReturnsRightConfig()
        {
            // Arrange
            ServiceFactory.CreateConfig<FooService>("ServiceTest1");
            
            // Act
            var config = ServiceFactory.GetConfig("ServiceTest1");
            
            // Assert
            Assert.NotNull(config);
            Assert.Equal(config.Name, "ServiceTest1");
        }

        [Fact]
        public void CreateThenAskAnotherConfigReturnsNull()
        {
            // Arrange
            // Act
            ServiceFactory.CreateConfig<FooService>("ServiceTest2");
            
            // Assert
            Assert.Null(ServiceFactory.GetConfig("NotKnownServiceTest"));
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
            catch (ArgumentException e)
            {
                // Assert
                Assert.True(true);
            }
        }
    }
}