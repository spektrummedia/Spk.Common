using NUnit.Framework;
using Spk.Common.Helpers.String;

namespace Spk.Common.Tests.Helpers.String
{
    /// <summary>
    /// These tests exist just to make sure they call the right API.
    /// </summary>
    public class StringExtensionsTests
    {
        [Test]
        public void IsNullorEmpty_ShouldReturnTrue_WhenNull()
        {
            string test = null;
            Assert.IsTrue(test.IsNullOrEmpty());
        }

        [Test]
        public void IsNullorEmpty_ShouldReturnTrue_WhenEmpty()
        {
            Assert.IsTrue("".IsNullOrEmpty());
        }

        [Test]
        public void IsNullorEmpty_ShouldReturnFalse_WhenNotEmpty()
        {
            Assert.IsFalse("test".IsNullOrEmpty());
        }

        [Test]
        public void HtmlEncode_ShouldEncodeProperly()
        {
            var result = "<p>Hi!</p>".HtmlEncode();
            Assert.That(result, Is.EqualTo("&lt;p&gt;Hi!&lt;/p&gt;"));
        }

        [Test]
        public void HtmlDecode_ShouldDecodeProperly()
        {
            var result = "&lt;p&gt;Hi!&lt;/p&gt;".HtmlDecode();
            Assert.That(result, Is.EqualTo("<p>Hi!</p>"));
        }

        [Test]
        public void UrlEncode_ShouldEncodeProperly()
        {
            var result = "test string".UrlEncode();
            Assert.That(result, Is.EqualTo("test+string"));
        }

        [Test]
        public void UrlDecode_ShouldDecodeProperly()
        {
            var result = "test+string".UrlDecode();
            Assert.That(result, Is.EqualTo("test string"));
        }
    }
}