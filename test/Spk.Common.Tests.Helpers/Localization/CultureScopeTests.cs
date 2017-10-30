using System;
using System.Globalization;
using System.Threading;
using Shouldly;
using Spk.Common.Helpers.Localization;
using Xunit;

namespace Spk.Common.Tests.Helpers.Localization
{
    public class CultureScopeTests
    {
        private const string Initial = "fr-CA";

        public CultureScopeTests()
        {
            var cultureInfo = CultureInfo.CreateSpecificCulture(Initial);

#if NET452
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
#endif

#if NETCOREAPP2_0
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
#endif
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("en-GB")]
        public void Should_EditBothCulturesOfCurrentThread_WhenModeIsBoth(string modified)
        {
            using (new CultureScope(modified, CultureScopeMode.Both))
            {
                CultureInfo.CurrentCulture.Name.ShouldBe(modified);
                CultureInfo.CurrentUICulture.Name.ShouldBe(modified);
            }
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("en-GB")]
        public void Should_EditMainCulturesOfCurrentThread_WhenModeIsMain(string modified)
        {
            using (new CultureScope(modified, CultureScopeMode.Main))
            {
                CultureInfo.CurrentCulture.Name.ShouldBe(modified);
                CultureInfo.CurrentUICulture.Name.ShouldBe(Initial);
            }
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("en-GB")]
        public void Should_EditUiCulturesOfCurrentThread_WhenModeIsUi(string modified)
        {
            using (new CultureScope(modified, CultureScopeMode.Ui))
            {
                CultureInfo.CurrentCulture.Name.ShouldBe(Initial);
                CultureInfo.CurrentUICulture.Name.ShouldBe(modified);
            }
        }

        [Fact]
        public void Should_RestoreCulture_WhenDisposed()
        {
            using (new CultureScope("en-US", CultureScopeMode.Ui))
            {
            }

            CultureInfo.CurrentCulture.Name.ShouldBe(Initial);
            CultureInfo.CurrentUICulture.Name.ShouldBe(Initial);
        }

        [Fact]
        public void Should_ThrowArgumentNullException_WhenCultureInfoIsNull()
        {
            CultureInfo nullCulture = null;
            Assert.Throws<ArgumentNullException>(() => new CultureScope(nullCulture));
        }
    }
}
