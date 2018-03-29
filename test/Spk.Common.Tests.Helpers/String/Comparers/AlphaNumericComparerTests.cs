using System.Linq;
using Shouldly;
using Spk.Common.Helpers.String.Comparers;
using Xunit;

namespace Spk.Common.Tests.Helpers.String.Comparers
{
    public class AlphaNumericComparerTests
    {
        [Theory]
        [InlineData("1", "-1")]
        [InlineData("test", "0")]
        [InlineData(null, "1")]
        public void Compare_ShouldReturnGreater_WhenFirstParamGreaterThanSecondParam(string str1, string str2)
        {
            // Arrange & assert
            new AlphaNumericComparer().Compare(str1, str2).ShouldBe(1);
        }

        [Theory]
        [InlineData("0", "0")]
        [InlineData("string", "string")]
        public void Compare_ShouldReturnEquality_WhenFirstParamEqualsSecondParam(string str1, string str2)
        {
            // Arrange & assert
            new AlphaNumericComparer().Compare(str1, str2).ShouldBe(0);
        }

        [Theory]
        [InlineData("9", "10")]
        [InlineData("0", "10")]
        [InlineData("0", "test")]
        [InlineData(null, "test")]
        public void Compare_ShouldReturnLess_WhenFirstParamLessThanSecondParam(string str1, string str2)
        {
            // Arrange & assert
            new AlphaNumericComparer().Compare(str1, str2).ShouldBe(-1);
        }

        [Fact]
        public void Compare_ShouldOrderBasedOnValue_WhenNumeric()
        {
            // Arrange
            var toBeOrdered = new[] {"10", "1", "2"};

            // Act
            var result = toBeOrdered.OrderBy(x => x, new AlphaNumericComparer());

            // Assert
            Assert.Collection(result,
                x => x.ShouldBe("1"),
                x => x.ShouldBe("2"),
                x => x.ShouldBe("10")
            );
        }

        [Fact]
        public void Compare_ShouldOrderNullBetweenAlphaAndNumeric_WhenAlphaNumericWithNull()
        {
            // Arrange
            var toBeOrdered = new[] {"test", "1", null};

            // Act
            var result = toBeOrdered.OrderBy(x => x, new AlphaNumericComparer());

            // Assert
            Assert.Collection(result,
                x => x.ShouldBe("1"),
                x => x.ShouldBe(null),
                x => x.ShouldBe("test")
            );
        }

        [Fact]
        public void Compare_ShouldOrderNumericFirst_WhenAlphaNumeric()
        {
            // Arrange
            var toBeOrdered = new[] {"test", "a", "10", "2"};

            // Act
            var result = toBeOrdered.OrderBy(x => x, new AlphaNumericComparer());

            // Assert
            Assert.Collection(result,
                x => x.ShouldBe("2"),
                x => x.ShouldBe("10"),
                x => x.ShouldBe("a"),
                x => x.ShouldBe("test")
            );
        }
    }
}
