using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        [Fact]
        public void GuardIsLaterThan_ShouldReturnUnalteredValue_WhenArgumentIsLaterThanTarget()
        {
            var argument = new System.DateTime(2010, 10, 10);
            var result = argument.GuardIsLaterThan(new System.DateTime(2010, 10, 9), nameof(argument));

            result.ShouldBe(argument);
        }

        [Fact]
        public void GuardIsLaterThan_Throw_WhenArgumentIsEarlierThanTarget()
        {
            var argument = new System.DateTime(2010, 10, 9);

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(argument),
                () => { argument.GuardIsLaterThan(new System.DateTime(2010, 10, 10), nameof(argument)); });
        }

        [Fact]
        public void GuardIsLaterThan_Throw_WhenArgumentIsEqualToTarget()
        {
            var argument = new System.DateTime(2010, 10, 9);

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(argument),
                () => { argument.GuardIsLaterThan(new System.DateTime(2010, 10, 9), nameof(argument)); });
        }
    }
}