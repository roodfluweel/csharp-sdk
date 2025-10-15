using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayNLSdk.Api.Transaction.Refund;

namespace PayNLSdk.Tests.Api.Transaction;

[TestClass]
public class TransactionRefundTests
{
    [TestMethod]
    public void Request_AmountInCents_PassedInAsDecimal()
    {
        // Arrange
        var sut = new Request
        {
            TransactionId = "DUMMY",
            Amount = 3.50m
        };

        // Act
        var result = sut.GetParameters();

        // Assert
        Assert.AreEqual("350", result["amount"]);
    }

    [TestMethod]
    public void Request_NoAmountSupplied_NoParameterWithAmount()
    {
        // Arrange
        var sut = new Request
        {
            TransactionId = "DUMMY",
            Amount = null
        };

        // Act
        var result = sut.GetParameters();

        // Assert
        Assert.IsNull(result["amount"]);
    }


}