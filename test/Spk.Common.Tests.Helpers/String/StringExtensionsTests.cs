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
        public void Split_ShouldNotContainEmptyString()
        {
            "Hello //// friend".Split("//").ShouldContain(string.Empty);
        }

        [Fact]
        public void Split_ShouldNotContainEmptyString_WhenSplitOptionsRemoveEmptyEntries()
        {
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

        [Fact]
        public void FormatWith_ShouldFormat_WhenPerfectMatchWithData()
        {
            var stringToFormat = "My name is {firstName} {lastName}, I am {age} years old.";
            var data = new
            {
                firstName = "François",
                lastName = "LN",
                age = 28
            };

            Assert.Equal("My name is François LN, I am 28 years old.", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WithNullData()
        {
            var stringToFormat = "My name is {firstName} {lastName}, I am {age} years old.";
            var data = new
            {
                firstName = (string) null,
                lastName = "LN",
                age = 28
            };

            Assert.Equal("My name is  LN, I am 28 years old.", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WithDoubleData()
        {
            var stringToFormat = "My name is {firstName} {lastName}, I am {age} years old. {age}";
            var data = new
            {
                firstName = "François",
                lastName = "LN",
                age = 28
            };

            Assert.Equal("My name is François LN, I am 28 years old. 28", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WhenExtraDataMarkerInString()
        {
            var stringToFormat = "My name is {firstName} {lastName}, I am {age} years old.";
            var data = new
            {
                firstName = "François",
                lastName = "LN",
            };

            Assert.Equal("My name is François LN, I am  years old.", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WhenExtraDataInObject()
        {
            var stringToFormat = "My name is {firstName} {lastName}.";
            var data = new
            {
                firstName = "François",
                lastName = "LN",
                age = 28
            };

            Assert.Equal("My name is François LN.", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WithEmptyString()
        {
            var stringToFormat = "";
            var data = new
            {
                firstName = "François",
                lastName = "LN",
                age = 28
            };

            Assert.Equal("", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WithNoData()
        {
            var stringToFormat = "My name real name is Olivier {var}.";
            var data = new {};

            Assert.Equal("My name real name is Olivier .", stringToFormat.FormatWith(data));
        }

        [Fact]
        public void FormatWith_ShouldFormat_WithNull()
        {
            var stringToFormat = "My name real name is Olivier {var}.";
            object data = null;

            Assert.Equal("My name real name is Olivier .", stringToFormat.FormatWith(data));
        }
    }
}
