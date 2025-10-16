using Shouldly;
using Xunit;

namespace PayNlSdk.Tests.Api.Transaction
{
    public class TransactionRefundTests
    {
        [Fact]
        public void Request_AmountInCents_PassedInAsDecimal()
        {
            // Arrange
            var sut = new PayNlSdk.Api.Transaction.Refund.Request
            {
                TransactionId = "DUMMY",
                Amount = 3.50m
            };

            // Act
            var result = sut.GetParameters();

            // Assert
            result["amount"].ShouldBe("350");
        }

        [Fact]
        public void Request_NoAmountSupplied_NoParameterWithAmount()
        {
            // Arrange
            var sut = new PayNlSdk.Api.Transaction.Refund.Request
            {
                TransactionId = "DUMMY",
                Amount = null
            };

            // Act
            var result = sut.GetParameters();

            // Assert
            result["amount"].ShouldBeNull();
        }
    }
}
