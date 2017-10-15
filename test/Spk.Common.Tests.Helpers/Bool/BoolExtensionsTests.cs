using Spk.Common.Helpers.Bool;
using Xunit;

namespace Spk.Common.Tests.Helpers.Bool
{
    public class BoolExtensionsTests
    {
        [Fact]
        public void ToNullableBool_ShouldReturnTrue_WhenStringTrue()
        {
            Assert.True("true".ToNullableBool());
            Assert.True("True".ToNullableBool());
            Assert.True("TRUE".ToNullableBool());
            Assert.True(true.ToString().ToNullableBool());
        }

        [Fact]
        public void ToNullableBool_ShouldReturnFalse_WhenJavascriptTrue()
        {
            Assert.False("false".ToNullableBool());
            Assert.False("False".ToNullableBool());
            Assert.False("FALSE".ToNullableBool());
            Assert.False(false.ToString().ToNullableBool());
        }

        [Fact]
        public void ToNullableBool_ShouldReturNull()
        {
            Assert.Null(BoolExtensions.ToNullableBool(null));
        }

        [Fact]
        public void ToNullableBool_ShouldReturNull_WhenBadValue()
        {
            Assert.Null("test".ToNullableBool());
        }
    }
}