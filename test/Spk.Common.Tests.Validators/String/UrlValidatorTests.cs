using Spk.Common.Validators.String;
using Xunit;

namespace Spk.Common.Tests.Validators.String
{
    public class UrlValidatorTests
    {
        [Fact]
        public void IsValidUrl_ShouldReturnFalse_WhenUrlIsInvalid()
        {
            var url = "www.google.com";
            Assert.False(url.IsValidUrl());

            url = "google.com";
            Assert.False(url.IsValidUrl());

            url = "";
            Assert.False(url.IsValidUrl());

            url = "http://";
            Assert.False(url.IsValidUrl());

            url = "294--0/09\02)2/-/-031-13-0";
            Assert.False(url.IsValidUrl());
        }

        [Fact]
        public void IsValidUrl_ShouldReturnTrue_WhenUrlValid()
        {
            var url = "http://google.com";
            Assert.True(url.IsValidUrl());

            url = "https://google.com";
            Assert.True(url.IsValidUrl());

            url = "https://twitter.com/relateiq";
            Assert.True(url.IsValidUrl());

            url = "https://test.com/got?john=1&snow=2";
            Assert.True(url.IsValidUrl());

            url = "https://test.com/got#test";
            Assert.True(url.IsValidUrl());
        }
    }
}