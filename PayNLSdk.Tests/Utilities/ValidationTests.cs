using System;
using PAYNLSDK.Utilities;
using Shouldly;
using Xunit;

namespace PayNLSdk.Tests.Utilities
{
    public class ValidationTests
    {
        [Fact]
        public void IsNotEmpty_DoesNotThrow_AbcInput()
        {
            // Arrange
            var input = "abc";

            // Act & Assert
            Should.NotThrow(() => ParameterValidator.IsNotEmpty(input, "someParamName"));
        }

        [Fact]
        public void IsNotEmpty_ThrowsException_EmptyString()
        {
            // Arrange
            var input = string.Empty;

            // Act & Assert
            Should.Throw<ArgumentException>(() => ParameterValidator.IsNotEmpty(input, "someParamName"));
        }

        [Fact]
        public void IsEmpty_False_AbcInput()
        {
            // Arrange
            var input = "abc";

            // Act
            var result = ParameterValidator.IsEmpty(input);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsEmpty_True_EmptyString()
        {
            // Arrange
            var input = string.Empty;

            // Act
            var result = ParameterValidator.IsEmpty(input);

            // Assert
            result.ShouldBeTrue();
        }
    }
}
