using System;
using Shouldly;
using Spk.Common.Helpers.String;
using Xunit;

namespace Spk.Common.Tests.Helpers.String
{
    /// <summary>
    ///     These tests exist just to make sure they call the right API.
    /// </summary>
    public class StringExtensionsTests
    {
        [Fact]
        public void HtmlDecode_ShouldDecodeProperly()
        {
            Assert.Equal("<p>Hi!</p>", "&lt;p&gt;Hi!&lt;/p&gt;".HtmlDecode());
        }

        [Fact]
        public void HtmlEncode_ShouldEncodeProperly()
        {
            Assert.Equal("&lt;p&gt;Hi!&lt;/p&gt;", "<p>Hi!</p>".HtmlEncode());
        }

        [Fact]
        public void IsNullorEmpty_ShouldReturnFalse_WhenNotEmpty()
        {
            Assert.False("test".IsNullOrEmpty());
        }

        [Fact]
        public void IsNullorEmpty_ShouldReturnTrue_WhenEmpty()
        {
            Assert.True("".IsNullOrEmpty());
        }

        [Fact]
        public void IsNullorEmpty_ShouldReturnTrue_WhenNull()
        {
            string test = null;
            Assert.True(test.IsNullOrEmpty());
        }

        [Fact]
        public void RemoveDiacritics_ShouldRemoveDiacritics()
        {
            Assert.Equal("aeio", "àèîô".RemoveDiacritics());
        }

        [Fact]
        public void ToBoolean_ShouldConvertProperly()
        {
            Assert.True("true".ToBoolean());
            Assert.False("false".ToBoolean());
        }

        [Fact]
        public void ToDecimal_ShouldConvertProperly()
        {
            Assert.Equal(42.01m, "42.01".ToDecimal());
        }

        [Fact]
        public void ToFloat_ShouldConvertProperly()
        {
            Assert.Equal(42.01f, "42.01".ToFloat());
        }

        [Fact]
        public void ToInt32_ShouldConvertProperly()
        {
            Assert.Equal(42, "42".ToInt32());
        }

        [Fact]
        public void UrlDecode_ShouldDecodeProperly()
        {
            Assert.Equal("test string", "test+string".UrlDecode());
        }

        [Fact]
        public void UrlEncode_ShouldEncodeProperly()
        {
            Assert.Equal("test+string", "test string".UrlEncode());
        }

        [Fact]
        public void Truncate_ShouldBeEmpty_WhenMaxLengthIs0()
        {
            Assert.Equal(string.Empty, "test".Truncate(0));
        }

        [Fact]
        public void Truncate_ShouldBeTruncateProperly()
        {
            Assert.Equal("te", "test".Truncate(2));
        }

        [Fact]
        public void TruncateWithEllipsis_ShouldCountEllipsis()
        {
            Assert.Equal("...", "test".TruncateWithEllipsis(2));
        }

        [Fact]
        public void TruncateWithEllipsis_ShouldBeTruncateProperly()
        {
            Assert.Equal("ab...", "abcdefghijk of test".TruncateWithEllipsis(5));
        }

        [Fact]
        public void Split_ShouldUseSplitOptions_WhenProvided()
        {
            "Hello //// friend".Split("//").ShouldContain(string.Empty);
            "Hello //// friend".Split("//", System.StringSplitOptions.RemoveEmptyEntries).ShouldNotContain(string.Empty);
        }

        [Theory]
        [InlineData("Hello/friend", '/')]
        public void Split_ShouldUseUnderlyingSplitMethod(string stringToSplit, char separator)
        {
            var splitByStringResult = stringToSplit.Split(separator.ToString(), splitOptions: StringSplitOptions.None);
            var splitByCharResult = stringToSplit.Split(separator);
            splitByStringResult.ShouldBe(splitByCharResult);
        }
    }
}
