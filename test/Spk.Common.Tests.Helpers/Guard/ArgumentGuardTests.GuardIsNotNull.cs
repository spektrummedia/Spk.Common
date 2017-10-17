using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        [Fact]
        public void GuardIsNotNull_ShouldThrow_WhenArgumentIsNull()
        {
            string argument = null;
            Assert.Throws<ArgumentNullException>(
                nameof(argument), () => { argument.GuardIsNotNull(nameof(argument)); });
        }

        [Fact]
        public void GuardIsNotNull_ShouldReturnUnalteredArgument_WhenArgumentIsNotNull()
        {
            var argument = "Such not-nullness";
            var result = argument.GuardIsNotNull(nameof(argument));
            result.ShouldBe(argument);
        }
    }
}