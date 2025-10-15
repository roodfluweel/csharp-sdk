using NSubstitute;
using PAYNLSDK;
using PAYNLSDK.Net;
using Xunit;

namespace PayNLSdk.Tests
{
    public class ServiceTests
    {
        private readonly IClient _client;
        private readonly Service _sut;

        public ServiceTests()
        {
            _client = Substitute.For<IClient>();
            _sut = new Service(_client);
        }

        [Fact]
        public void GetCategories_withoutParams()
        {
            // Arrange

            // Act
            _sut.GetCategories();

            // Assert
            _client.Received(1).PerformRequest(Arg.Any<PAYNLSDK.API.Service.GetCategories.Request>());
            // Assert.IsNotNull(result); // UNTESTABLE CURRENTLY
        }

        [Fact]
        public void GetCategories_withParams()
        {
            // Arrange
            const int paymentOptionId = 1;

            // Act
            _sut.GetCategories(paymentOptionId);

            // Assert
            _client.Received(1).PerformRequest(Arg.Any<PAYNLSDK.API.Service.GetCategories.Request>());
            // Assert.IsNotNull(result); // UNTESTABLE CURRENTLY
        }
    }
}
