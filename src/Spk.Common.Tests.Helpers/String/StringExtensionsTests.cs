using Spk.Common.Helpers.String;
using Xunit;

namespace Spk.Common.Tests.Helpers.String
{
    /// <summary>
    /// These tests exist just to make sure they call the right API.
    /// </summary>
    public class StringExtensionsTests
    {
        [Fact]
        public void IsNullorEmpty_ShouldReturnTrue_WhenNull()
        {
            string test = null;
            Assert.True(test.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullorEmpty_ShouldReturnTrue_WhenEmpty()
        {
            Assert.True("".IsNullOrEmpty());
        }

        [Fact]
        public void IsNullorEmpty_ShouldReturnFalse_WhenNotEmpty()
        {
            Assert.False("test".IsNullOrEmpty());
        }

        [Fact]
        public void HtmlEncode_ShouldEncodeProperly()
        {
            var result = "<p>Hi!</p>".HtmlEncode();
            Assert.Equal("&lt;p&gt;Hi!&lt;/p&gt;", result);
        }

        [Fact]
        public void HtmlDecode_ShouldDecodeProperly()
        {
            var result = "&lt;p&gt;Hi!&lt;/p&gt;".HtmlDecode();
            Assert.Equal("<p>Hi!</p>", result);
        }

        [Fact]
        public void UrlEncode_ShouldEncodeProperly()
        {
            var result = "test string".UrlEncode();
            Assert.Equal("test+string", result);
        }

        [Fact]
        public void UrlDecode_ShouldDecodeProperly()
        {
            var result = "test+string".UrlDecode();
            Assert.Equal("test string", result);
        }
    }
}