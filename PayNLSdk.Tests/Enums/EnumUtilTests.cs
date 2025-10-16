using System;
using PAYNLSDK.Enums;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests.Enums
{
    public class EnumUtilTests
    {
        [Fact]
        public void ToEnumString_Generic_ShouldReturnEnumMemberValue()
        {
            // Arrange
            const Gender gender = Gender.Male;

            // Act
            var value = EnumUtil.ToEnumString(gender);

            // Assert
            value.ShouldBe("m");
        }

        [Fact]
        public void ToEnumString_WithType_ShouldReturnEnumMemberValue()
        {
            // Arrange
            object paymentMethod = PaymentMethodId.PayPerTransaction;

            // Act
            var value = EnumUtil.ToEnumString(paymentMethod, typeof(PaymentMethodId));

            // Assert
            value.ShouldBe("4");
        }

        [Fact]
        public void ToEnum_Generic_ShouldReturnEnumByEnumMember()
        {
            // Arrange
            const string input = "f";

            // Act
            var gender = EnumUtil.ToEnum<Gender>(input);

            // Assert
            gender.ShouldBe(Gender.Female);
        }

        [Fact]
        public void ToEnum_Generic_ShouldReturnDefaultWhenUnknown()
        {
            // Arrange
            const string input = "unknown";

            // Act
            var gender = EnumUtil.ToEnum<Gender>(input);

            // Assert
            gender.ShouldBe(default(Gender));
        }

        [Fact]
        public void ToEnum_WithType_ShouldReturnEnumByEnumMember()
        {
            // Arrange
            const string input = "H";

            // Act
            var taxClass = (TaxClass)EnumUtil.ToEnum(input, typeof(TaxClass));

            // Assert
            taxClass.ShouldBe(TaxClass.High);
        }

        [Fact]
        public void ToEnum_WithType_ShouldReturnFirstEnumValueWhenUnknown()
        {
            // Arrange
            const string input = "zzz";

            // Act
            var result = EnumUtil.ToEnum(input, typeof(PaymentMethodId));

            // Assert
            result.ShouldBe(PaymentMethodId.Sms);
        }

        [Fact]
        public void ToEnumString_ShouldThrow_WhenEnumValueWithoutEnumMemberAttribute()
        {
            // Arrange
            var consoleColor = (ConsoleColor)0;

            // Act & Assert
            Should.Throw<InvalidOperationException>(() => EnumUtil.ToEnumString(consoleColor, typeof(ConsoleColor)));
        }
    }
}
