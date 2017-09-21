using System;
using Spk.Common.Helpers.Guard;
using Xunit;

namespace Spk.Common.Tests.Helpers.Guard
{
    public class ArgumentGuardTests
    {
        [Theory]
        [InlineData(2, 1, 3)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 3)]
        [InlineData(2, 1.89, 2.03)]
        [InlineData(-1, -1.89, 0.93)]
        public void WithinRange_ShouldNotThrow_WhenArgumentIsWithinRange(
            double argument,
            double lowerBound,
            double upperBound)
        {
            ArgumentGuard.WithinRange(argument, nameof(argument), lowerBound, upperBound);
        }

        [Theory]
        [InlineData(0, 1, 3)]
        [InlineData(3, 1, 2)]
        [InlineData(-1, -0.89, 1.5)]
        public void WithinRange_ShouldThrow_WhenArgumentIsOutOfRange(
            double argument,
            double lowerBound,
            double upperBound)

        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ArgumentGuard.WithinRange(argument, nameof(argument), lowerBound, upperBound);
            });
        }
    }
}