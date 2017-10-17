using System;
using Shouldly;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public partial class ArgumentGuardTests
    {
        [Fact]
        public void GuardIsEarlierThan_ShouldReturnUnalteredValue_WhenArgumentIsEarlierThanTarget()
        {
            var argument = new System.DateTime(2010, 10, 9);
            var result = argument.GuardIsEarlierThan(new System.DateTime(2010, 10, 10), nameof(argument));

            result.ShouldBe(argument);
        }

        [Fact]
        public void GuardIsEarlierThan_Throw_WhenArgumentIsLaterThanTarget()
        {
            var argument = new System.DateTime(2010, 10, 10);
           
            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(argument),
                () =>
                {
                    argument.GuardIsEarlierThan(new System.DateTime(2010, 10, 9), nameof(argument));
                });
        }

        [Fact]
        public void GuardIsEarlierThan_Throw_WhenArgumentIsEqualToTarget()
        {
            var argument = new System.DateTime(2010, 10, 9);
           
            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(argument),
                () =>
                {
                    argument.GuardIsEarlierThan(new System.DateTime(2010, 10, 9), nameof(argument));
                });
        }
    }
}