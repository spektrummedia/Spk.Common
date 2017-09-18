using NUnit.Framework;
using Spk.Common.Validators.String;

namespace Spk.Common.Tests.Validators.String
{
    public class UrlValidatorTests
    {
        [Test]
        public void IsValidUrl_ShouldReturnFalse_WhenUrlIsInvalid()
        {
            var url = "www.google.com";
            Assert.IsFalse(url.IsValidUrl());

            url = "google.com";
            Assert.IsFalse(url.IsValidUrl());

            url = "";
            Assert.IsFalse(url.IsValidUrl());

            url = "http://";
            Assert.IsFalse(url.IsValidUrl());

            url = "294--0/09\02)2/-/-031-13-0";
            Assert.IsFalse(url.IsValidUrl());
        }

        [Test]
        public void IsValidUrl_ShouldReturnTrue_WhenUrlValid()
        {
            var url = "http://google.com";
            Assert.IsTrue(url.IsValidUrl());

            url = "https://google.com";
            Assert.IsTrue(url.IsValidUrl());

            url = "https://twitter.com/relateiq";
            Assert.IsTrue(url.IsValidUrl());

            url = "https://test.com/got?john=1&snow=2";
            Assert.IsTrue(url.IsValidUrl());

            url = "https://test.com/got#test";
            Assert.IsTrue(url.IsValidUrl());
        }
    }
}