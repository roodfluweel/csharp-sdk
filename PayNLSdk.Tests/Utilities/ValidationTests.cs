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

        [Fact]
        public void IsNotNull_DoesNotThrow_ForReferenceValue()
        {
            // Arrange
            object value = new object();

            // Act & Assert
            Should.NotThrow(() => ParameterValidator.IsNotNull(value, nameof(value)));
        }

        [Fact]
        public void IsNotNull_ThrowsArgumentException_ForNullReference()
        {
            // Act & Assert
            Should.Throw<ArgumentException>(() => ParameterValidator.IsNotNull(null!, "param"));
        }

        [Fact]
        public void IsNull_ShouldReturnTrue_WhenValueIsNull()
        {
            // Act
            var result = ParameterValidator.IsNull(null);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNull_ShouldReturnFalse_WhenValueProvided()
        {
            // Act
            var result = ParameterValidator.IsNull("value");

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsNonEmptyInt_ShouldReturnFalse_WhenNull()
        {
            // Act
            var result = ParameterValidator.IsNonEmptyInt(null);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsNonEmptyInt_ShouldReturnTrue_WhenValueProvided()
        {
            // Act
            var result = ParameterValidator.IsNonEmptyInt(5);

            // Assert
            result.ShouldBeTrue();
        }
    }
}
