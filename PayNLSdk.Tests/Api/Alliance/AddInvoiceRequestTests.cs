using Shouldly;
using Xunit;

namespace PayNLSdk.Tests.Api.Alliance
{
    public class AddInvoiceRequestTests
    {
        private readonly PAYNLSDK.API.Alliance.AddInvoice.Request _sut;

        public AddInvoiceRequestTests()
        {
            _sut = new PAYNLSDK.API.Alliance.AddInvoice.Request(
                "Dummy",
                "Dummy",
                "Dummy",
                "Dummy",
                12345
            );
        }

        [Fact]
        public void GetParameters_ReturnMandatoryProperties_OnCalled()
        {
            // Arrange

            // Act
            var parameters = _sut.GetParameters();

            // Assert
            parameters["serviceId"].ShouldNotBeNull();
            parameters["merchantId"].ShouldNotBeNull();
            parameters["invoiceId"].ShouldNotBeNull();
            parameters["amount"].ShouldNotBeNull();
            parameters["description"].ShouldNotBeNull();
        }

        #region Optional parameters
        [Fact]
        public void MakeYesterday_internalPropertySet_True()
        {
            // Arrange

            // Act
            _sut.MakeYesterday = true;

            // Assert
            _sut.GetParameters()["makeYesterday"].ShouldBe("true");
        }

        [Fact]
        public void MakeYesterday_propertyNotAvailableInInParameters_PropertyIsNotSet()
        {
            // Arrange
            //_sut.MakeYesterday = null;

            // Act
            var parameter = _sut.GetParameters()["makeYesterday"];

            // Assert
            parameter.ShouldBeNull();
        }

        [Fact]
        public void InvoiceUrl_internalPropertySet_True()
        {
            // Arrange
            var httpUrlToInvoice = "http://url.to/invoice";

            // Act
            _sut.InvoiceUrl = httpUrlToInvoice;

            // Assert
            _sut.GetParameters()["invoiceUrl"].ShouldBe(httpUrlToInvoice);
        }

        [Fact]
        public void InvoiceUrl_propertyNotAvailableInInParameters_PropertyIsNotSet()
        {
            // Arrange
            //_sut.MakeYesterday = null;

            // Act
            var parameter = _sut.GetParameters()["invoiceUrl"];
            // Assert
            parameter.ShouldBeNull();
        }
        #endregion
    }
}
