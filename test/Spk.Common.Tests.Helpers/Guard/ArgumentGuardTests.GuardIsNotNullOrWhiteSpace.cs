using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        [Theory]
        [InlineData("   ")]
        [InlineData("\n ")]
        [InlineData("\n\r")]
        [InlineData("")]
        [InlineData(null)]
        public void GuardIsNotNullOrWhiteSpace_ShouldThrow_WhenArgumentIsNullOrAllWhiteSpaces(string argument)
        {
            Assert.Throws<ArgumentException>(
                nameof(argument),
                () => { argument.GuardIsNotNullOrWhiteSpace(nameof(argument)); });
        }

        [Theory]
        [InlineData("Yay")]
        [InlineData("s \n")]
        [InlineData("\n\r Bleh")]
        public void GuardIsNotNullOrWhiteSpace_ShouldReturnUnalteredArgument_WhenArgumentIsNotNullOrAllWhiteSpaces(
            string argument)
        {
            var result = argument.GuardIsNotNullOrWhiteSpace(nameof(argument));
            result.ShouldBe(argument);
        }
    }
}
