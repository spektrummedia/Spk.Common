using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        [Fact]
        public void GuardIsNotEmpty_ShouldThrow_WhenArgumentIsEmpty()
        {
            Guid argument = Guid.Empty;
            Assert.Throws<ArgumentException>(
                nameof(argument), () => { argument.GuardGuidIsNotEmpty(nameof(argument)); });
        }

        [Fact]
        public void GuardIsNotEmpty_ShouldReturnUnalteredArgument_WhenArgumentIsNotEmpty()
        {
            var argument = Guid.NewGuid();
            var result = argument.GuardGuidIsNotEmpty(nameof(argument));
            result.ShouldBe(argument);
        }
    }
}
