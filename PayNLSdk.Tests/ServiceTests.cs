using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayNLSdk;
using PayNLSdk.Net;

namespace PayNLSdk.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private Mock<IClient> _iClientMock;
        private ServiceClient _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _iClientMock = new Mock<IClient>();
            _sut = new ServiceClient(_iClientMock.Object);
        }

        [TestMethod]
        public void GetCategories_withoutParams()
        {
            // Arrange

            // Act
            var result = _sut.GetCategories();

            // Assert
            _iClientMock.Verify(
                o => o.PerformRequest(It.IsAny<PayNLSdk.API.Service.GetCategories.Request>()),
                Times.Once);
            // Assert.IsNotNull(result); // UNTESTABLE CURRENTLY
        }

        [TestMethod]
        public void GetCategories_withParams()
        {
            // Arrange
            int paymentOptionId = 1;

            // Act
            var result = _sut.GetCategories(paymentOptionId);

            // Assert
            _iClientMock.Verify(
                o => o.PerformRequest(It.IsAny<PayNLSdk.API.Service.GetCategories.Request>()),
                Times.Once);
            // Assert.IsNotNull(result); // UNTESTABLE CURRENTLY
        }
    }
}
